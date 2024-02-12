using Microsoft.Extensions.Logging;

namespace Nox.Application.Jobs
{
    internal sealed class JobScheduler : IJobScheduler
    {
        private readonly ILogger<JobScheduler> _logger;
        private readonly IJobRegistry _jobRegistry;        

        public JobScheduler(ILogger<JobScheduler> logger, IJobRegistry jobRegistry)
        {
            _logger = logger;
            _jobRegistry = jobRegistry;        
        }
        public void Run(string jobName)
        {
            try
            {
                var job = _jobRegistry.FindJob(jobName);

                if (job is null)
                {
                    _logger.LogError("Job {jobName} can not be found", jobName);
                    return;
                }

                _logger.LogInformation("Job {jobName} started", jobName);
               
                job.Run();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Job {jobName} failed", jobName);
                return;
            }
            _logger.LogInformation("Job {jobName} completed", jobName);
        }
    }
}
