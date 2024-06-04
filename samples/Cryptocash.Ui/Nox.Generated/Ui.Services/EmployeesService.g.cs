// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IEmployeesService
{
    public Task<List<EmployeeModel>> GetAllAsync();
    public Task<EmployeeModel?> GetByIdAsync(string id);
    public Task<EmployeeModel?> CreateAsync(EmployeeModel employee);
    public Task<EmployeeModel?> UpdateAsync(EmployeeModel employee);
    public Task DeleteAsync(EmployeeModel employee);
}

internal partial class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<EmployeeModel, EmployeeDto> dtoConverter,
        IModelConverter<EmployeeModel, EmployeeCreateDto> createDtoConverter,
        IModelConverter<EmployeeModel, EmployeeUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class EmployeesServiceBase : IEmployeesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<EmployeeModel, EmployeeDto> _dtoConverter;
    private readonly IModelConverter<EmployeeModel, EmployeeCreateDto> _createDtoConverter;
    private readonly IModelConverter<EmployeeModel, EmployeeUpdateDto> _updateDtoConverter;

    protected EmployeesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<EmployeeModel, EmployeeDto> dtoConverter,
        IModelConverter<EmployeeModel, EmployeeCreateDto> createDtoConverter,
        IModelConverter<EmployeeModel, EmployeeUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.EmployeesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<EmployeeModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<EmployeeDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<EmployeeModel>();
    }

    public async Task<EmployeeModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<EmployeeDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<EmployeeModel?> CreateAsync(EmployeeModel employee)
    {
        var item = await _httpClient.PostAsync<EmployeeCreateDto, EmployeeDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(employee));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<EmployeeModel?> UpdateAsync(EmployeeModel employee)
    {
        if (employee.Etag != Guid.Empty)
        {
            string currentEtag = employee.Etag.ToString();

            Dictionary<string, IEnumerable<string>> headers = new()
            {
                { "If-Match", new List<string> { $"\"{currentEtag}\"" } }
            };
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        string? currentID = string.Empty;
        if (employee.Id != null)
        {
            currentID = employee.Id.ToString();
        }

        var item = await _httpClient.PutAsync<EmployeeUpdateDto, EmployeeDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(employee));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(EmployeeModel employee)
    {
        if (employee.Etag != Guid.Empty)
        {
            string currentEtag = employee.Etag.ToString();

            Dictionary<string, IEnumerable<string>> headers = new()
            {
                { "If-Match", new List<string> { $"\"{currentEtag}\"" } }
            };
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        string? currentID = string.Empty;
        if (employee.Id != null)
        {
            currentID = employee.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}