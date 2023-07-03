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

    public static IServiceCollection AddNoxSolution(this IServiceCollection services)
    {
        if (_solution == null) CreateSolution();
        services.AddSingleton(_solution!);
        return services;
    } 
    
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        var solution = new NoxSolutionBuilder()
            .Build();

        return services;
    }

    private static void CreateSolution()
    {
        _solution = new NoxSolutionBuilder()
            .Build();
    }

}