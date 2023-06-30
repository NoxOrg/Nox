using System.Reflection;
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

    private static string GetExecutingDirectory()
    {
        var location = new Uri(Assembly.GetEntryAssembly()!.Location);
        return new FileInfo(location.AbsolutePath).Directory!.FullName;
    }
}