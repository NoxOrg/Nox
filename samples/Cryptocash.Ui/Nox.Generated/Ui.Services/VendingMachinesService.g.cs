// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IVendingMachinesService
{
    public Task<List<VendingMachineModel>> GetAllAsync();
    public Task<VendingMachineDto?> GetByIdAsync(string id);
    public Task<VendingMachineDto?> CreateAsync(VendingMachineCreateDto vendingMachine);
    public Task<VendingMachineDto?> UpdateAsync(VendingMachineUpdateDto vendingMachine);
    public Task DeleteAsync(string id);
}

internal partial class VendingMachinesService : VendingMachinesServiceBase
{
    public VendingMachinesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<VendingMachineModel, VendingMachineDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class VendingMachinesServiceBase : IVendingMachinesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<VendingMachineModel, VendingMachineDto> _modelConverter;

    protected VendingMachinesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<VendingMachineModel, VendingMachineDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.VendingMachinesUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<VendingMachineModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<VendingMachineDto>>(_apiBaseUrl);
        if (items is null)
            return new List<VendingMachineModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
    }

    public async Task<VendingMachineDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<VendingMachineDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<VendingMachineDto?> CreateAsync(VendingMachineCreateDto vendingMachine)
    {
        return await _httpClient.PostAsync<VendingMachineCreateDto, VendingMachineDto>(_apiBaseUrl, vendingMachine);
    }

    public async Task<VendingMachineDto?> UpdateAsync(VendingMachineUpdateDto vendingMachine)
    {
        return await _httpClient.PutAsync<VendingMachineUpdateDto, VendingMachineDto>(_apiBaseUrl, vendingMachine);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}