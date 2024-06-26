using AutoFixture;
using ClientApi.Tests.Tests.Models;
using FluentAssertions;
using MassTransit.Testing;

using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit.Abstractions;

using Nox.Application.Dto;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Tests;

#region DEBUG
/// <summary>
/// Test againg a DatabaseInstance, use it for development/troubleshooting
/// </summary>
public abstract class NoxWebApiTestDbInstanceBase : NoxWebApiTestBase, IClassFixture<TestDatabaseInstanceService>
{
    protected NoxWebApiTestDbInstanceBase(ITestOutputHelper testOutput, ITestDatabaseService testDatabaseService, bool enableMessagingTests = false, string? environment = null) : base(testOutput, testDatabaseService, enableMessagingTests, environment)
    {
    }
}
#endregion
public abstract class NoxWebApiTestBase : IClassFixture<TestDatabaseContainerService>
{
    protected readonly Fixture _fixture = new Fixture();
    private readonly NoxAppClient _noxAppClient;

    /// <summary>
    /// TODO  enableMessagingTests is causing the GitHub CI to hang...
    /// </summary>
    protected NoxWebApiTestBase(
        ITestOutputHelper testOutput,
        ITestDatabaseService testDatabaseService,
        bool enableMessagingTests = false,
        string? environment = null)
    {
        _noxAppClient = testDatabaseService
            .GetNoxClient(testOutput, enableMessagingTests, environment);
        _noxAppClient.ResetDataContext();
    }

    protected ITestHarness MassTransitTestHarness => _noxAppClient.GetTestHarness();

    public HttpClient CreateHttpClient()
    {
        return _noxAppClient.CreateClient();
    }

    /// <summary>
    ///  Get collection result from Odata End Point
    /// </summary>
    public async Task<TResult?> GetODataCollectionResponseAsync<TResult>(string requestUrl, Dictionary<string, IEnumerable<string>>? headers = null)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new());

        return await httpClient.GetODataCollectionResponseAsync<TResult>(requestUrl);
    }
    /// <summary>
    ///  Get collection result from a non Odata EndPoint
    /// </summary>
    public async Task<TResult?> GetResponseAsync<TResult>(string requestUrl, Dictionary<string, IEnumerable<string>>? headers = null)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new());

        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var data = DeserializeResponse<TResult>(content);

        return data;
    }

    /// <summary>
    ///  Get single result from Odata End Point
    ///  Asserts is a valid Odata Response
    /// </summary>
    public async Task<TResult?> GetODataSimpleResponseAsync<TResult>(string requestUrl, Dictionary<string, IEnumerable<string>>? headers = null)
    {
        using var httpClient = CreateHttpClient();

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
        using var httpClient = CreateHttpClient();
        var result = await httpClient.GetAsync(requestUrl);

        return result;
    }

    public async Task<HttpResponseMessage> PostAsync(string requestUrl)
    {
        using var httpClient = CreateHttpClient();

        var result = await httpClient.PostAsync(requestUrl, null);
        result.EnsureSuccessStatusCode();

        return result;
    }

    public async Task<HttpResponseMessage> PostAsync<TValue>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>>? headers = null)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new());

        var result = await httpClient.PostAsJsonAsync(requestUrl, data);

        return result;
    }

    public async Task<TResult?> PostAsync<TValue, TResult>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>> headers)
    {
        using var httpClient = CreateHttpClient();

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

    protected async Task<HttpResponseMessage?> PutAsync<TValue>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>>? headers, bool throwOnError = true)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new Dictionary<string, IEnumerable<string>>());

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    protected async Task<HttpResponseMessage?> PutAsync<TValue>(string requestUrl, TValue data, bool throwOnError = true)
    {
        return await PutAsync<TValue>(requestUrl, data, new(), throwOnError);
    }

    protected async Task<TResult?> PutAsync<TValue, TResult>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>>? headers, bool throwOnError = true)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new Dictionary<string, IEnumerable<string>>());

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

    public async Task<HttpResponseMessage?> PutManyAsync<TValue>(string requestUrl, TValue[] data, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers);

        var collection = new EntityDtoCollection<TValue> { Values = data };

        var message = await httpClient.PutAsJsonAsync(requestUrl, collection);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    public async Task<TResult[]> PutManyAsync<TValue, TResult>(string requestUrl, TValue[] data, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new());

        var collection = new EntityDtoCollection<TValue> { Values = data };

        var message = await httpClient.PutAsJsonAsync(requestUrl, collection);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        var content = await message.Content.ReadAsStringAsync();

        var result = DeserializeResponse<ODataCollectionDto<TResult[]>>(content);

        return result!.Value;
    }

    public async Task<HttpResponseMessage?> PatchAsync<TValue>(string requestUrl, TValue delta, Dictionary<string, IEnumerable<string>> headers, bool throwOnError = true, Guid? etag = null)
        where TValue : class
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new Dictionary<string, IEnumerable<string>>());

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

    protected async Task<TResult?> PatchAsync<TValue, TResult>(string requestUrl, TValue delta, Dictionary<string, IEnumerable<string>>? headers)
        where TValue : class
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new Dictionary<string, IEnumerable<string>>());

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

    public async Task<HttpResponseMessage?> DeleteAsync(string requestUrl, Dictionary<string, IEnumerable<string>>? headers, bool throwOnError = true)
    {
        using var httpClient = CreateHttpClient();

        AddHeaders(httpClient, headers ?? new Dictionary<string, IEnumerable<string>>());

        var message = await httpClient.DeleteAsync(requestUrl);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    public async Task<HttpResponseMessage?> DeleteAsync(string requestUrl, bool throwOnError = true)
    {
        return await DeleteAsync(requestUrl, new(), throwOnError);
    }

    public Dictionary<string, IEnumerable<string>> CreateEtagHeader(Guid etag)
        => new()
        {
                { "If-Match",new [] { etag.ToString() } }
        };

    public Dictionary<string, IEnumerable<string>> CreateAcceptLanguageHeader(params string[] language)
        => new()
        {
            { "Accept-Language", language }
        };

    public Dictionary<string, IEnumerable<string>> CreateHeaders(params Dictionary<string, IEnumerable<string>>[] headers)
    {
        var result = new Dictionary<string, IEnumerable<string>>();

        foreach (var header in headers)
        {
            foreach (var item in header)
            {
                result.Add(item.Key, item.Value);
            }
        }

        return result;
    }

    private static void AddHeaders(HttpClient httpClient, Dictionary<string, IEnumerable<string>> headers)
    {
        foreach (var header in headers)
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
        }
    }

    protected TResult? DeserializeResponse<TResult>(string response)
    {
        return JsonSerializer.Deserialize<TResult>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } });
    }

    private void EnsureOdataSingleResponse(string content)
    {
        var oDataResponse = DeserializeResponse<ODataSingleDto>(content);
        oDataResponse.Should().NotBeNull();
        oDataResponse!.Context.Should().NotBeNullOrEmpty();
    }

    protected TResult? GetEntityByFilter<TResult>(Func<TResult, bool> filter) where TResult : class
    {
        var ctx = GetDbContext();
        var entity = ctx.Set<TResult>().FirstOrDefault(filter);
        return entity;
    }

    protected AppDbContext GetDbContext() => _noxAppClient.GetDbContext();
}