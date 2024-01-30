// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface IEmployeesService
{
    public Task<List<EmployeeDto>> GetAllAsync();
    public Task<EmployeeDto?> GetByIdAsync(string id);
    public Task<EmployeeDto?> CreateAsync(EmployeeCreateDto employee);
    public Task<EmployeeDto?> UpdateAsync(EmployeeUpdateDto employee);
    public Task DeleteAsync(string id);
}

internal partial class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class EmployeesServiceBase : IEmployeesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected EmployeesServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.EmployeesUrl;
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<EmployeeDto>>(_apiBaseUrl);
        return items ?? new List<EmployeeDto>();
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