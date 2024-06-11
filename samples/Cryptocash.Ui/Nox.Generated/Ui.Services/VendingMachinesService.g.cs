// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface IVendingMachinesService
{
    public Task<List<VendingMachineModel>> GetAllAsync();
    public Task<VendingMachineModel?> GetByIdAsync(string id);
    public Task<VendingMachineModel?> CreateAsync(VendingMachineModel vendingMachine);
    public Task<VendingMachineModel?> UpdateAsync(VendingMachineModel vendingMachine);
    public Task DeleteAsync(VendingMachineModel vendingMachine);
}

internal partial class VendingMachinesService : VendingMachinesServiceBase
{
    public VendingMachinesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<VendingMachineModel, VendingMachineDto> dtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineCreateDto> createDtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class VendingMachinesServiceBase : IVendingMachinesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<VendingMachineModel, VendingMachineDto> _dtoConverter;
    private readonly IModelConverter<VendingMachineModel, VendingMachineCreateDto> _createDtoConverter;
    private readonly IModelConverter<VendingMachineModel, VendingMachineUpdateDto> _updateDtoConverter;

    protected VendingMachinesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<VendingMachineModel, VendingMachineDto> dtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineCreateDto> createDtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.VendingMachinesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<VendingMachineModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<VendingMachineDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<VendingMachineModel>();
    }

    public async Task<VendingMachineModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<VendingMachineDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<VendingMachineModel?> CreateAsync(VendingMachineModel vendingMachine)
    {
        var item = await _httpClient.PostAsync<VendingMachineCreateDto, VendingMachineDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(vendingMachine));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<VendingMachineModel?> UpdateAsync(VendingMachineModel vendingMachine)
    {
        if (vendingMachine.Etag != Guid.Empty)
        {
            string currentEtag = vendingMachine.Etag.ToString();

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
        if (vendingMachine.Id != null)
        {
            currentID = vendingMachine.Id.ToString();
        }

        var item = await _httpClient.PutAsync<VendingMachineUpdateDto, VendingMachineDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(vendingMachine));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(VendingMachineModel vendingMachine)
    {
        if (vendingMachine.Etag != Guid.Empty)
        {
            string currentEtag = vendingMachine.Etag.ToString();

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
        if (vendingMachine.Id != null)
        {
            currentID = vendingMachine.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}