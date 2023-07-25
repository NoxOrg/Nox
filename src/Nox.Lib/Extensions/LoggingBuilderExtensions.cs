using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nox.Abstractions.Logging;

namespace Nox;

public static class LoggingBuilderExtensions
{
    public static ILoggingBuilder AddLogging(this ILoggingBuilder builder, IConfigurationRoot configuration, Action<LoggingOptionsBuilder>? optionsAction)
    {
        var optionsBuilder = new LoggingOptionsBuilder(builder);
        optionsAction?.Invoke(optionsBuilder);
        return builder;
    }
    
    
}