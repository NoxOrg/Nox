using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Monitoring;
using Nox.Solution;

namespace Nox;

public interface INoxDataSeeder
{
    void Seed();
}

public static class MiddlewareExtension
{
    public static void UseNox(this IApplicationBuilder builder)
    {
        NoxSolution noxSolution = builder.ApplicationServices.GetRequiredService<NoxSolution>();
        builder.UseMonitoring(noxSolution);
    }

    public static void UseNoxSeedData(this IApplicationBuilder builder)
    {
        var dataSeeders = builder.ApplicationServices.GetServices<INoxDataSeeder>();
        foreach (var dataSeeder in dataSeeders)
        {
            dataSeeder.Seed();
        }
    }
}