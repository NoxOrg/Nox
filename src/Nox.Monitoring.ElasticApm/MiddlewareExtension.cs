using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;

namespace Nox.Monitoring.ElasticApm;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseElasticMonitoring(this IApplicationBuilder builder, Solution.Monitoring? monitoringDefinition = null)
    {
        var config = monitoringDefinition.ToConfiguration();
        builder.UseAllElasticApm(config);
        return builder;
    }
    
}