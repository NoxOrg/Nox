using Microsoft.Extensions.DependencyInjection;

namespace Nox.Application.Integrations;

public class NoxIntegrationOptionsBuilder
{
    public IServiceCollection Services { get; }

    public NoxIntegrationOptionsBuilder(IServiceCollection services)
    {
        Services = services;
    }
}