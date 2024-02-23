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
    public Task<CustomerModel?> GetByIdAsync(string id);
    public Task<CustomerModel?> CreateAsync(CustomerModel customer);
    public Task<CustomerModel?> UpdateAsync(CustomerModel customer);
    public Task DeleteAsync(string id);
}

internal partial class CustomersService : CustomersServiceBase
{
    public CustomersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CustomerModel, CustomerDto> dtoConverter,
        IModelConverter<CustomerModel, CustomerCreateDto> createDtoConverter,
        IModelConverter<CustomerModel, CustomerUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CustomersServiceBase : ICustomersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CustomerModel, CustomerDto> _dtoConverter;
    private readonly IModelConverter<CustomerModel, CustomerCreateDto> _createDtoConverter;
    private readonly IModelConverter<CustomerModel, CustomerUpdateDto> _updateDtoConverter;

    protected CustomersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CustomerModel, CustomerDto> dtoConverter,
        IModelConverter<CustomerModel, CustomerCreateDto> createDtoConverter,
        IModelConverter<CustomerModel, CustomerUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CustomersUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CustomerModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CustomerDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CustomerModel>();
    }

    public async Task<CustomerModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CustomerDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CustomerModel?> CreateAsync(CustomerModel customer)
    {
        var item = await _httpClient.PostAsync<CustomerCreateDto, CustomerDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(customer));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CustomerModel?> UpdateAsync(CustomerModel customer)
    {
        var item = await _httpClient.PutAsync<CustomerUpdateDto, CustomerDto>(_apiBaseUrl, _updateDtoConverter.ConvertToDto(customer));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}