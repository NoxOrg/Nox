// Generated

#nullable enable

using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using CryptocashApi.Domain;

namespace CryptocashApi.Infrastructure.Persistence;

public partial class CryptocashApiDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public CryptocashApiDbContext(
            DbContextOptions<CryptocashApiDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
        }


    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "CryptocashApi", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                Console.WriteLine($"CryptocashApiDbContext Configure database for Entity {entity.Name}");
                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, _noxSolution.GetRelationshipsToCreate(codeGeneratorState.GetEntityType, entity));
                }
            }
        }
    }
}