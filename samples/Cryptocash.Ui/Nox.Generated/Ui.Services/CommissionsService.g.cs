// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICommissionsService
{
    public Task<List<CommissionModel>> GetAllAsync();
    public Task<CommissionModel?> GetByIdAsync(string id);
    public Task<CommissionModel?> CreateAsync(CommissionModel commission);
    public Task<CommissionModel?> UpdateAsync(CommissionModel commission);
    public Task DeleteAsync(string id);
}

internal partial class CommissionsService : CommissionsServiceBase
{
    public CommissionsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CommissionModel, CommissionDto> dtoConverter,
        IModelConverter<CommissionModel, CommissionCreateDto> createDtoConverter,
        IModelConverter<CommissionModel, CommissionUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CommissionsServiceBase : ICommissionsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CommissionModel, CommissionDto> _dtoConverter;
    private readonly IModelConverter<CommissionModel, CommissionCreateDto> _createDtoConverter;
    private readonly IModelConverter<CommissionModel, CommissionUpdateDto> _updateDtoConverter;

    protected CommissionsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CommissionModel, CommissionDto> dtoConverter,
        IModelConverter<CommissionModel, CommissionCreateDto> createDtoConverter,
        IModelConverter<CommissionModel, CommissionUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CommissionsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CommissionModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CommissionDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CommissionModel>();
    }

    public async Task<CommissionModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CommissionDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CommissionModel?> CreateAsync(CommissionModel commission)
    {
        var item = await _httpClient.PostAsync<CommissionCreateDto, CommissionDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(commission));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CommissionModel?> UpdateAsync(CommissionModel commission)
    {
        var item = await _httpClient.PutAsync<CommissionUpdateDto, CommissionDto>(_apiBaseUrl, _updateDtoConverter.ConvertToDto(commission));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}