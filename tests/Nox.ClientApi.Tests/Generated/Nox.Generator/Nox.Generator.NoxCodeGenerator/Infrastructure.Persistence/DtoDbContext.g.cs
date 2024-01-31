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

internal partial class DtoDbContext : DtoDbContextBase
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
internal abstract partial class DtoDbContextBase : DbContext, Nox.Application.Repositories.IReadOnlyRepository
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

    
        public virtual DbSet<CountryDto> Countries { get; set; } = null!;
        public virtual DbSet<RatingProgramDto> RatingPrograms { get; set; } = null!;
        public virtual DbSet<CountryQualityOfLifeIndexDto> CountryQualityOfLifeIndices { get; set; } = null!;
        public virtual DbSet<StoreDto> Stores { get; set; } = null!;
        public virtual DbSet<WorkplaceDto> Workplaces { get; set; } = null!;
        public virtual DbSet<StoreOwnerDto> StoreOwners { get; set; } = null!;
        public virtual DbSet<StoreLicenseDto> StoreLicenses { get; set; } = null!;
        public virtual DbSet<CurrencyDto> Currencies { get; set; } = null!;
        public virtual DbSet<TenantDto> Tenants { get; set; } = null!;
        public virtual DbSet<ClientDto> Clients { get; set; } = null!;
        public virtual DbSet<ReferenceNumberEntityDto> ReferenceNumberEntities { get; set; } = null!;
        public virtual DbSet<PersonDto> People { get; set; } = null!;
    public virtual DbSet<WorkplaceLocalizedDto> WorkplacesLocalized { get; set; } = null!;
    public virtual DbSet<TenantBrandLocalizedDto> TenantBrandsLocalized { get; set; } = null!;
    public virtual DbSet<TenantContactLocalizedDto> TenantContactsLocalized { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.CountryContinentDto> CountriesContinents { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.CountryContinentLocalizedDto> CountriesContinentsLocalized { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.StoreStatusDto> StoresStatuses { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.WorkplaceOwnershipDto> WorkplacesOwnerships { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.WorkplaceOwnershipLocalizedDto> WorkplacesOwnershipsLocalized { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.WorkplaceTypeDto> WorkplacesTypes { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.TenantStatusDto> TenantsStatuses { get; set; } = null!;

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
                "ClientApi",
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
        modelBuilder.Entity<CountryDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<StoreDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<WorkplaceDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<StoreOwnerDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<StoreLicenseDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CurrencyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<ClientDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<ReferenceNumberEntityDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<PersonDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    }
}