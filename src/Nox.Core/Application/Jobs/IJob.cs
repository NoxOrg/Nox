namespace Nox.Application.Jobs;


/// <summary>
/// All Jobs will be registerd automatically by the framework in the container as Transient
/// </summary>
public interface IJob
{
    /// <summary>
    /// Run the job, if failed, throw exception
    /// </summary>
    void Run();
}


/// <summary>
/// Unique Job Name and and Scheduler  - All jobs will require to have it
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class NoxJobAttribute : Attribute
{
    public string Name { get; }
    public string CronExpression { get; }
    public NoxJobAttribute(string name, string cronExpression)
    {
        Name = name;
        CronExpression = cronExpression;
    }
}
