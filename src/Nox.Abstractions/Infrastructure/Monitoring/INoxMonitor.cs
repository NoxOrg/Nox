using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Nox.Abstractions.Infrastructure.Monitoring;

public interface INoxMonitor
{
    void Install(IHostBuilder hostBuilder);
    void Install(ILoggingBuilder builder);
}