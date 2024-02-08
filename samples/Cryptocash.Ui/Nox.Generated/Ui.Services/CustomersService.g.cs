// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface ICustomersService
{
    public Task<List<CustomerDto>> GetAllAsync();
    public Task<CustomerDto?> GetByIdAsync(string id);
    public Task<CustomerDto?> CreateAsync(CustomerCreateDto customer);
    public Task<CustomerDto?> UpdateAsync(CustomerUpdateDto customer);
    public Task DeleteAsync(string id);
}

internal partial class CustomersService : CustomersServiceBase
{
    public CustomersService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class CustomersServiceBase : ICustomersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CustomersServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CustomersUrl;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CustomerDto>>(_apiBaseUrl);
        return items ?? new List<CustomerDto>();
    }

    public async Task<CustomerDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<CustomerDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<CustomerDto?> CreateAsync(CustomerCreateDto customer)
    {
        return await _httpClient.PostAsync<CustomerCreateDto, CustomerDto>(_apiBaseUrl, customer);
    }

    public async Task<CustomerDto?> UpdateAsync(CustomerUpdateDto customer)
    {
        return await _httpClient.PutAsync<CustomerUpdateDto, CustomerDto>(_apiBaseUrl, customer);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}