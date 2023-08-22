// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using ClientApi.Application.Dto;

namespace ClientApi.Presentation.Api.OData;

public class ODataDbContext : DbContext
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
        public ODataDbContext(
            DbContextOptions<ODataDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
        }
        
        public DbSet<ClientDatabaseNumberDto> ClientDatabaseNumbers { get; set; } = null!;
        
        public DbSet<ClientNuidDto> ClientNuids { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
            {
                _dbProvider.ConfigureDbContext(optionsBuilder, "ClientApi", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
            }
        }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                var type = typeof(ClientDatabaseNumberDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
                builder.OwnsMany(typeof(OwnedEntityDto), "OwnedEntities", owned =>
                    {
                         
                        owned.WithOwner().HasForeignKey("ClientDatabaseNumberId");
                        owned.HasKey("Id");
                        owned.ToTable("OwnedEntity");
                        owned.Property("Id").ValueGeneratedOnAdd();
                    }
                );
            }
            {
                var type = typeof(ClientNuidDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
            }
        }
    }
