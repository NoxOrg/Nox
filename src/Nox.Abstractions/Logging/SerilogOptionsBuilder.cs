using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nox.Abstractions.Logging;

public class SerilogOptionsBuilder
{
    public IServiceCollection Services { get; }
    public IConfigurationRoot Configuration { get; }

    public SerilogOptionsBuilder(IServiceCollection services, IConfigurationRoot configuration)
    {
        Services = services;
        Configuration = configuration;
    }
}