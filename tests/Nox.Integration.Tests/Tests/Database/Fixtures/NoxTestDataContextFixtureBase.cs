using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public abstract class NoxTestDataContextFixtureBase : INoxTestDataContextFixture
{
    protected DbContext _dbContext = default!;
    private readonly IServiceProvider _serviceProvider;

    protected NoxTestDataContextFixtureBase()
    {
        var services = new ServiceCollection();

        services.AddNox(
               null,
           (noxOptions) =>
           {
               noxOptions.WithoutMessagingTransactionalOutbox();
               noxOptions.WithoutNoxLogging();
           }, null)
            .AddLogging(configure => configure.SetMinimumLevel(LogLevel.Error));        
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(INoxDatabaseProvider));
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }
        services.AddSingleton(sp =>
        {            
            return GetDatabaseProvider(
                sp.GetServices<INoxTypeDatabaseConfigurator>(),
                sp.GetRequiredService<NoxCodeGenConventions>());
        });

        _serviceProvider = services.BuildServiceProvider();
    }

    public NoxCodeGenConventions NoxCodeGenConventions => _serviceProvider.GetRequiredService<NoxCodeGenConventions>();

    public DbContext DataContext
    {
        get
        {
            if (_dbContext == null)
            {
                RefreshDbContext();
            }

            return _dbContext!;
        }
    }

    public void RefreshDbContext()
    {
        var scope = _serviceProvider.CreateScope();
        _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    protected abstract INoxDatabaseProvider GetDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState);
}