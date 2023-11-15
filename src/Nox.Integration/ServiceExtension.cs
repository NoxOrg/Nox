using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Services;
using Nox.Solution;

namespace Nox.Integration;

public static class ServiceExtension
{
    public static IServiceCollection AddNoxIntegrations(this IServiceCollection services, Solution.NoxSolution solution)
    {
        if (solution.Application is { Integrations: not null } && solution.Application.Integrations.Any())
        {
            services.TryAddSingleton<INoxIntegrationContext>(p =>
            {
                var loggerFactory = p.GetRequiredService<LoggerFactory>();
                var context = new NoxIntegrationContext(loggerFactory, solution);
                context.Initialize();
                return context;
            });
        }
        
        return services;
    }
}