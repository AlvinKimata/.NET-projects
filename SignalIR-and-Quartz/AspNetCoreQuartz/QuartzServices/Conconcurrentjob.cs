using Microsoft.AspNetCore.SignalR;
using Quartz;
using AspNetCoreQuartz;

namespace AspNetCoreQuartz.QuartzServices
{
    public class ConconcurrentJob : IJob
    {
        private readonly ILogger<ConconcurrentJob> _logger;
        private static int _counter = 0;
        private readonly IHubContext<JobsHub> _hubContext;

        public ConconcurrentJob (ILogger<ConconcurrentJob> logger, IHubContext<JobsHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var count = _counter ++;

            var beginMessage = $"Conconcurrent job BEGIN {count} {DateTime.UtcNow}";
            await _hubContext.Clients.All.SendAsync("ConcurrentJobs", beginMessage);
            _logger.LogInformation(beginMessage);


            Thread.Sleep(7000);

            var endMessage = $"Conconcurrent job END  {count} {DateTime.UtcNow}";
            await _hubContext.Clients.All.SendAsync("ConcurrentJobs", endMessage);
            _logger.LogInformation(endMessage);
        }
        
    }
}