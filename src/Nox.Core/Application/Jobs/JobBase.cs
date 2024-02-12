using Microsoft.Extensions.Logging;

namespace Nox.Application.Jobs;

public abstract class JobBase : IJob
{
    protected ILogger<IJob> Logger { get; }

    protected JobBase(ILogger<IJob> logger)
    {
        Logger = logger;
    }

    public virtual void Run()
    {
        Logger.LogWarning("Job {TypeName} does not have a implementation", GetType().Name);
    }
}
