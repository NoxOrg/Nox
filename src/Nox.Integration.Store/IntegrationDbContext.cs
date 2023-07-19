using Microsoft.EntityFrameworkCore;

namespace Nox.Integration.Store;

public class IntegrationDbContext: DbContext
{
    public DbSet<Integration>? Integrations { get; set; }
    public DbSet<MergeState>? MergeStates { get; set; }

    public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Integration>()
            .HasMany<MergeState>();
    }
}