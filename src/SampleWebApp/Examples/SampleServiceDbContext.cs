// generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using SampleWebApp.Domain;
using System.Reflection;

namespace SampleWebApp.Examples;

public partial class SampleServiceDbContext : DbContext
{

    public DbSet<Country> Countries;

    public DbSet<Currency> Currencies;

    //TODO Solve Composite Keys for Entities, that do not have an Id
    //public DbSet<CurrencyCashBalance> CurrencyCashBalances;

    // ...

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleServiceDbContext(
        DbContextOptions<SampleServiceDbContext> options
        ) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public static void RegisterDbContext(IServiceCollection services)
    {
        services.AddDbContext<SampleServiceDbContext>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configurations = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(configurations);

        base.OnModelCreating(modelBuilder);
    }
}

