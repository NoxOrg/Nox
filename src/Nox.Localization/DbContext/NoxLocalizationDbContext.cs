using Microsoft.EntityFrameworkCore;
using Nox.Localization.Models;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Localization.DbContext;

public class NoxLocalizationDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    private const string LocalizationSchema = "l10n";

    private readonly NoxSolution _noxSolution;

    private readonly INoxDatabaseProvider _dbProvider;

    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    // Schema: 'i10n'
    public DbSet<Translation> Translations { get; set; } = default!;

    public NoxLocalizationDbContext(
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider
    ) 
    {
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxSolution = noxSolution;
    } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var appName = _noxSolution.Name;

        var dbServer = _noxSolution.Infrastructure?.Persistence.DatabaseServer;

        if(dbServer is not null)
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, appName, dbServer);
        }

        //optionsBuilder.MigrationsAssembly("ImportExportLocalization");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Schema 'dbo': Domain State

        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                // Ignore owned entities configuration as they are configured inside entity constructor
                if (_noxSolution.IsOwnedEntity(entity))
                {
                    continue;
                }

                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, new EntityBuilderAdapter(modelBuilder.Entity(type)), entity, _noxSolution, codeGeneratorState.GetEntityType);
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