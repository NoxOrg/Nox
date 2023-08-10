using Microsoft.Extensions.DependencyInjection;

namespace Nox.Abstractions.Localization;

public class NoxLocalizationOptionsBuilder
{
    public IServiceCollection Services { get; }
    
    public NoxLocalizationOptionsBuilder(IServiceCollection services)
    {
        Services = services;
    }
    
    
}