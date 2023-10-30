using AutoFixture;
using ClientApi.Tests.Tests.Models;
using FluentAssertions;
using MassTransit.Testing;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit.Abstractions;

namespace ClientApi.Tests;

public abstract class NoxWebApiTestBase : IClassFixture<TestDatabaseContainerService>
//For development Purposes
//public abstract class NoxWebApiTestBase : IClassFixture<TestDatabaseInstanceService>
{
    protected readonly Fixture _fixture = new Fixture();
    private readonly NoxTestApplicationFactory _appFactory;

    /// <summary>
    /// TODO  enableMessagingTests is causing the GitHub CI to hang...
    /// </summary>
    protected NoxWebApiTestBase(
        ITestOutputHelper testOutput,      
        ITestDatabaseService testDatabaseService,
        bool enableMessagingTests = false,
        string? environment = null)
    {
        _appFactory = testDatabaseService.GetTestApplicationFactory(testOutput, enableMessagingTests, environment);
        _appFactory.ResetDataContext();
    }

    protected ITestHarness MassTransitTestHarness => _appFactory.GetTestHarness();

    /// <summary>
    ///  Get collection result from Odata End Point
    /// </summary>
    public async Task<TResult?> GetODataCollectionResponseAsync<TResult>(string requestUrl, Dictionary<string, IEnumerable<string>>? headers = null)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var data = DeserializeResponse<ODataCollectionResponse<TResult>>(content);

        return data!.Value;
    }

    /// <summary>
    ///  Get single result from Odata End Point
    ///  Asserts is a valid Odata Response
    /// </summary>
    public async Task<TResult?> GetODataSimpleResponseAsync<TResult>(string requestUrl, Dictionary<string, IEnumerable<string>>? headers = null)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var result = await httpClient.GetAsync(requestUrl);

        result.EnsureSuccessStatusCode();

        result.Headers.Single(h => h.Key == "OData-Version").Value.First().Should().Be("4.0");

        var content = await result.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var data = DeserializeResponse<TResult>(content);

        return data;
    }

    public async Task<HttpResponseMessage> GetAsync(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();
        var result = await httpClient.GetAsync(requestUrl);

        return result;
    }

    public async Task<HttpResponseMessage> PostAsync(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.PostAsync(requestUrl, null);
        result.EnsureSuccessStatusCode();

        return result;
    }

    public async Task<HttpResponseMessage> PostAsync<TValue>(string requestUrl, TValue data)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.PostAsJsonAsync(requestUrl, data);

        return result;
    }

    public async Task<TResult?> PostAsync<TValue, TResult>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>> headers)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var message = await httpClient.PostAsJsonAsync(requestUrl, data);
        message.EnsureSuccessStatusCode();

        var content = await message.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var result = DeserializeResponse<TResult>(content);

        return result;
    }

    public async Task<TResult?> PostAsync<TValue, TResult>(string requestUrl, TValue data)
    {
        return await PostAsync<TValue, TResult>(requestUrl, data, new());
    }

    public async Task<HttpResponseMessage?> PutAsync<TValue>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers);

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    public async Task<HttpResponseMessage?> PutAsync<TValue>(string requestUrl, TValue data, bool throwOnError = true)
    {
        return await PutAsync<TValue>(requestUrl, data, new(), throwOnError);
    }

    public async Task<TResult?> PutAsync<TValue, TResult>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        var content = await message.Content.ReadAsStringAsync();

        if (throwOnError)
            EnsureOdataSingleResponse(content);

        var result = DeserializeResponse<TResult>(content);

        return result;
    }

    public async Task<TResult?> PutAsync<TValue, TResult>(string requestUrl, TValue data)
    {
        return await PutAsync<TValue, TResult>(requestUrl, data, new());
    }

    public async Task<HttpResponseMessage?> PatchAsync<TValue>(string requestUrl, TValue delta, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true)
        where TValue : class
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var responseMessage = await httpClient.PatchAsJsonAsync(requestUrl, delta);

        if (throwOnError)
            responseMessage.EnsureSuccessStatusCode();

        return responseMessage;
    }

    public async Task PatchAsync<TValue>(string requestUrl, TValue delta)
        where TValue : class
    {
        await PatchAsync<TValue>(requestUrl, delta, new());
    }

    public async Task<TResult?> PatchAsync<TValue, TResult>(string requestUrl, TValue delta, Dictionary<string, IEnumerable<string>> headers)
        where TValue : class
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var opts = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        var request = await httpClient.PatchAsJsonAsync(requestUrl, delta, opts);
        request.EnsureSuccessStatusCode();

        var content = await request.Content.ReadAsStringAsync();
        EnsureOdataSingleResponse(content);

        var result = DeserializeResponse<TResult>(content);

        return result;
    }

    public async Task<TResult?> PatchAsync<TValue, TResult>(string requestUrl, TValue delta)
        where TValue : class
    {
        return await PatchAsync<TValue, TResult>(requestUrl, delta, new());
    }

    public async Task<HttpResponseMessage?> DeleteAsync(string requestUrl, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers ?? new());

        var message = await httpClient.DeleteAsync(requestUrl);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    public async Task<HttpResponseMessage?> DeleteAsync(string requestUrl, bool throwOnError = true)
    {
        return await DeleteAsync(requestUrl, new(), throwOnError);
    }

    public Dictionary<string, IEnumerable<string>> CreateEtagHeader(System.Guid? etag)
        => new()
        {
                { "If-Match", new List<string> { $"\"{etag}\"" } }
        };

    private static void AddHeaders(HttpClient httpClient, Dictionary<string, IEnumerable<string>> headers)
    {
        foreach (var header in headers)
        {
            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }

    private TResult? DeserializeResponse<TResult>(string response)
    {
        return JsonSerializer.Deserialize<TResult>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } });
    }

    private void EnsureOdataSingleResponse(string content)
    {
        var oDataResponse = DeserializeResponse<ODataSigleResponse>(content);
        oDataResponse.Should().NotBeNull();
        oDataResponse!.Context.Should().NotBeNullOrEmpty();
    }

    protected TResult? GetEntityByFilter<TResult>(Func<TResult, bool> filter) where TResult : class
    {
        var ctx = _appFactory.GetDbContext();
        var entity = ctx.Set<TResult>().Where(filter).FirstOrDefault();
        return entity;
    }
}