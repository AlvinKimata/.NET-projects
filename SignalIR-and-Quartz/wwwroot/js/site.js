const connection = new signalR.HubConnectionBuilder() // Use 'HubConnectionBuilder' instead of 'HubConnectionbuilder'
    .withUrl("/jobshub")
    .configureLogging(signalR.LogLevel.Information) // Use 'LogLevel' instead of 'Loglevel'
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

connection.onclose(async () => {
    await start();
});

start();

connection.on("ConcurrentJobs", function (message) {
    var li = document.createElement("li");
    document.getElementById("concurrentJobs").appendChild(li);
    li.textContent = `${message}`;
});

connection.on("NonConcurrentJobs", function (message) {
    var li = document.createElement("li");
    document.getElementById("nonConcurrentJobs").appendChild(li); // Corrected typo in id
    li.textContent = `${message}`;
});
