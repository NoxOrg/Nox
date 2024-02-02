// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICustomersService
{
    public Task<List<CustomerModel>> GetAllAsync();
    public Task<CustomerDto?> GetByIdAsync(string id);
    public Task<CustomerDto?> CreateAsync(CustomerCreateDto customer);
    public Task<CustomerDto?> UpdateAsync(CustomerUpdateDto customer);
    public Task DeleteAsync(string id);
}

internal partial class CustomersService : CustomersServiceBase
{
    public CustomersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CustomerModel, CustomerDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class CustomersServiceBase : ICustomersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CustomerModel, CustomerDto> _modelConverter;

    protected CustomersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CustomerModel, CustomerDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CustomersUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<CustomerModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CustomerDto>>(_apiBaseUrl);
        if (items is null)
            return new List<CustomerModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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