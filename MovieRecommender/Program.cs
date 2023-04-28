using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using MovieRecommender;

namespace MovieRecommender
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create MLContext to be shared across the model creation workflow objects.
            MLContext mLContext = new MLContext();

            //Load data.
            (IDataView training, IDataView test) = LoadData(mLContext);
            ITransformer model = BuildAndTrainModel(mLContext, training);
            EvaluateModel(mLContext, test, model);

            // Use model to try a single prediction (one row of data)
            UseModelForSinglePrediction(mLContext, model);

            // Save model
            SaveModel(mLContext, training.Schema, model);



        }

        public static (IDataView training, IDataView test) LoadData(MLContext mLContext)
        {
            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-test.csv");
            
            //Data in DataView is represented as an IDataView interface. It is a flexiblw, efficient way if describing tabilar data.
            IDataView training = mLContext.Data.LoadFromTextFile<MovieRating>(trainingDataPath, hasHeader: true, separatorChar: ',');
            IDataView test = mLContext.Data.LoadFromTextFile<MovieRating>(testDataPath, hasHeader: true, separatorChar: ',');

            return (training, test);
        }

        //Build and train the model.
        public static ITransformer BuildAndTrainModel(MLContext mLContext, IDataView training)
        {
            //Add data transformations.
            IEstimator<ITransformer> estimator = mLContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId")
                .Append(mLContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "movieId"));

            //Set algorithm options and append algorithm <SnippetAlgorthm>
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mLContext.Recommendation().Trainers.MatrixFactorization(options));

            Console.WriteLine("====================== Training the model ===================");
            ITransformer model = trainerEstimator.Fit(training);
            return model;
        }

        //Evaluate the model.
        public static void EvaluateModel(MLContext mLContext, IDataView test, ITransformer model)
        {
            Console.WriteLine("================== Evaluating the model =====================");
            var prediction = model.Transform(test);
            var metrics = mLContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());

        }

        //Use model for a single prediction.
        public static void UseModelForSinglePrediction(MLContext mLContext, ITransformer model)
        {
            Console.WriteLine("================== Making a prediction ==================");
            var predictionEngine = mLContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(model);

            //Create test input to make a prediction.
            var testInput = new MovieRating { userId = 6, movieId = 10 };

            var movieRatingPrediction = predictionEngine.Predict(testInput);

            if (Math.Round(movieRatingPrediction.Score, 1) > 3.5)
            {
                Console.WriteLine("Movie " + testInput.movieId + " is recommended for user " + testInput.userId);
            }
            else
            {
                Console.WriteLine("Movie " + testInput.movieId + " is not recommended for user " + testInput.userId);

            }
        }

        //Save model.
        public static void SaveModel(MLContext mLContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            //Save the model to a zip file
            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");

            Console.WriteLine("======================== Saving the model to a file ===================");
            mLContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }
    }
}

