using AutoFixture;

namespace Nox.ClientApi.Tests;

public abstract class NoxIntegrationTestBase : IClassFixture<NoxTestApplicationFactory<StartupFixture>>
{
    private readonly NoxTestApplicationFactory<StartupFixture> _appFactory;

    protected NoxIntegrationTestBase(NoxTestApplicationFactory<StartupFixture> appFactory)
    {
        _appFactory = appFactory;
    }

    protected async Task<TResult?> GetAsync<TResult>(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var data = await result.Content.ReadFromJsonAsync<TResult>();

        return data;
    }

    protected async Task<HttpResponseMessage> GetAsync(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();
        var result = await httpClient.GetAsync(requestUrl);

        return result;
    }

    protected async Task<HttpResponseMessage> PostAsync<TValue>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.PostAsJsonAsync(requestUrl, data);

        return result;
    }

    protected async Task<TResult?> PostAsync<TValue, TResult>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.PostAsJsonAsync(requestUrl, data);
        message.EnsureSuccessStatusCode();

        var result = await message.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    protected async Task PutAsync<TValue>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);
        message.EnsureSuccessStatusCode();
    }

    protected async Task PatchAsync<TValue>(string requestUrl, TValue delta)
        where TValue : class
    {
        using var httpClient = _appFactory.CreateClient();

        var request = await httpClient.PatchAsJsonAsync(requestUrl, delta);
        request.EnsureSuccessStatusCode();
    }

    protected async Task DeleteAsync(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.DeleteAsync(requestUrl);
        message.EnsureSuccessStatusCode();
    }
}