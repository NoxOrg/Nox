using Microsoft.Extensions.DependencyInjection;
using Nox.Secrets.Abstractions;
using Nox.Solution.Constants;
using File = System.IO.File;

namespace Nox.Secrets.Tests;

public class CacheTests
{
    [Fact]
    public void Can_Save_and_retrieve_a_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();
        var provider = services.BuildServiceProvider();
        var store = provider.GetRequiredService<IPersistedSecretStore>();
        var key = "my-secret";
        var secret = "This is no secret!";
        store.Save(key, secret);
        var path = Path.Combine(WellKnownPaths.SecretsCachePath, $".{key}");
        Assert.True(File.Exists(path));
        var loaded = store.Load(key, new TimeSpan(0, 0, 10));
        Assert.Equal(loaded, secret);
    }
    
    [Fact]
    public void Must_not_retrieve_an_expired_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();
        var provider = services.BuildServiceProvider();
        var store = provider.GetRequiredService<IPersistedSecretStore>();
        var key = "my-secret";
        var secret = "This is no secret!";
        store.Save(key, secret);
        var path = Path.Combine(WellKnownPaths.SecretsCachePath, $".{key}");
        Assert.True(File.Exists(path));
        Thread.Sleep(1000);
        var loaded = store.Load(key, new TimeSpan(0, 0, 1));
        Assert.Null(loaded);
    }
}