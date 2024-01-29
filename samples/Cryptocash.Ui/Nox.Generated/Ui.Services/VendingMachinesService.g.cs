// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class VendingMachinesService : VendingMachinesServiceBase
{
    public VendingMachinesService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class VendingMachinesServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected VendingMachinesServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.VendingMachinesUrl;
    }

    public async Task<List<VendingMachineDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<VendingMachineDto>>(_apiBaseUrl);
        return items ?? new List<VendingMachineDto>();
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