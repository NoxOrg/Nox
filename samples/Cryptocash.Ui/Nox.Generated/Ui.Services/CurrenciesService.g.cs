// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class CurrenciesService : CurrenciesServiceBase
{
    public CurrenciesService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class CurrenciesServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CurrenciesServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CurrenciesUrl;
    }

    public async Task<List<CurrencyDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CurrencyDto>>(_apiBaseUrl);
        return items ?? new List<CurrencyDto>();
    }

    public async Task<CurrencyDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<CurrencyDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<CurrencyDto?> CreateAsync(CurrencyCreateDto currency)
    {
        return await _httpClient.PostAsync<CurrencyCreateDto, CurrencyDto>(_apiBaseUrl, currency);
    }

    public async Task<CurrencyDto?> UpdateAsync(CurrencyUpdateDto currency)
    {
        return await _httpClient.PutAsync<CurrencyUpdateDto, CurrencyDto>(_apiBaseUrl, currency);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}