// Generated

#nullable enable

using Nox;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using SampleWebApp.Domain;

using Nox.Localization;


namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public SampleWebAppDbContext(
            DbContextOptions<SampleWebAppDbContext> options,
            NoxSolution noxSolution,
            IEnumerable<INoxDatabaseProvider> databaseProviders,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProviders.Single(p => p.StoreType == NoxDataStoreType.EntityStore);
            _clientAssemblyProvider = clientAssemblyProvider;
        }


    public DbSet<Country> Countries { get; set; } = null!;



    // Schema: 'l10n'
    public DbSet<Translation> Translations { get; set; } = default!;


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

        ConfigureLocalization(modelBuilder); 

        
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                Console.WriteLine($"SampleWebAppDbContext Configure database for Entity {entity.Name}");
                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, _noxSolution.GetRelationshipsToCreate(codeGeneratorState.GetEntityType, entity));
                }
            }
        }
    }


    private void ConfigureLocalization(ModelBuilder builder)
    {
        builder.Entity<Translation>().ToTable("Translations", "l10n");
        builder.Entity<Translation>().HasKey(m => m.Id);
        builder.Entity<Translation>().HasAlternateKey(c => new { c.Key, c.CultureCode, c.ResourceKey });
    }

}