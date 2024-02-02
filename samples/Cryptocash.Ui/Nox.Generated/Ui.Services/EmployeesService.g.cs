// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IEmployeesService
{
    public Task<List<EmployeeModel>> GetAllAsync();
    public Task<EmployeeDto?> GetByIdAsync(string id);
    public Task<EmployeeDto?> CreateAsync(EmployeeCreateDto employee);
    public Task<EmployeeDto?> UpdateAsync(EmployeeUpdateDto employee);
    public Task DeleteAsync(string id);
}

internal partial class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<EmployeeModel, EmployeeDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class EmployeesServiceBase : IEmployeesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<EmployeeModel, EmployeeDto> _modelConverter;

    protected EmployeesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<EmployeeModel, EmployeeDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.EmployeesUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<EmployeeModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<EmployeeDto>>(_apiBaseUrl);
        if (items is null)
            return new List<EmployeeModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
    }

    public async Task<EmployeeDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<EmployeeDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<EmployeeDto?> CreateAsync(EmployeeCreateDto employee)
    {
        return await _httpClient.PostAsync<EmployeeCreateDto, EmployeeDto>(_apiBaseUrl, employee);
    }

    public async Task<EmployeeDto?> UpdateAsync(EmployeeUpdateDto employee)
    {
        return await _httpClient.PutAsync<EmployeeUpdateDto, EmployeeDto>(_apiBaseUrl, employee);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}