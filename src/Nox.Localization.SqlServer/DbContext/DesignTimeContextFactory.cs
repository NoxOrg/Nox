using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Nox.Localization.DbContext;

namespace Nox.Localization.SqlServer.DbContext;

public class DesignTimeContextFactory: IDesignTimeDbContextFactory<NoxLocalizationDbContext>
{
    public NoxLocalizationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NoxLocalizationDbContext>();
        optionsBuilder.UseSqlServer("data source=localhost;user id=sa; password=Developer*123; database=LocalizationStore; pooling=false;encrypt=false", sqlOpt =>
        {
            sqlOpt.MigrationsAssembly("Nox.Localization.SqlServer");
        });
        return new NoxLocalizationDbContext(optionsBuilder.Options);
    }
}