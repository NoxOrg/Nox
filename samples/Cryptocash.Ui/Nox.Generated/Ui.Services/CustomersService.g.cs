// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class CustomersService : CustomersServiceBase
{
    public CustomersService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class CustomersServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CustomersServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
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