// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class CountriesService : CountriesServiceBase
{
    public CountriesService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class CountriesServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CountriesServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CountriesUrl;
    }

    public async Task<List<CountryDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CountryDto>>(_apiBaseUrl);
        return items ?? new List<CountryDto>();
    }

    public async Task<CountryDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<CountryDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<CountryDto?> CreateAsync(CountryCreateDto country)
    {
        return await _httpClient.PostAsync<CountryCreateDto, CountryDto>(_apiBaseUrl, country);
    }

    public async Task<CountryDto?> UpdateAsync(CountryUpdateDto country)
    {
        return await _httpClient.PutAsync<CountryUpdateDto, CountryDto>(_apiBaseUrl, country);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}