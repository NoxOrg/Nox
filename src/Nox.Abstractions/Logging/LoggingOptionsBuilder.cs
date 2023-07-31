using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Nox.Abstractions.Logging;

public class LoggingOptionsBuilder
{
    public ILoggingBuilder LoggingBuilder { get; }
    public IConfigurationRoot Configuration { get; }

    public LoggingOptionsBuilder(ILoggingBuilder loggingBuilder, IConfigurationRoot configuration)
    {
        LoggingBuilder = loggingBuilder;
        Configuration = configuration;
    }
}