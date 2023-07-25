using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Nox.Abstractions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace Nox.Logging.Serilog;

public static class LoggingOptionsBuilderExtension
{
    public static LoggingOptionsBuilder UseSerilog(this LoggingOptionsBuilder optionsBuilder, Action<SerilogOptionsBuilder>? serilogOptionsAction = null)
    {
        var loggerConfig = new LoggerConfiguration()
            .ReadFrom.Configuration(optionsBuilder.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console();
        var logger = loggerConfig.CreateLogger();
        optionsBuilder.LoggingBuilder.AddSerilog(logger);
        var serilogOptionsBuilder = new SerilogOptionsBuilder(loggerConfig);
        serilogOptionsAction?.Invoke(serilogOptionsBuilder);
        return optionsBuilder;
    }
}