namespace Nox.Localization;

public interface INoxLocalizationDbContextFactory
{
    NoxLocalizationDbContext CreateContext();
}