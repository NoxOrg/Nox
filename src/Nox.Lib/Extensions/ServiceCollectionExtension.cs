using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;

namespace Nox;

public static class ServiceCollectionExtension
{
    private static NoxSolution? _solution;

    public static NoxSolution Solution
    {
        get
        {
            if (_solution == null) CreateSolution();
            return _solution!;
        }
    }
    
    public static IServiceCollection AddNoxLib(this IServiceCollection services)
    {
        services.AddSingleton(Solution);
        
        return services;
    }

    private static void CreateSolution()
    {
        _solution = new NoxSolutionBuilder()
            .Build();
    }

}