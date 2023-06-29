using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Abstractions.Infrastructure.Monitoring;
using Nox.PackageManager;
using Nox.Solution;

namespace Nox;

public static class ServiceExtensions
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        var solution = new NoxSolutionBuilder()
            .Build();

        var executionDirectory = GetExecutingDirectory();
        
#if DEBUG
        var pkgManager = new NoxPackageManager(executionDirectory, true);
#else 
        var pkgManager = new NoxPackageManager();
#endif
        
        pkgManager.DownloadPackage("Nox.Monitoring.ElasticApm");
        var assm = Assembly.LoadFrom(Path.Combine(executionDirectory, "Nox.Monitoring.ElasticApm.dll"));
        var monitor = assm.GetTypes().Where(t => !t.IsInterface && t.IsAssignableTo(typeof(INoxMonitor))).First();
        services.AddSingleton(typeof(INoxMonitor), monitor);
        
        return services;
    }

    private static string GetExecutingDirectory()
    {
        var location = new Uri(Assembly.GetEntryAssembly()!.Location);
        return new FileInfo(location.AbsolutePath).Directory!.FullName;
    }
}