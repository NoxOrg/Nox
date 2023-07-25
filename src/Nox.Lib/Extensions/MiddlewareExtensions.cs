using Microsoft.AspNetCore.Builder;
using Nox.Abstractions.Monitoring;

namespace Nox;

public static class MiddlewareExtensions
{
    public static void UseMonitoring(this IApplicationBuilder builder, Action<MonitoringOptionsBuilder>? optionsAction)
    {
        var optionsBuilder = new MonitoringOptionsBuilder(builder);
        optionsAction?.Invoke(optionsBuilder);
    }
}