using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.vNext;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Examples;

public class SampleWebAppDbContextExample : DbContext
{
    private NoxSolution _noxSolution { get; set; }
    private INoxDatabaseConfigurator _databaseConfigurator { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleWebAppDbContextExample(
        DbContextOptions<SampleWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseConfigurator databaseConfigurator
    ) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _noxSolution = noxSolution;
        _databaseConfigurator = databaseConfigurator;
    }

    public DbSet<Country> Countries;

    public DbSet<Currency> Currencies;

    public DbSet<Store> Stores;

    public DbSet<CountryLocalNames> CountryLocalNames;

    public static void RegisterDbContext(IServiceCollection services)
    {
        services.AddDbContext<SampleWebAppDbContext>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_noxSolution.Domain != null)
        {
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = Type.GetType("SampleWebApp.Domain." + entity.Name);

                if (type != null)
                {
                    _databaseConfigurator.ConfigureEntity(modelBuilder.Entity(type), entity);
                }
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}