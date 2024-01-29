// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class EmployeesServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected EmployeesServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
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