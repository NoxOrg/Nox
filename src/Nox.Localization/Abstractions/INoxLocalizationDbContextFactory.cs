using Nox.Localization.DbContext;

namespace Nox.Localization.Abstractions;

public interface INoxLocalizationDbContextFactory
{
    NoxLocalizationDbContext CreateContext();
}