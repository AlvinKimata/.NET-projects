using Quartz;
using AspNetCoreQuartz;
using AspNetCoreQuartz.QuartzServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();
builder.Services.AddQuartz(
    q => {
        var conconcurrentJobKey = new JobKey("ConconcurrentJob");
        q.AddJob<ConconcurrentJob>(opts => opts.WithIdentity(conconcurrentJobKey));
        q.AddTrigger(opts => opts
        .ForJob(conconcurrentJobKey)
        .WithIdentity("ConconcurrentJob-trigger")
        .WithSimpleSchedule( x => x.WithIntervalInSeconds(5).RepeatForever()));

        var nonConconcurrentJobKey = new JobKey("NonConconcurrentJob");
        q.AddJob<NonConconcurrentJob>(opts => opts.WithIdentity(nonConconcurrentJobKey));
        q.AddTrigger(opts => opts
        .ForJob(nonConconcurrentJobKey)
        .WithIdentity("NonConconcurrentJob-trigger")
        .WithSimpleSchedule( x => x.WithIntervalInSeconds(5).RepeatForever()));
    }
);

builder.Services.AddQuartzHostedService(
    q => q.WaitForJobsToComplete = true
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints( endpoints => 
{
    endpoints.MapHub<JobsHub>("/jobshub");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
