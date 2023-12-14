using Microsoft.Extensions.DependencyInjection;

namespace Nox.Integration.Abstractions;

public class NoxIntegrationOptionsBuilder
{
    public IServiceCollection Services { get; }

    public NoxIntegrationOptionsBuilder(IServiceCollection services)
    {
        Services = services;
    }
}