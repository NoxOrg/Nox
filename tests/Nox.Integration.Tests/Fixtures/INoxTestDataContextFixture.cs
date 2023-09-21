using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public interface INoxTestDataContextFixture
{
    void RefreshDbContext();

    TestWebAppDbContext DataContext { get; }
}