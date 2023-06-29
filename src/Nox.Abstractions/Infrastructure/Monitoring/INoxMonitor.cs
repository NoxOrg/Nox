using Microsoft.Extensions.DependencyInjection;

namespace Nox.Abstractions.Infrastructure.Monitoring;

public interface INoxMonitor
{
    void Install();
}