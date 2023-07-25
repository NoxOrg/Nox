using Microsoft.AspNetCore.Builder;

namespace Nox.Abstractions.Monitoring;

public class MonitoringOptionsBuilder
{
    public IApplicationBuilder ApplicationBuilder { get; }

    public MonitoringOptionsBuilder(IApplicationBuilder applicationBuilder)
    {
        ApplicationBuilder = applicationBuilder;
    }
}