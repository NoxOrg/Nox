using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;

namespace Nox.Logging.Serilog;

public static class LoggerConfigurationExtension
{
    public static LoggerConfiguration CreateSerilogLogger(this IConfigurationRoot configuration)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console();
        return logger;
    }

    public static LoggerConfiguration WithHttpContextAccessor(this LoggerConfiguration loggerConfiguration, IHttpContextAccessor httpContextAccessor)
    {
        loggerConfiguration.Enrich.WithEcsHttpContext(httpContextAccessor);
        return loggerConfiguration;
    }

    public static LoggerConfiguration WithElasticApm(this LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.Enrich.WithElasticApmCorrelationInfo();
        loggerConfiguration.WriteTo.Console(new EcsTextFormatter());
        return loggerConfiguration;
    }
}