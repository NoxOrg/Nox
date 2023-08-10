using Microsoft.EntityFrameworkCore;
using Nox.Localization.Models;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Localization.DbContext;

public class NoxLocalizationDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    private const string LocalizationSchema = "l10n";

    private readonly INoxDatabaseProvider _dbProvider;

    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    // Schema: 'i10n'
    public DbSet<Translation> Translations { get; set; } = default!;

    public NoxLocalizationDbContext(
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider
    ) 
    {
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
    } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var appName = NoxSolutionBuilder.Instance!.Name;

        var dbServer = NoxSolutionBuilder.Instance.Infrastructure?.Persistence.DatabaseServer;

        if(dbServer is not null)
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, appName, dbServer);
        }

        //optionsBuilder.MigrationsAssembly("ImportExportLocalization");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Schema 'dbo': Domain State

        if (NoxSolutionBuilder.Instance!.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(NoxSolutionBuilder.Instance, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in NoxSolutionBuilder.Instance!.Domain.Entities)
            {
                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, NoxSolutionBuilder.Instance!.GetRelationshipsToCreate(codeGeneratorState.GetEntityType, entity));
                }
            }
        }

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
        base.OnModelCreating(builder);
    }
}