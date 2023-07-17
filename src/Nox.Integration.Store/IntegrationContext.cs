using Microsoft.EntityFrameworkCore;

namespace Nox.Integration.Store;

public class IntegrationContext: DbContext
{
    public DbSet<Integration>? Integrations { get; set; }
    public DbSet<Source>? Sources { get; set; }
    public DbSet<MergeState>? MergeStates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Integration>()
            .HasOne<Source>();
        modelBuilder.Entity<Source>()
            .HasOne<MergeState>();
    }
}