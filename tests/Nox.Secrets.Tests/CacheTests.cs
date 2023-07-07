using Microsoft.Extensions.DependencyInjection;

namespace Nox.Secrets.Tests;

public class CacheTests
{
    [Fact]
    public async Task Can_Save_and_retrieve_a_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();
        var provider = services.BuildServiceProvider();
        var store = provider.GetRequiredService<IPersistedSecretStore>();
        var key = "my-secret";
        var secret = "This is no secret!";
        await store.SaveAsync(key, secret);
        var nuid = new Nuid(key).ToHex();
        var path = Path.Combine(WellKnownPaths.SecretsCachePath, $".{nuid}");
        Assert.True(File.Exists(path));
        var loaded = await store.LoadAsync(key, new TimeSpan(0, 0, 1));
        Assert.Equal(loaded, secret);
    }
    
    [Fact]
    public async Task Must_not_retrieve_an_expired_secret()
    {
        var services = new ServiceCollection();
        services.AddPersistedSecretStore();
        var provider = services.BuildServiceProvider();
        var store = provider.GetRequiredService<IPersistedSecretStore>();
        var key = "my-secret";
        var secret = "This is no secret!";
        await store.SaveAsync(key, secret);
        var nuid = new Nuid(key).ToHex();
        var path = Path.Combine(WellKnownPaths.SecretsCachePath, $".{nuid}");
        Assert.True(File.Exists(path));
        Thread.Sleep(1000);
        var loaded = await store.LoadAsync(key, new TimeSpan(0, 0, 1));
        Assert.Null(loaded);
    }
}