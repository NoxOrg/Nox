using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Nox.Abstractions.Infrastructure.Monitoring;

public interface INoxMonitor
{
    void Install(IHostBuilder hostBuilder);
    void Install(IConfigurationRoot configuration, ILoggingBuilder builder);
}