﻿using DotNet.Testcontainers.Containers;
using Nox;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests;

/// <summary>
/// Database instance for testing
/// For Development purposes
/// </summary>
public class TestDatabaseInstanceService : IAsyncLifetime, ITestDatabaseService
{
#if DEBUG    
    public static readonly DatabaseServerProvider DbProviderKind = DatabaseServerProvider.Postgres;
#else
    public static readonly DatabaseServerProvider DbProviderKind = DatabaseServerProvider.SqlServer;
#endif

    private NoxTestApplicationFactory _applicationFactory = null!;

    public NoxTestApplicationFactory GetTestApplicationFactory(ITestOutputHelper testOutput, bool enableMessagingTests, string? environment = null)
    {
        if (_applicationFactory == null)
        {
            _applicationFactory = new NoxTestApplicationFactory(testOutput, this, enableMessagingTests, environment);
        }

        return _applicationFactory;
    }

    public INoxDatabaseProvider GetDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurations,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider noxClientAssemblyProvider)
    {        
        return DbProviderKind switch
        {
            DatabaseServerProvider.Postgres => new PostgreSqlTestProvider("Host=localhost; Database=clientapitests; Username=dev; Password=12345", configurations, noxSolutionCodeGeneratorState, noxClientAssemblyProvider),
            DatabaseServerProvider.SqlServer => new MsSqlTestProvider("Data Source=localhost;TrustServerCertificate=true;Initial Catalog=clientapitests;User ID=sa;password=Developer*123;", configurations, noxSolutionCodeGeneratorState, noxClientAssemblyProvider),
            _ => throw new NotImplementedException($"{DbProviderKind} is not suported"),
        };
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;

    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public DatabaseServerProvider GetDatabaseServerProvider() => DbProviderKind;
}