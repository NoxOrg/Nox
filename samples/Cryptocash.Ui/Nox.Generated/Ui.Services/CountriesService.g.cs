// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface ICountriesService
{
    public Task<List<CountryDto>> GetAllAsync();
    public Task<CountryDto?> GetByIdAsync(string id);
    public Task<CountryDto?> CreateAsync(CountryCreateDto country);
    public Task<CountryDto?> UpdateAsync(CountryUpdateDto country);
    public Task DeleteAsync(string id);
}

internal partial class CountriesService : CountriesServiceBase
{
    public CountriesService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class CountriesServiceBase : ICountriesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CountriesServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
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