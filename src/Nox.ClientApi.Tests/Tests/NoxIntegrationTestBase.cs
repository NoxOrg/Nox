using Newtonsoft.Json;

using System.Net.Http.Headers;

namespace Nox.ClientApi.Tests;

public class ODataFixture
{
    private readonly NoxTestApplicationFactory<StartupFixture> _appFactory;

    public ODataFixture(NoxTestApplicationFactory<StartupFixture> appFactory)
    {
        _appFactory = appFactory;
    }

    public async Task<TResult?> GetAsync<TResult>(string requestUrl)
    {
        using var httpClient = _appFactory.CreateClient();

        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
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

        var result = await message.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    public async Task<HttpResponseMessage?> PutAsync<TValue>(string requestUrl, TValue data, Dictionary<string, IEnumerable<string>>? headers = null, bool throwOnError = true)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers);

        var message = await httpClient.PutAsJsonAsync(requestUrl, data);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    public async Task PatchAsync<TValue>(string requestUrl, TValue delta, Dictionary<string, IEnumerable<string>>? headers = null)
        where TValue : class
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers);

        var request = await httpClient.PatchAsJsonAsync(requestUrl, delta);
        request.EnsureSuccessStatusCode();
    }

    public async Task<HttpResponseMessage?> DeleteAsync(string requestUrl, Dictionary<string, IEnumerable<string>>? headers = null, bool throwOnError = true)
    {
        using var httpClient = _appFactory.CreateClient();

        AddHeaders(httpClient, headers);

        var message = await httpClient.DeleteAsync(requestUrl);

        if (throwOnError)
            message.EnsureSuccessStatusCode();

        return message;
    }

    public Dictionary<string, IEnumerable<string>>? CreateEtagHeader(System.Guid? etag)
        => new()
        {
                { "If-Match", new List<string> { $"\"{etag}\"" } }
        };

    private static void AddHeaders(HttpClient httpClient, Dictionary<string, IEnumerable<string>>? headers)
    {
        if (headers != null)
        {
            foreach (var header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}