using System.Reflection.Metadata.Ecma335;
using Serilog;

namespace Nox.Abstractions.Logging;

public class SerilogOptionsBuilder
{
    public LoggerConfiguration LoggerConfiguration { get; }

    public SerilogOptionsBuilder(LoggerConfiguration loggerConfiguration)
    {
        LoggerConfiguration = loggerConfiguration;
    }
}