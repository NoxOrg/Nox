using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;

namespace Nox;

public static class ServiceExtensions
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        var solution = new NoxSolutionBuilder()
            .Build();
        
        return services;
    } 
}