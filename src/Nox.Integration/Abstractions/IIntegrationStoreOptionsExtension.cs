using Microsoft.Extensions.DependencyInjection;

namespace Nox.Integration.Abstractions;

public interface IIntegrationStoreOptionsExtension
{
    void ApplyServices(IServiceCollection services);

    void Validate(IIntegrationStoreOptions options);

}