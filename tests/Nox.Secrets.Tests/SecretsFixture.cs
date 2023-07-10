using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public class SecretsFixture
{
    public IServiceProvider ServiceProvider { get; }

    public SecretsFixture()
    {
        var services = new ServiceCollection();
        services.AddSecretsResolver();
        ServiceProvider = services.BuildServiceProvider();
    }
   
}