using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Nox.Logging;

public class LoggingOptionsBuilder
{
    public ILoggingBuilder LoggingBuilder { get; }

    public LoggingOptionsBuilder(ILoggingBuilder loggingBuilder)
    {
        LoggingBuilder = loggingBuilder;
    }
}