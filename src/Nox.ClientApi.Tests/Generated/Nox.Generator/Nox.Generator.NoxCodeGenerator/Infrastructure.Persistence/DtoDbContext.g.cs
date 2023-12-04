// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Infrastructure.Persistence;

using ClientApi.Application.Dto;
using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Infrastructure.Persistence;

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

    private readonly IEnumerable<IInterceptor> _interceptors;

    public DtoDbContext(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
        NoxCodeGenConventions codeGeneratorState,
        IEnumerable<IInterceptor> interceptors) 
        : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
        _codeGenConventions = codeGeneratorState;
        _interceptors = interceptors;
    }

    
        public virtual DbSet<CountryDto> Countries { get; set; } = null!;
        public virtual DbSet<RatingProgramDto> RatingPrograms { get; set; } = null!;
        public virtual DbSet<CountryQualityOfLifeIndexDto> CountryQualityOfLifeIndices { get; set; } = null!;
        public virtual DbSet<StoreDto> Stores { get; set; } = null!;
        public virtual DbSet<WorkplaceDto> Workplaces { get; set; } = null!;
        public virtual DbSet<StoreOwnerDto> StoreOwners { get; set; } = null!;
        public virtual DbSet<StoreLicenseDto> StoreLicenses { get; set; } = null!;
        public virtual DbSet<CurrencyDto> Currencies { get; set; } = null!;
        public virtual DbSet<TenantDto> Tenants { get; set; } = null!;
    public virtual DbSet<WorkplaceLocalizedDto> WorkplacesLocalized { get; set; } = null!;
    public virtual DbSet<TenantBrandLocalizedDto> TenantBrandsLocalized { get; set; } = null!;
    public virtual DbSet<TenantContactLocalizedDto> TenantContactsLocalized { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.CountryContinentDto> CountriesContinents { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.CountryContinentLocalizedDto> CountriesContinentsLocalized { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.StoreStatusDto> StoresStatuses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "ClientApi", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
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
        modelBuilder.Entity<CountryDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<StoreDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<StoreOwnerDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<StoreLicenseDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CurrencyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    }
}