using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions.Logging;
using Serilog;

namespace Nox.Monitoring.ElasticApm;

public static class SerilogOptionsExtension
{
    public static SerilogOptionsBuilder WithElasticApm(this SerilogOptionsBuilder optionsBuilder)
    {
        var provider = optionsBuilder.Services.BuildServiceProvider();
        var loggerConfig = provider.GetRequiredService<LoggerConfiguration>();
        loggerConfig.Enrich.WithElasticApmCorrelationInfo();
        loggerConfig.WriteTo.Console(new EcsTextFormatter());
        return optionsBuilder;
    }
    
    public static SerilogOptionsBuilder WithEcsHttpContext(this SerilogOptionsBuilder optionsBuilder)
    {
        var httpAccessor = optionsBuilder.Configuration.Get<HttpContextAccessor>();
        if (httpAccessor != null)
        {
            var provider = optionsBuilder.Services.BuildServiceProvider();
            var loggerConfig = provider.GetRequiredService<LoggerConfiguration>();
            loggerConfig.Enrich.WithEcsHttpContext(httpAccessor);
        }
        return optionsBuilder;
    }
}