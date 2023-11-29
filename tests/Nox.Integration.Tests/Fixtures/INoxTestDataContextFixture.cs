using Microsoft.EntityFrameworkCore;
using Nox.Solution;

namespace Nox.Integration.Tests.Fixtures;

public interface INoxTestDataContextFixture
{
    void RefreshDbContext();

    DbContext DataContext { get; }

    NoxCodeGenConventions NoxCodeGenConventions { get; }
}