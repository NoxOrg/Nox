namespace Nox.Integration.Abstractions;

public interface IIntegrationStoreOptionsBuilder
{
    void AddOrUpdateExtension<TExtension>(TExtension extension)
        where TExtension : class, IIntegrationStoreOptionsExtension;
}