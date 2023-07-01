using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;

namespace Nox.Monitoring.ElasticApm;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseElasticMonitoring(this IApplicationBuilder builder)
    {
        builder.UseAllElasticApm();
        return builder;
    }
    
}