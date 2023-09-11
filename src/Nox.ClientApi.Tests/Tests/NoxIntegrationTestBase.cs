using ClientApi.Tests.Tests.Models;
using FluentAssertions;
using Newtonsoft.Json;

namespace ClientApi.Tests;

public class ODataFixture
{
    private readonly NoxTestApplicationFactory<StartupFixture> _appFactory;

    public ODataFixture(NoxTestApplicationFactory<StartupFixture> appFactory)
    {
        _appFactory = appFactory;
    }

    /// <summary>
    ///  Get collection result from Odata End Point
    /// </summary>
    public async Task<TResult?> GetODataCollectionResponseAsync<TResult>(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<ODataCollectionResponse<TResult>>(content);

        return data!.Value;
    }

    /// <summary>
    ///  Get single result from Odata End Point
    ///  Asserts is a valid Odata Response
    /// </summary>
    public async Task<TResult?> GetODataSimpleResponseAsync<TResult>(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.GetAsync(requestUrl);

        result.EnsureSuccessStatusCode();

        result.Headers.Single(h => h.Key == "OData-Version").Value.First().Should().Be("4.0");

        var content = await result.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var data = JsonConvert.DeserializeObject<TResult>(content);

        return data;
    }

    public async Task<HttpResponseMessage> GetAsync(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();
        var result = await httpClient.GetAsync(requestUrl);
        
        return result;
    }

    public async Task<HttpResponseMessage> PostAsync<TValue>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.PostAsJsonAsync(requestUrl, data);

        return result;
    }

    public async Task<TResult?> PostAsync<TValue, TResult>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.PostAsJsonAsync(requestUrl, data);
        message.EnsureSuccessStatusCode();

        var content = await message.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var result = JsonConvert.DeserializeObject<TResult>(content);

        return result;
    }

    public async Task PutAsync<TValue>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);
        message.EnsureSuccessStatusCode();
    }

    public async Task<TResult?> PutAsync<TValue, TResult>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);
        message.EnsureSuccessStatusCode();

        var content = await message.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var result = JsonConvert.DeserializeObject<TResult>(content);

        return result;
    }

    public async Task PatchAsync<TValue>(string requestUrl, TValue delta)
        where TValue : class
    {
        using var httpClient = _appFactory.CreateClient();

        var request = await httpClient.PatchAsJsonAsync(requestUrl, delta);
        request.EnsureSuccessStatusCode();
    }

    public async Task<TResult?> PatchAsync<TValue, TResult>(string requestUrl, TValue delta)
    where TValue : class
    {
        using var httpClient = _appFactory.CreateClient();

        var request = await httpClient.PatchAsJsonAsync(requestUrl, delta);
        request.EnsureSuccessStatusCode();

        var content = await request.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var result = JsonConvert.DeserializeObject<TResult>(content);

        return result;
    }

    public async Task DeleteAsync(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var message = await httpClient.DeleteAsync(requestUrl);
        message.EnsureSuccessStatusCode();
    }

    private void EnsureOdataSingleResponse(string content)
    {
        var oDataResponse = JsonConvert.DeserializeObject<ODataSigleResponse>(content);
        oDataResponse.Should().NotBeNull();
        oDataResponse!.Context.Should().NotBeNullOrEmpty();
    }
}