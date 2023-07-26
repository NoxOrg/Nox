using Microsoft.Extensions.Options;
using Localization.SqlLocalizer.DbStringLocalizer;

namespace Nox.Translations.Tests;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class LocalizationContextFactory : IDesignTimeDbContextFactory<LocalizationModelContext>
{
    public LocalizationModelContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LocalizationModelContext>();


        var sqlConnectionString = "Data Source=localization.db;";

        optionsBuilder.UseSqlite(sqlConnectionString,
            b => b.MigrationsAssembly("Nox.Translations.Tests"));
        
        var sqlOptions = new SqlContextOptions();

        return new LocalizationModelContext(optionsBuilder.Options, Options.Create(sqlOptions) );
    }
}
