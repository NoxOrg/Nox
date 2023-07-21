namespace Nox.Integration.Abstractions;

public interface IIntegrationStoreOptions
{
    IEnumerable<IIntegrationStoreOptionsExtension> Extensions { get; }

    TExtension? FindExtension<TExtension>()
        where TExtension : class, IIntegrationStoreOptionsExtension;
}