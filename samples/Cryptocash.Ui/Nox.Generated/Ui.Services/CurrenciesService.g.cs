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
    public Task<CurrencyDto?> GetByIdAsync(string id);
    public Task<CurrencyDto?> CreateAsync(CurrencyCreateDto currency);
    public Task<CurrencyDto?> UpdateAsync(CurrencyUpdateDto currency);
    public Task DeleteAsync(string id);
}

internal partial class CurrenciesService : CurrenciesServiceBase
{
    public CurrenciesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CurrencyModel, CurrencyDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class CurrenciesServiceBase : ICurrenciesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CurrencyModel, CurrencyDto> _modelConverter;

    protected CurrenciesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CurrencyModel, CurrencyDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CurrenciesUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<CurrencyModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CurrencyDto>>(_apiBaseUrl);
        if (items is null)
            return new List<CurrencyModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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