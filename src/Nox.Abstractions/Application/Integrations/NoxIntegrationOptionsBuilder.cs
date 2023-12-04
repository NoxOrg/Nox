using Microsoft.Extensions.DependencyInjection;

namespace Nox.Abstractions;

public class NoxIntegrationOptionsBuilder
{
    public IServiceCollection Services { get; }

    public NoxIntegrationOptionsBuilder(IServiceCollection services)
    {
        Services = services;
    }
}