// Generated

#nullable enable

using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using SampleWebApp.Domain;

namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public SampleWebAppDbContext(
            DbContextOptions<SampleWebAppDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
        }

    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Currency> Currencies { get; set; } = null!;

    public DbSet<Store> Stores { get; set; } = null!;

    public DbSet<StoreSecurityPasswords> StoreSecurityPasswords { get; set; } = null!;

    public DbSet<AllNoxType> AllNoxTypes { get; set; } = null!;

    public DbSet<CurrencyCashBalance> CurrencyCashBalances { get; set; } = null!;

    public DbSet<CountryLocalNames> CountryLocalNames { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "SampleWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
            {
                Console.WriteLine($"SampleWebAppDbContext Configure database for Entity {entity.Name}");

                // Ignore owned entities configuration as they are configured inside entity constructor
                if (codeGeneratorState.Solution.IsOwnedEntity(entity))
                {
                    continue;
                }

                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, new EntityBuilderAdapter(modelBuilder.Entity(type)), entity, codeGeneratorState.GetEntityType);
                }
            }
        }
    }
}