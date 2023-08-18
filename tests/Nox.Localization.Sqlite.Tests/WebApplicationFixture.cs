using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.EntityFramework.Sqlite;
using Nox.EntityFramework.SqlServer;
using Nox.Localization.Tests.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization.Sqlite.Tests;

public class WebApplicationFixture
{
    public WebApplication? FixtureWebApplication { get; }

    public void InitDatabase()
    {
        if (FixtureWebApplication == null) throw new ArgumentNullException(nameof(FixtureWebApplication));
        var dbContextFactory = FixtureWebApplication.Services.GetRequiredService<INoxLocalizationDbContextFactory>();
        var context = dbContextFactory.CreateContext();
        context.Database.ExecuteSql($"DELETE FROM Translations;");
        AddTranslation(context, "en-GB", "Hello World!", "Hello World!");
        AddTranslation(context, "en-GB", "Bye {0}!", "Bye {0}!");
        AddTranslation(context, "fr-FR", "Hello World!", "Bonjour Monde!");
        AddTranslation(context, "fr-FR", "Bye {0}!", "au revoir {0}!");
        context.SaveChanges();
    }

    private void AddTranslation(NoxLocalizationDbContext context, string cultureCode, string key, string text)
    {
        context.Translations.Add(new Translation
        {
            CultureCode = cultureCode,
            LastUpdatedUtc = DateTime.UtcNow,
            ResourceKey = "Nox.Localization.Sqlite.Tests.SqliteLocalizationTests",
            Validated = false,
            Key = key,
            Text = text
        });
    }

    public WebApplicationFixture()
    {
        // Simulate app startup
        var solution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sqlite-localizer.solution.nox.yaml")
            .Build();
        
        var host = WebApplication.CreateBuilder();
        host.Services.AddSingleton<NoxSolution>(solution);
        host.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));

        host.Services.AddNoxLib(Assembly.GetExecutingAssembly());
        host.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        host.Services.AddSingleton<DbContextOptions<TestDbContext>>();
        host.Services.AddSingleton<INoxDatabaseConfigurator>(provider => new SqliteDatabaseProvider(
            NoxDataStoreType.EntityStore,
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        host.Services.AddSingleton<INoxDatabaseProvider>(provider => new SqliteDatabaseProvider(
            NoxDataStoreType.EntityStore,
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        
        host.Services.AddDbContext<TestDbContext>();
        host.Services.AddNoxLocalization();
        
        var app = host.Build();
        app.UseNox();
        
        var dbContextFactory = app.Services.GetRequiredService<INoxLocalizationDbContextFactory>();
        var context = dbContextFactory.CreateContext();
        context.Database.Migrate();
        
        app.UseNox();
        
        FixtureWebApplication = app;
    }

    public void SetCulture(string? culture)
    {
        if(culture is not null) 
        { 
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = new CultureInfo(culture); 
        }
    }
}