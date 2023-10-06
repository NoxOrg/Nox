using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Nox.Monitoring.ElasticApm;

public static class LoggerConfigurationExtensions
{    
    public static LoggerConfiguration AddNoxElasticMonitoring(this LoggerConfiguration loggerConfig)
    {
        loggerConfig.Enrich.WithElasticApmCorrelationInfo();
        loggerConfig.WriteTo.Console(new EcsTextFormatter());
        return loggerConfig;
    }

    public static LoggerConfiguration AddNoxEcsHttpContext(this LoggerConfiguration loggerConfig, HttpContextAccessor? httpAccessor)
    {
        if (httpAccessor == null)
        {
            return loggerConfig; 
        }
        loggerConfig.Enrich.WithEcsHttpContext(httpAccessor);
        return loggerConfig;
    }
}