// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface ICashStockOrdersService
{
    public Task<List<CashStockOrderDto>> GetAllAsync();
    public Task<CashStockOrderDto?> GetByIdAsync(string id);
    public Task<CashStockOrderDto?> CreateAsync(CashStockOrderCreateDto cashStockOrder);
    public Task<CashStockOrderDto?> UpdateAsync(CashStockOrderUpdateDto cashStockOrder);
    public Task DeleteAsync(string id);
}

internal partial class CashStockOrdersService : CashStockOrdersServiceBase
{
    public CashStockOrdersService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class CashStockOrdersServiceBase : ICashStockOrdersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CashStockOrdersServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
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