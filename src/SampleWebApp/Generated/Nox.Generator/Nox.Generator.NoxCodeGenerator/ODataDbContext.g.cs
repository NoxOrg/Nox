// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;

namespace SampleWebApp.Presentation.Api.OData;

public class ODataDbContext : DbContext
{
    
    public ODataDbContext(
        DbContextOptions<ODataDbContext> options
        ) : base(options)
    {
    }
    
    public DbSet<Country> Countries {get; set;} = null!;
    
    public DbSet<Currency> Currencies {get; set;} = null!;
    
    public DbSet<Store> Stores {get; set;} = null!;
    
    public DbSet<CountryLocalNames> CountryLocalNames {get; set;} = null!;
    
}
