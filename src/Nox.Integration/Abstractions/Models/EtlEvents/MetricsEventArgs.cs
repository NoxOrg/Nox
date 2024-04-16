namespace Nox.Integration.Abstractions.Models;

public class MetricsEventArgs: EventArgs
{
    public dynamic? DataRecord { get; }

    public MetricsEventArgs(dynamic dataRecord)
    {
        DataRecord = dataRecord;
    }
}