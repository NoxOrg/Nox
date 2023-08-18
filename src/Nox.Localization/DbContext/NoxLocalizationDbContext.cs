using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization;

public class NoxLocalizationDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    private const string LocalizationSchema = "l10n";

    private readonly INoxDatabaseProvider? _databaseProvider;
    private readonly NoxSolution _noxSolution;

    // Schema: 'i10n'
    public DbSet<Translation> Translations { get; set; } = default!;
    
    public NoxLocalizationDbContext(
        NoxSolution noxSolution,
        IEnumerable<INoxDatabaseProvider> databaseProviders
    )
    {
        _noxSolution = noxSolution;
        _databaseProvider = databaseProviders.Single(p => p.StoreType == NoxDataStoreType.EntityStore);
    } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var appName = _noxSolution.Name;

        var dbServer = _noxSolution.Infrastructure?.Persistence.DatabaseServer;
    
        if(dbServer is not null)
        {
            _databaseProvider!.ConfigureDbContext(optionsBuilder, appName, dbServer);
        }
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Schema 'dbo': Domain State
        //
        // if (NoxSolutionBuilder.Instance != null)
        // {
        //     if (NoxSolutionBuilder.Instance.Domain != null)
        //     {
        //         var codeGeneratorState = new NoxSolutionCodeGeneratorState(NoxSolutionBuilder.Instance, _clientAssemblyProvider!.ClientAssembly);
        //         foreach (var entity in NoxSolutionBuilder.Instance!.Domain.Entities)
        //         {
        //             var type = codeGeneratorState.GetEntityType(entity.Name);
        //             if (type != null)
        //             {
        //                 ((INoxDatabaseConfigurator)_databaseProvider!).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity,
        //                     NoxSolutionBuilder.Instance!.GetRelationshipsToCreate(codeGeneratorState.GetEntityType, entity));
        //             }
        //         }
        //     }
        // }
        
        // Schema 'l10n': Localization
        ConfigureLocalization(modelBuilder);

        // Schema 'jobs': Hangfire Jobs

        // Schema 'meta': MetaData

        // Schema 'etl': IntegrationState

        // Schema 'migrations': Migrations

        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureLocalization(ModelBuilder builder)
    {
        builder.Entity<Translation>().ToTable("Translations", LocalizationSchema);
        builder.Entity<Translation>().HasKey(m => m.Id);
        builder.Entity<Translation>().HasAlternateKey(c => new { c.Key, c.CultureCode, c.ResourceKey });
    }
}