using Microsoft.EntityFrameworkCore;
using Nox.Infrastructure;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Solution;

namespace Nox.Integration;

public class NoxIntegrationDbContext: DbContext
{
    private const string IntegrationSchema = "integration";
    private readonly NoxSolution? _solution;
    private readonly INoxIntegrationDatabaseProvider? _dbProvider;
    private readonly INoxClientAssemblyProvider? _clientAssemblyProvider;
    
    public DbSet<IntegrationMergeState>? MergeStates { get; set; }

    //This constructor is used at design time for migrations. It is internal so that derived applications are forced to user the public constructor
    internal NoxIntegrationDbContext(DbContextOptions<NoxIntegrationDbContext> options) : base(options)
    {
        
    }

    public NoxIntegrationDbContext(
        NoxSolution solution,
        INoxIntegrationDatabaseProvider dbProvider,
        INoxClientAssemblyProvider? clientAssemblyProvider)
    {
        _solution = solution;
        _dbProvider = dbProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_solution != null)
        {
            var appName = _solution.Name;

            var dbServer = _solution.Infrastructure.Persistence?.DatabaseServer;

            if(dbServer is not null)
            {
                switch (dbServer.Provider)
                {
                    case DatabaseServerProvider.SqlServer:
                        ;
                        break;
                        
                }
                _dbProvider!.ConfigureDbContext(optionsBuilder, appName, dbServer, _clientAssemblyProvider!.ClientAssembly.GetName().Name!);
            }
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IntegrationMergeState>().ToTable("IntegrationMergeStates", IntegrationSchema);
        modelBuilder.Entity<IntegrationMergeState>().HasKey(m => m.Id);
        modelBuilder.Entity<IntegrationMergeState>().HasAlternateKey(c => new { c.Integration, c.Property });
        base.OnModelCreating(modelBuilder);
    }
}

