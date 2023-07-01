// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Generator.Test.DatabaseTests.Model;
using System.Reflection;

namespace Nox.Generator.Test.DatabaseTests;

public partial class SampleWebAppDbContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleWebAppDbContext(
        DbContextOptions<SampleWebAppDbContext> options
        ) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public DbSet<Country> Countries { get; set; }

    public static void RegisterDbContext(IServiceCollection services)
    {
        services.AddDbContext<SampleWebAppDbContext>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configurations = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(configurations);

        base.OnModelCreating(modelBuilder);
    }
}
