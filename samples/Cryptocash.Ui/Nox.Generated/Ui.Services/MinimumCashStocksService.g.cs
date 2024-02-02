// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IMinimumCashStocksService
{
    public Task<List<MinimumCashStockModel>> GetAllAsync();
    public Task<MinimumCashStockDto?> GetByIdAsync(string id);
    public Task<MinimumCashStockDto?> CreateAsync(MinimumCashStockCreateDto minimumCashStock);
    public Task<MinimumCashStockDto?> UpdateAsync(MinimumCashStockUpdateDto minimumCashStock);
    public Task DeleteAsync(string id);
}

internal partial class MinimumCashStocksService : MinimumCashStocksServiceBase
{
    public MinimumCashStocksService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<MinimumCashStockModel, MinimumCashStockDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class MinimumCashStocksServiceBase : IMinimumCashStocksService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<MinimumCashStockModel, MinimumCashStockDto> _modelConverter;

    protected MinimumCashStocksServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<MinimumCashStockModel, MinimumCashStockDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.MinimumCashStocksUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<MinimumCashStockModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<MinimumCashStockDto>>(_apiBaseUrl);
        if (items is null)
            return new List<MinimumCashStockModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
    }

    public async Task<MinimumCashStockDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<MinimumCashStockDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<MinimumCashStockDto?> CreateAsync(MinimumCashStockCreateDto minimumCashStock)
    {
        return await _httpClient.PostAsync<MinimumCashStockCreateDto, MinimumCashStockDto>(_apiBaseUrl, minimumCashStock);
    }

    public async Task<MinimumCashStockDto?> UpdateAsync(MinimumCashStockUpdateDto minimumCashStock)
    {
        return await _httpClient.PutAsync<MinimumCashStockUpdateDto, MinimumCashStockDto>(_apiBaseUrl, minimumCashStock);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}