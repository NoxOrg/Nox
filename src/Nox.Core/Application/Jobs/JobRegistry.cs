using Nox.Extensions;

namespace Nox.Application.Jobs;

internal sealed class JobRegistry : IJobRegistry
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, JobRegistration> _jobsRegistry  = new();


    public JobRegistry(IServiceProvider serviceProvider, ICollection<JobRegistration> jobsToRegister)
    {
        _serviceProvider = serviceProvider;
        jobsToRegister.ForEach(j => _jobsRegistry.Add(j.JobName, j));
    }

    public IJob? FindJob(string jobName)
    {
        if (_jobsRegistry.TryGetValue(jobName, out var jobRegistration))
        {
            return (IJob)_serviceProvider.GetService(jobRegistration.JobType)!;
        }
        return null;
    }

    public IReadOnlyCollection<JobRegistration> GetAllJobs()
    {
        return new List<JobRegistration>(_jobsRegistry.Values);
    }
}