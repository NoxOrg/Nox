// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICurrenciesService
{
    public Task<List<CurrencyModel>> GetAllAsync();
    public Task<CurrencyModel?> GetByIdAsync(string id);
    public Task<CurrencyModel?> CreateAsync(CurrencyModel currency);
    public Task<CurrencyModel?> UpdateAsync(CurrencyModel currency);
    public Task DeleteAsync(string id);
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
        var item = await _httpClient.PutAsync<CurrencyUpdateDto, CurrencyDto>(_apiBaseUrl, _updateDtoConverter.ConvertToDto(currency));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}