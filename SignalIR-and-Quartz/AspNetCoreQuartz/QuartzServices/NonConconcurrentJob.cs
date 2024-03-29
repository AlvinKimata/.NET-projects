using Microsoft.AspNetCore.SignalR;
using Quartz;
using AspNetCoreQuartz;

namespace AspNetCoreQuartz.QuartzServices
{
    [DisallowConcurrentExecution]
    public class NonConconcurrentJob : IJob
    {
        private readonly ILogger<NonConconcurrentJob> _logger;
        private static int _counter = 0;
        private readonly IHubContext<JobsHub> _hubContext;

        public NonConconcurrentJob (ILogger<NonConconcurrentJob> logger, IHubContext<JobsHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var count = _counter ++;

            var beginMessage = $"Nonconconcurrent job BEGIN {count} {DateTime.UtcNow}";
            await _hubContext.Clients.All.SendAsync("NonConcurrentJobs", beginMessage);
            _logger.LogInformation(beginMessage);


            Thread.Sleep(7000);

            var endMessage = $"Nonconconcurrent job END  {count} {DateTime.UtcNow}";
            await _hubContext.Clients.All.SendAsync("NonConcurrentJobs", endMessage);
            _logger.LogInformation(endMessage);
        }
        
    }
}