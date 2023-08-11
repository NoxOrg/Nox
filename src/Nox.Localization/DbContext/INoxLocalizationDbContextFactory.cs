namespace Nox.Localization.DbContext;

public interface INoxLocalizationDbContextFactory
{
    NoxLocalizationDbContext CreateContext();
}