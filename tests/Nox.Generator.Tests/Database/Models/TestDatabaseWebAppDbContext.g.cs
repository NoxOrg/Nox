// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;
using System;
using Nox.Types.EntityFramework.Abstractions;
using TestDatabaseWebApp.Domain;

namespace TestDatabaseWebApp.Infrastructure.Persistence;

public partial class TestDatabaseWebAppDbContext : DbContext
{
    private NoxSolution _noxSolution { get; set; }
    private INoxDatabaseConfigurator _databaseConfigurator { get; set; }

    public TestDatabaseWebAppDbContext(
        DbContextOptions<TestDatabaseWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseConfigurator databaseConfigurator
        ) : base(options)
    {
        _noxSolution = noxSolution;
        _databaseConfigurator = databaseConfigurator;
    }

    public DbSet<TestEntity> TestEntities { get; set; } = null!;


    public static void RegisterDbContext(IServiceCollection services)
    {
        services.AddDbContext<TestDatabaseWebAppDbContext>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_noxSolution.Domain != null)
        {
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = Type.GetType("TestDatabaseWebApp.Domain." + entity.Name);

                if (type != null)
                {
                    _databaseConfigurator.ConfigureEntity(modelBuilder.Entity(type), entity);
                }
            }

        }

        base.OnModelCreating(modelBuilder);
    }
}

