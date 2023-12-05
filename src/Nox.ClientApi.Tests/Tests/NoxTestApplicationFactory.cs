using Divergic.Logging.Xunit;
using MassTransit;
using MassTransit.Testing;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Nox.Types.EntityFramework.Abstractions;
using ClientApi.Infrastructure.Persistence;
using Xunit.Abstractions;
using Nox.Solution;
using Nox.Infrastructure;
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>
{
    private readonly ITestOutputHelper _testOutput;
    private readonly ITestDatabaseService _databaseService;
    private readonly bool _enableMessaging;
    private readonly string Environment = Environments.Production;

    public NoxTestApplicationFactory(
        ITestOutputHelper testOutput,
        ITestDatabaseService databaseService,
        bool enableMessaging,
        string? environment = null)
    {
        _testOutput = testOutput;
        _databaseService = databaseService;
        _enableMessaging = enableMessaging;

        if (environment != null)
        {
            Environment = environment;
        }
    }

    public ITestHarness GetTestHarness()
    {
        return Services.GetTestHarness();
    }

    public void ResetDataContext()
    {
        var dbContext = Services.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    internal AppDbContext GetDbContext() => Services.GetRequiredService<AppDbContext>();

    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
            .UseEnvironment(Environment)
            .UseStartup<StartupFixture>()
            // this extension makes it sure that our lambda will run after the Startup.ConfigureServices()
            // method has been executed.
            .ConfigureTestServices(services =>
            {
                //Override Entity Store Db Provider and set container connection string
                var descriptors = services.Where(d => d.ServiceType == typeof(INoxDatabaseProvider)).ToList();
                if (descriptors.Any())
                {
                    foreach (var descriptor in descriptors)
                    {
                        services.Remove(descriptor);
                    }
                }
                services.AddSingleton(sp =>
                {
                    return _databaseService.GetDatabaseProvider(
                        sp.GetServices<INoxTypeDatabaseConfigurator>(),
                        sp.GetRequiredService<NoxCodeGenConventions>(),
                        sp.GetRequiredService<INoxClientAssemblyProvider>());
                });

                if (_enableMessaging)
                    services.AddMassTransitTestHarness();

                //TODO Override NoxSolution with _dbProviderKind
            })
            .ConfigureLogging(opts => opts.AddXunit(_testOutput, new LoggingConfig
            {
                LogLevel = LogLevel.Error
            }));

        return host;
    }
}