using Microsoft.EntityFrameworkCore;
using Nox.Integration.Tests.Fixtures;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public abstract class NoxIntegrationContainerTestBase<TFixture> : IClassFixture<TFixture>
    where TFixture : class, INoxTestDataContextFixture
{
    private readonly DbContext _dbContext;

    protected NoxIntegrationContainerTestBase(TFixture fixture)
    {
        _dbContext = fixture.DataContext;

        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    protected TDbContext GetDataContext<TDbContext>()
        where TDbContext : DbContext
    {
        return (TDbContext)_dbContext;
    }
}