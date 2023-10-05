using Microsoft.EntityFrameworkCore;

namespace Nox.Integration.Tests.Fixtures;

public interface INoxTestDataContextFixture
{
    void RefreshDbContext();

    DbContext DataContext { get; }
}