// generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SampleService.Domain;

namespace SampleService.Infrastructure.Persistence;

public partial class SampleServiceDbContext_Sample : DbContext
{

    public DbSet<Country> Countries;

    public DbSet<Currency> Currencies;

    public DbSet<CurrencyCashBalance> CurrencyCashBalances;

    // ...

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleServiceDbContext_Sample(
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

