// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Infrastructure.Persistence;
using CryptocashIntegration.Application.Dto;
using DtoNameSpace = CryptocashIntegration.Application.Dto;

namespace CryptocashIntegration.Infrastructure.Persistence;

internal class DtoDbContext : DbContext
{
    /// <summary>
    /// The Nox solution configuration.
    /// </summary>
    protected readonly NoxSolution _noxSolution;

    /// <summary>
    /// The database provider.
    /// </summary>
    protected readonly INoxDatabaseProvider _dbProvider;

    protected readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    protected readonly INoxDtoDatabaseConfigurator _noxDtoDatabaseConfigurator;
    private readonly NoxCodeGenConventions _codeGenConventions;

    public DtoDbContext(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
        NoxCodeGenConventions codeGeneratorState
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
        _codeGenConventions = codeGeneratorState;
    }
    
        public virtual DbSet<CountryQueryToTableDto> CountryQueryToTables { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "CryptocashIntegration", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureAuditable(modelBuilder);

        if (_noxSolution.Domain != null)
        {            
            foreach (var entity in _codeGenConventions.Solution.Domain!.Entities)
            {
                var dtoName = entity.Name + "Dto";

                var type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                    ?? throw new TypeNotFoundException(dtoName);

                _noxDtoDatabaseConfigurator.ConfigureDto(modelBuilder.Entity(type).ToTable(entity.Persistence.TableName), entity);

                if (entity.IsLocalized)
                {
                    dtoName = NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name);
                    
                    type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                        ?? throw new TypeNotFoundException(dtoName);

                    _noxDtoDatabaseConfigurator.ConfigureLocalizedDto(modelBuilder.Entity(type!), entity);
                }
            }
        }
    }

private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountryQueryToTableDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    }
}