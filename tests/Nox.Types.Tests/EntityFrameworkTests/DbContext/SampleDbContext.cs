using Microsoft.EntityFrameworkCore;

namespace Nox.Types.Tests.EntityFrameworkTests;

public class SampleDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleDbContext).Assembly);
    }
}