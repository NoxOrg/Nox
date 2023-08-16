// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Nox.Abstractions;
using Nox;
using Nox.Solution;
using Nox.EntityFramework.SqlServer;
using Nox.Localization;
using Nox.Localization.SqlServer;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;
using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Presentation.Api.OData;

public static class NoxWebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Services.AddNoxLib(Assembly.GetExecutingAssembly());
        appBuilder.Services.AddNoxOdata();
        appBuilder.Services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        appBuilder.Services.AddSingleton<DbContextOptions<SampleWebAppDbContext>>();
        appBuilder.Services.AddSingleton<INoxDatabaseConfigurator>(provider => new SqlServerDatabaseProvider(
            NoxDataStoreType.EntityStore,
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        appBuilder.Services.AddSingleton<INoxDatabaseProvider>(provider => new SqlServerDatabaseProvider(
            NoxDataStoreType.EntityStore,
            provider.GetServices<INoxTypeDatabaseConfigurator>())
        );
        appBuilder.Services.AddDbContext<SampleWebAppDbContext>();
        appBuilder.Services.AddDbContext<ODataDbContext>();
        appBuilder.UseNoxLocalization(opt =>
        {
            opt.WithSqlServerStore();
        });
        return appBuilder;
    }
    
}
