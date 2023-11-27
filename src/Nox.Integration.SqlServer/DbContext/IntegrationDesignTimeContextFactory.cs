using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Nox.Integration.SqlServer;

public class IntegrationDesignTimeContextFactory: IDesignTimeDbContextFactory<NoxIntegrationDbContext>
{
    public NoxIntegrationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NoxIntegrationDbContext>();
        optionsBuilder.UseSqlServer("", options =>
        {
            options.MigrationsAssembly("Nox.Integration.SqlServer");
        });
        return new NoxIntegrationDbContext(optionsBuilder.Options);
    }
}