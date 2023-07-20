using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Nox.Integration.Store.SqlServer;

public class IntegrationDbContextFactory: IDesignTimeDbContextFactory<IntegrationDbContext>
{
    /// <summary>
    /// DbContext builder Used for migrations
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public IntegrationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IntegrationDbContext>();
        optionsBuilder.UseSqlServer("data source=localhost;user id=sa; password=Developer*123; database=IntegrationStore; pooling=false;encrypt=false", sqlOpt =>
        {
            sqlOpt.MigrationsAssembly("Nox.Integration.Store.SqlServer");
        });
        return new IntegrationDbContext(optionsBuilder.Options);
    }
}
