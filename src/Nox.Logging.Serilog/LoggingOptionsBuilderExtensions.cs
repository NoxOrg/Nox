using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Abstractions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace Nox.Logging.Serilog;

public static class LoggingOptionsBuilderExtensions
{
    public static WebApplicationBuilder UseNoxSerilogLogging(this WebApplicationBuilder builder, Action<SerilogOptionsBuilder>? serilogOptionsAction = null)
    {
        var loggerConfig = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console();
        var logger = loggerConfig.CreateLogger();
        builder.Services.AddSingleton(loggerConfig);
        builder.Logging.AddSerilog(logger);
        var serilogOptionsBuilder = new SerilogOptionsBuilder(builder.Services, builder.Configuration);
        serilogOptionsAction?.Invoke(serilogOptionsBuilder);
        return builder;
    }
}