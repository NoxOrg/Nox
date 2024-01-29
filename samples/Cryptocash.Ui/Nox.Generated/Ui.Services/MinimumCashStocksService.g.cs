// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class MinimumCashStocksService : MinimumCashStocksServiceBase
{
    public MinimumCashStocksService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class MinimumCashStocksServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected MinimumCashStocksServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
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