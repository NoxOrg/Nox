// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICashStockOrdersService
{
    public Task<List<CashStockOrderModel>> GetAllAsync();
    public Task<CashStockOrderDto?> GetByIdAsync(string id);
    public Task<CashStockOrderDto?> CreateAsync(CashStockOrderCreateDto cashStockOrder);
    public Task<CashStockOrderDto?> UpdateAsync(CashStockOrderUpdateDto cashStockOrder);
    public Task DeleteAsync(string id);
}

internal partial class CashStockOrdersService : CashStockOrdersServiceBase
{
    public CashStockOrdersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CashStockOrderModel, CashStockOrderDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class CashStockOrdersServiceBase : ICashStockOrdersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CashStockOrderModel, CashStockOrderDto> _modelConverter;

    protected CashStockOrdersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CashStockOrderModel, CashStockOrderDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CashStockOrdersUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<CashStockOrderModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CashStockOrderDto>>(_apiBaseUrl);
        if (items is null)
            return new List<CashStockOrderModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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