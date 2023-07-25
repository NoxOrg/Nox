using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Http;
using Nox.Abstractions.Logging;
using Serilog;

namespace Nox.Monitoring.ElasticApm;

public static class SerilogOptionsExtension
{
    public static SerilogOptionsBuilder WithElasticApm(this SerilogOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LoggerConfiguration.Enrich.WithElasticApmCorrelationInfo();
        optionsBuilder.LoggerConfiguration.WriteTo.Console(new EcsTextFormatter());
        return optionsBuilder;
    }
    
    public static SerilogOptionsBuilder WithEcsHttpContext(this SerilogOptionsBuilder optionsBuilder, IHttpContextAccessor? httpContextAccessor)
    {
        if (httpContextAccessor != null)
        {
            
            optionsBuilder.LoggerConfiguration.Enrich.WithEcsHttpContext(httpContextAccessor);
        }
        return optionsBuilder;
    }
}