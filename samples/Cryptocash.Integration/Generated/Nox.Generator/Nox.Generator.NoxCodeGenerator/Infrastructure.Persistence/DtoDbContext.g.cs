﻿// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Infrastructure;
using Nox.Infrastructure.Persistence;
using CryptocashIntegration.Application.Dto;
using DtoNameSpace = CryptocashIntegration.Application.Dto;

namespace CryptocashIntegration.Infrastructure.Persistence;

public partial class DtoDbContext : DtoDbContextBase
{
    public DtoDbContext(
      DbContextOptions<DtoDbContext> options,
      NoxSolution noxSolution,
      INoxDatabaseProvider databaseProvider,
      INoxClientAssemblyProvider clientAssemblyProvider,
      INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
      NoxCodeGenConventions codeGenConventions,
      IEnumerable<IInterceptor> interceptors)
      : base(
          options,
          noxSolution,
          databaseProvider,
          clientAssemblyProvider,
          noxDtoDatabaseConfigurator,
          codeGenConventions,
          interceptors)
    { }
}
public abstract partial class DtoDbContextBase : DbContext, Nox.Application.Repositories.IReadOnlyRepository
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

    private readonly IEnumerable<IInterceptor> _interceptors;

    public DtoDbContextBase(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
        NoxCodeGenConventions codeGenConventions,
        IEnumerable<IInterceptor> interceptors) 
        : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
        _codeGenConventions = codeGenConventions;
        _interceptors = interceptors;
    }

    
        public virtual DbSet<CountryQueryToTableDto> CountryQueryToTables { get; set; } = null!;
        public virtual DbSet<CountryJsonToTableDto> CountryJsonToTables { get; set; } = null!;
        public virtual DbSet<CountryProcToTableDto> CountryProcToTables { get; set; } = null!;

    public IQueryable<T> Query<T>() where T : class
    {
        return this.Set<T>().AsNoTracking();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder, 
                "CryptocashIntegration",
                _noxSolution.Infrastructure!.Persistence.DatabaseServer,
                _clientAssemblyProvider.DtoAssembly.GetName().Name);
            optionsBuilder.AddInterceptors(_interceptors);
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

                var type = _clientAssemblyProvider.GetEntityDtoType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                    ?? throw new TypeNotFoundException(dtoName);

                _noxDtoDatabaseConfigurator.ConfigureDto(modelBuilder.Entity(type).ToTable(entity.Persistence.TableName), entity, _clientAssemblyProvider.DtoAssembly);

                if (entity.IsLocalized)
                {
                    dtoName = NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name);
                    
                    type = _clientAssemblyProvider.GetEntityDtoType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                        ?? throw new TypeNotFoundException(dtoName);

                    _noxDtoDatabaseConfigurator.ConfigureLocalizedDto(modelBuilder.Entity(type!), entity);
                }
            }
        }
    }

private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
    }
}