// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface ICurrenciesService
{
    public Task<List<CurrencyDto>> GetAllAsync();
    public Task<CurrencyDto?> GetByIdAsync(string id);
    public Task<CurrencyDto?> CreateAsync(CurrencyCreateDto currency);
    public Task<CurrencyDto?> UpdateAsync(CurrencyUpdateDto currency);
    public Task DeleteAsync(string id);
}

internal partial class CurrenciesService : CurrenciesServiceBase
{
    public CurrenciesService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class CurrenciesServiceBase : ICurrenciesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CurrenciesServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
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