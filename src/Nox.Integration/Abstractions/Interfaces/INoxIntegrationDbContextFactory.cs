namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxIntegrationDbContextFactory
{
    NoxIntegrationDbContext CreateContext();
}