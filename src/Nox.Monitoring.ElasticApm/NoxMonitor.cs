using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nox.Abstractions.Infrastructure.Monitoring;
using Serilog;
using Serilog.Exceptions;

namespace Nox.Monitoring.ElasticApm;

public class NoxMonitor: INoxMonitor
{
    public void Install(IHostBuilder builder)
    {
        
    }

    public void Install(IConfigurationRoot configuration, ILoggingBuilder builder)
    {
        var httpAccessor = configuration.Get<IHttpContextAccessor>();
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithElasticApmCorrelationInfo()
            .Enrich.WithEcsHttpContext(httpAccessor)
            .WriteTo.Console(new EcsTextFormatter())
            .CreateLogger();
            
        builder.ClearProviders();
        builder.AddSerilog(logger);
    }
}