using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nox.Logging.Serilog;
using Nox.Solution;
using Serilog;

namespace Nox.Logging;

public static class LoggingExtension
{
    public static void AddLogging(this ILoggingBuilder builder, IConfigurationRoot configuration, NoxSolution solution, IHttpContextAccessor? httpContextAccessor = null)
    {
        //Todo logging should be defined in yaml definition, currently not, so defaulting to Serilog
        var loggerConfig = configuration.CreateSerilogLogger();
        if (solution.Infrastructure is { Dependencies.Monitoring: not null })
        {
            var monitoringConfig = solution.Infrastructure.Dependencies.Monitoring;
            switch (monitoringConfig.Provider)
            {
                case MonitoringProvider.ElasticApm:
                    if (httpContextAccessor != null) loggerConfig.WithHttpContextAccessor(httpContextAccessor);
                    loggerConfig.WithElasticApm();
                    break;
            }
        }

        var logger = loggerConfig.CreateLogger();
        builder.AddSerilog(logger);
    }
}