using Nox.Diagnostics;
using Nox.Integration.Abstractions;

namespace Nox.Integration;

public class IntegrationStoreOptionsBuilder: IIntegrationStoreOptionsBuilder
{
    private IntegrationStoreOptions _options;
    
    public IntegrationStoreOptionsBuilder(): this(new IntegrationStoreOptions<IStoreService>())
    {
        
    }
    
    public IntegrationStoreOptionsBuilder(IntegrationStoreOptions options)
    {
        Guard.NotNull(options, nameof(options));

        _options = options;
    }
    
    public void AddOrUpdateExtension<TExtension>(TExtension extension) where TExtension : class, IIntegrationStoreOptionsExtension
    {
        
    }
}