// generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore.Extensions;
using System.Reflection;

namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : DbContext
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SampleWebAppDbContext(
        DbContextOptions<SampleWebAppDbContext> options
        ) : base(options) { }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
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

// https://www.svrz.com/unable-to-resolve-service-for-type-microsoft-entityframeworkcore-storage-typemappingsourcedependencies/
public partial class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddEntityFrameworkMySQL();
        new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
            .TryAddCoreServices();
    }
}
