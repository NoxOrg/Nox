// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICountriesService
{
    public Task<List<CountryModel>> GetAllAsync();
    public Task<CountryModel?> GetByIdAsync(string id);
    public Task<CountryModel?> CreateAsync(CountryModel country);
    public Task<CountryModel?> UpdateAsync(CountryModel country);
    public Task DeleteAsync(CountryModel country);
}

internal partial class CountriesService : CountriesServiceBase
{
    public CountriesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CountryModel, CountryDto> dtoConverter,
        IModelConverter<CountryModel, CountryCreateDto> createDtoConverter,
        IModelConverter<CountryModel, CountryUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CountriesServiceBase : ICountriesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CountryModel, CountryDto> _dtoConverter;
    private readonly IModelConverter<CountryModel, CountryCreateDto> _createDtoConverter;
    private readonly IModelConverter<CountryModel, CountryUpdateDto> _updateDtoConverter;

    protected CountriesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CountryModel, CountryDto> dtoConverter,
        IModelConverter<CountryModel, CountryCreateDto> createDtoConverter,
        IModelConverter<CountryModel, CountryUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CountriesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CountryModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CountryDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CountryModel>();
    }

    public async Task<CountryModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CountryDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CountryModel?> CreateAsync(CountryModel country)
    {
        var item = await _httpClient.PostAsync<CountryCreateDto, CountryDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(country));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CountryModel?> UpdateAsync(CountryModel country)
    {
        if (country.Etag != Guid.Empty)
        {
            string currentEtag = country.Etag.ToString();

            Dictionary<string, IEnumerable<string>> headers = new()
            {
                { "If-Match", new List<string> { $"\"{currentEtag}\"" } }
            };
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        string? currentID = string.Empty;
        if (country.Id != null)
        {
            currentID = country.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CountryUpdateDto, CountryDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(country));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CountryModel country)
    {
        if (country.Etag != Guid.Empty)
        {
            string currentEtag = country.Etag.ToString();

            Dictionary<string, IEnumerable<string>> headers = new()
            {
                { "If-Match", new List<string> { $"\"{currentEtag}\"" } }
            };
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        string? currentID = string.Empty;
        if (country.Id != null)
        {
            currentID = country.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}