using System.Text.Json.Serialization;
using System.Text.Json;
using Nox.Ui.Blazor.Lib.Models;
using System.Net.Http.Json;

namespace Nox.Ui.Blazor.Lib.Extensions;

public static class HttpClientExtension
{
    public static async Task<TResult?> GetODataCollectionResponseAsync<TResult>(this HttpClient httpClient, string requestUrl)
    {
        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var data = DeserializeResponse<ODataCollectionResponse<TResult>>(content);
        
        return data!.Value;
    }

    public static async Task<TResult?> GetODataSimpleResponseAsync<TResult>(this HttpClient httpClient, string requestUrl)
    {
        var result = await httpClient.GetAsync(requestUrl);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        return DeserializeResponse<TResult>(content);
    }

    public static async Task<TResult?> PostAsync<TValue, TResult>(this HttpClient httpClient, string requestUrl, TValue data)
    {
        var result = await httpClient.PostAsJsonAsync(requestUrl, data);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();

        return DeserializeResponse<TResult>(content);
    }
    public static async Task<TResult?> PutAsync<TValue, TResult>(this HttpClient httpClient, string requestUrl, TValue data)
    {
        var result = await httpClient.PutAsJsonAsync(requestUrl, data);
        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();

        return DeserializeResponse<TResult>(content);
    }

    private static TResult? DeserializeResponse<TResult>(string response)
    {
        return JsonSerializer.Deserialize<TResult>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } });
    }
}
