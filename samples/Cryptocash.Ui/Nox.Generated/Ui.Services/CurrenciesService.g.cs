// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICurrenciesService
{
    public Task<List<CurrencyModel>> GetAllAsync();
    public Task<CurrencyModel?> GetByIdAsync(string id);
    public Task<CurrencyModel?> CreateAsync(CurrencyModel currency);
    public Task<CurrencyModel?> UpdateAsync(CurrencyModel currency);
    public Task DeleteAsync(CurrencyModel currency);
}

internal partial class CurrenciesService : CurrenciesServiceBase
{
    public CurrenciesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CurrencyModel, CurrencyDto> dtoConverter,
        IModelConverter<CurrencyModel, CurrencyCreateDto> createDtoConverter,
        IModelConverter<CurrencyModel, CurrencyUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CurrenciesServiceBase : ICurrenciesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CurrencyModel, CurrencyDto> _dtoConverter;
    private readonly IModelConverter<CurrencyModel, CurrencyCreateDto> _createDtoConverter;
    private readonly IModelConverter<CurrencyModel, CurrencyUpdateDto> _updateDtoConverter;

    protected CurrenciesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CurrencyModel, CurrencyDto> dtoConverter,
        IModelConverter<CurrencyModel, CurrencyCreateDto> createDtoConverter,
        IModelConverter<CurrencyModel, CurrencyUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CurrenciesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CurrencyModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CurrencyDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CurrencyModel>();
    }

    public async Task<CurrencyModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CurrencyDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CurrencyModel?> CreateAsync(CurrencyModel currency)
    {
        var item = await _httpClient.PostAsync<CurrencyCreateDto, CurrencyDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(currency));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CurrencyModel?> UpdateAsync(CurrencyModel currency)
    {
        if (currency.Etag != Guid.Empty)
        {
            string currentEtag = currency.Etag.ToString();

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
        if (currency.Id != null)
        {
            currentID = currency.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CurrencyUpdateDto, CurrencyDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(currency));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CurrencyModel currency)
    {
        if (currency.Etag != Guid.Empty)
        {
            string currentEtag = currency.Etag.ToString();

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
        if (currency.Id != null)
        {
            currentID = currency.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}