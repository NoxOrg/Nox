namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

public class IntegrationScheduleRetryPolicy
{
    public int? Limit { get; internal set; }
    public int? DelaySeconds { get; internal set; }
    public int? DoubleDelayLimit { get; internal set; }
}