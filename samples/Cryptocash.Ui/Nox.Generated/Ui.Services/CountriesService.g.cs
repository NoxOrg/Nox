// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICountriesService
{
    public Task<List<CountryModel>> GetAllAsync();
    public Task<CountryDto?> GetByIdAsync(string id);
    public Task<CountryDto?> CreateAsync(CountryCreateDto country);
    public Task<CountryDto?> UpdateAsync(CountryUpdateDto country);
    public Task DeleteAsync(string id);
}

internal partial class CountriesService : CountriesServiceBase
{
    public CountriesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CountryModel, CountryDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class CountriesServiceBase : ICountriesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CountryModel, CountryDto> _modelConverter;

    protected CountriesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CountryModel, CountryDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CountriesUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<CountryModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CountryDto>>(_apiBaseUrl);
        if (items is null)
            return new List<CountryModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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