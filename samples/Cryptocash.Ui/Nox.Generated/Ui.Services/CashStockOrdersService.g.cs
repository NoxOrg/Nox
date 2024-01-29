// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class CashStockOrdersService : CashStockOrdersServiceBase
{
    public CashStockOrdersService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class CashStockOrdersServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CashStockOrdersServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CashStockOrdersUrl;
    }

    public async Task<List<CashStockOrderDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CashStockOrderDto>>(_apiBaseUrl);
        return items ?? new List<CashStockOrderDto>();
    }

    public async Task<CashStockOrderDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<CashStockOrderDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<CashStockOrderDto?> CreateAsync(CashStockOrderCreateDto cashStockOrder)
    {
        return await _httpClient.PostAsync<CashStockOrderCreateDto, CashStockOrderDto>(_apiBaseUrl, cashStockOrder);
    }

    public async Task<CashStockOrderDto?> UpdateAsync(CashStockOrderUpdateDto cashStockOrder)
    {
        return await _httpClient.PutAsync<CashStockOrderUpdateDto, CashStockOrderDto>(_apiBaseUrl, cashStockOrder);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}