using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;
using Nox.Solution.Exceptions;

namespace Nox.Monitoring.ElasticApm;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseElasticMonitoring(this IApplicationBuilder builder)
    {
        var solution = builder.ApplicationServices.GetService<Solution.Solution>();
        if (solution == null) throw new NoxSolutionConfigurationException("Nox solution definition is not defined. If you want to use monitoring you have to provide a Nox yaml definition.");
        if (solution.Infrastructure == null) throw new NoxSolutionConfigurationException("Nox solution infrastructure is not defined. If you want to use monitoring you have to provide an infrastructure definition");
        if (solution.Infrastructure.Dependencies == null) throw new NoxSolutionConfigurationException("Nox solution infrastructure -> dependencies is not defined. If you want to use monitoring you have to provide an infrastructure -> dependencies definition");
        if (solution.Infrastructure.Dependencies.Monitoring == null) throw new NoxSolutionConfigurationException("Nox solution infrastructure -> dependencies -> monitoring is not defined. If you want to use monitoring you have to provide a monitoring definition");
        if (solution.Infrastructure.Dependencies.Monitoring.Provider != MonitoringProvider.ElasticApm) throw new NoxSolutionConfigurationException("Invalid monitoring provider. If you want to use Elastic APM monitoring you have to use the ElasticApm provider in infrastructure -> dependencies -> monitoring.");
        var config = solution.Infrastructure.Dependencies.Monitoring.ToConfiguration();
        builder.UseAllElasticApm(config);
        return builder;
    }
    
}