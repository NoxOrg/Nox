using Microsoft.Extensions.DependencyInjection;
using Nox.Integration.Abstractions;
using Nox.IntegrationSource.File;
using Nox.Solution;

namespace Nox.Integration.Executor;

public static class ServiceExtension
{
    public static IServiceCollection AddIntegrationSourceFactory(this IServiceCollection services)
    {
        services.AddSingleton<Func<IEnumerable<ISource>>>(s => () => s.GetService<IEnumerable<ISource>>()!);
        services.AddSingleton<IIntegrationSourceFactory, IntegrationSourceFactory>(); 
        
        // if (solution.Application is { Integrations: not null } && solution.Application.Integrations.Any())
        // {
        //     
        //     
        //     // //Add csv sources
        //     // foreach (var integration in solution.Application.Integrations)
        //     // {
        //     //     var dataConnectionName = integration.Source!.DataConnectionName;
        //     //     var dataConnection = solution.Infrastructure!.Dependencies!.DataConnections!.First(dc => dc.Name.Equals(dataConnectionName, StringComparison.OrdinalIgnoreCase));
        //     //     switch (dataConnection.Provider)
        //     //     {
        //     //         case DataConnectionProvider.CsvFile:
        //     //             var csvSource = new CsvIntegrationSource(integration.Source, dataConnection);
        //     //             services.AddSingleton<ISource>(csvSource);
        //     //             break;
        //     //     } 
        //     //     
        //     // }
        //     
        //        
        // }
        
        return services;
    }
}