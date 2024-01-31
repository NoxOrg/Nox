// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface IMinimumCashStocksService
{
    public Task<List<MinimumCashStockDto>> GetAllAsync();
    public Task<MinimumCashStockDto?> GetByIdAsync(string id);
    public Task<MinimumCashStockDto?> CreateAsync(MinimumCashStockCreateDto minimumCashStock);
    public Task<MinimumCashStockDto?> UpdateAsync(MinimumCashStockUpdateDto minimumCashStock);
    public Task DeleteAsync(string id);
}

internal partial class MinimumCashStocksService : MinimumCashStocksServiceBase
{
    public MinimumCashStocksService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class MinimumCashStocksServiceBase : IMinimumCashStocksService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected MinimumCashStocksServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.MinimumCashStocksUrl;
    }

    public async Task<List<MinimumCashStockDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<MinimumCashStockDto>>(_apiBaseUrl);
        return items ?? new List<MinimumCashStockDto>();
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