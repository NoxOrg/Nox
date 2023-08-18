using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization;

public class NoxLocalizationDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    private const string LocalizationSchema = "l10n";

    private readonly INoxDatabaseProvider? _databaseProvider;

    private readonly INoxClientAssemblyProvider? _clientAssemblyProvider;

    // Schema: 'i10n'
    public DbSet<Translation> Translations { get; set; } = default!;

    //This constructor is used at design time for migrations. It remains internal so that derived applications are forced to user the public constructor
    internal NoxLocalizationDbContext(DbContextOptions<NoxLocalizationDbContext> options): base(options)
    {
        
    }
    
    //This is the runtime constructor
    public NoxLocalizationDbContext(
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider? clientAssemblyProvider = null
    ) 
    {
        _databaseProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
    } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (NoxSolutionBuilder.Instance != null)
        {
            var appName = NoxSolutionBuilder.Instance.Name;
    
            var dbServer = NoxSolutionBuilder.Instance.Infrastructure?.Persistence.DatabaseServer;
    
            if(dbServer is not null)
            {
                _databaseProvider!.ConfigureDbContext(optionsBuilder, appName, dbServer);
            }
        }
        base.OnConfiguring(optionsBuilder);
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