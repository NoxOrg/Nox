using Microsoft.AspNetCore.Builder;
using Nox.Monitoring.ElasticApm;
using Nox.Solution;

namespace Nox.Monitoring;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseMonitoring(this IApplicationBuilder builder, NoxSolution solution)
    {
        if (solution.Infrastructure is { Dependencies.Monitoring: not null })
        {
            var monitoringConfig = solution.Infrastructure.Dependencies.Monitoring;
            switch (monitoringConfig.Provider)
            {
                case MonitoringProvider.ElasticApm:
                    builder.UseElasticMonitoring();
                    break;
            }
        }
        
        return builder;
    }
    
}