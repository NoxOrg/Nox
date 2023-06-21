// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using SampleService.Domain;
using System.Reflection;

namespace SampleService.Infrastructure.Persistence;

public partial class SampleServiceDbContext : DbContext
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleServiceDbContext(
        DbContextOptions<SampleServiceDbContext> options
        ) : base(options) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    public DbSet<Country> Countries;
    
    public DbSet<Currency> Currencies;
    
    public DbSet<CountryLocalNames> CountryLocalNames;
    
    public DbSet<CurrencyCashBalance> CurrencyCashBalances;
    
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

