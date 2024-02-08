namespace Nox.Application.Jobs;

public interface IJobRegistry
{    
    /// <summary>
    /// Finds, resolves a transient job by name. Null if Not Found
    /// </summary>    
    /// <param name="jobName"></param>
    /// <returns></returns>
    IJob? FindJob(string jobName);

    /// <summary>
    /// List of all jobs name
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<JobRegistration> GetAllJobs();
}

public sealed record JobRegistration(string JobName, string RecurrentCronExpression, Type JobType);

