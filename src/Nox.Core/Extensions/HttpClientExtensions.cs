using System.Text.Json.Serialization;
using System.Text.Json;

using System.Net.Http.Json;
using Nox.Application.Dto;
using System.Net.Http.Headers;

namespace Nox.Extensions;

public static class HttpClientExtensions
{

    public static async Task<TResult?> GetODataCollectionResponseAsync<TResult>(this HttpClient httpClient, string requestUrl)
    {
      
        var result = await httpClient.GetAsync(requestUrl);

        result.EnsureSuccessStatusCode();

        var content = await result.Content.ReadAsStringAsync();
        var data = DeserializeResponse<ODataCollectionDto<TResult>>(content);

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
    public static async Task<HttpResponseMessage?> DeleteAsync(this HttpClient httpClient, string requestUrl)
    {
        var message = await httpClient.DeleteAsync(requestUrl);

         message.EnsureSuccessStatusCode();

        return message;
    }

    public static HttpClient AddeTag(this HttpClient httpClient, Guid eTag)
    {
        httpClient.DefaultRequestHeaders.IfNoneMatch.Add(new EntityTagHeaderValue($"\"{eTag}\""));
        return httpClient;
    }

    public static HttpClient AddBearToken(this HttpClient httpClient, string bearToken)
    {
        const string BearTokeHeaderName = "Bearer";
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(BearTokeHeaderName, bearToken);
        return httpClient;
    }

    private static TResult? DeserializeResponse<TResult>(string response)
    {
        return JsonSerializer.Deserialize<TResult>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } });
    }
    
}
