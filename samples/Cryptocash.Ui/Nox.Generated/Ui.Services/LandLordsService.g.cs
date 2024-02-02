// Generated

#nullable enable

using Nox.Ui.Blazor.Lib.Contracts;
using Nox.Ui.Blazor.Lib.Extensions;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ILandLordsService
{
    public Task<List<LandLordModel>> GetAllAsync();
    public Task<LandLordModel?> GetByIdAsync(string id);
    public Task<LandLordModel?> CreateAsync(LandLordModel landLord);
    public Task<LandLordModel?> UpdateAsync(LandLordModel landLord);
    public Task DeleteAsync(string id);
}

internal partial class LandLordsService : LandLordsServiceBase
{
    public LandLordsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<LandLordModel, LandLordDto> dtoConverter,
        IModelConverter<LandLordModel, LandLordCreateDto> createDtoConverter,
        IModelConverter<LandLordModel, LandLordUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class LandLordsServiceBase : ILandLordsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<LandLordModel, LandLordDto> _dtoConverter;
    private readonly IModelConverter<LandLordModel, LandLordCreateDto> _createDtoConverter;
    private readonly IModelConverter<LandLordModel, LandLordUpdateDto> _updateDtoConverter;

    protected LandLordsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<LandLordModel, LandLordDto> dtoConverter,
        IModelConverter<LandLordModel, LandLordCreateDto> createDtoConverter,
        IModelConverter<LandLordModel, LandLordUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.LandLordsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<LandLordModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<LandLordDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<LandLordModel>();
    }

    public async Task<LandLordModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<LandLordDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<LandLordModel?> CreateAsync(LandLordModel landLord)
    {
        var item = await _httpClient.PostAsync<LandLordCreateDto, LandLordDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(landLord));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<LandLordModel?> UpdateAsync(LandLordModel landLord)
    {
        var item = await _httpClient.PutAsync<LandLordUpdateDto, LandLordDto>(_apiBaseUrl, _updateDtoConverter.ConvertToDto(landLord));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}