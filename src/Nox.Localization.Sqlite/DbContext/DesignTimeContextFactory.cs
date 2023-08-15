using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Nox.Localization.DbContext;

namespace Nox.Localization.Sqlite.DbContext;

public class DesignTimeContextFactory: IDesignTimeDbContextFactory<NoxLocalizationDbContext>
{
    public NoxLocalizationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NoxLocalizationDbContext>();
        optionsBuilder.UseSqlite("data source=localization.db", sqlOpt =>
        {
            sqlOpt.MigrationsAssembly("Nox.Localization.Sqlite");
        });
        return new NoxLocalizationDbContext(optionsBuilder.Options);
    }
}