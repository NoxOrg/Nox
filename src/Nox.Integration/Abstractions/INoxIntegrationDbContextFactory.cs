namespace Nox.Integration.Abstractions;

public interface INoxIntegrationDbContextFactory
{
    NoxIntegrationDbContext CreateContext();
}