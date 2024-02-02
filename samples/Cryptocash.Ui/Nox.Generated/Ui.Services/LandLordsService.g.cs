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
    public Task<LandLordDto?> GetByIdAsync(string id);
    public Task<LandLordDto?> CreateAsync(LandLordCreateDto landLord);
    public Task<LandLordDto?> UpdateAsync(LandLordUpdateDto landLord);
    public Task DeleteAsync(string id);
}

internal partial class LandLordsService : LandLordsServiceBase
{
    public LandLordsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<LandLordModel, LandLordDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class LandLordsServiceBase : ILandLordsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<LandLordModel, LandLordDto> _modelConverter;

    protected LandLordsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<LandLordModel, LandLordDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.LandLordsUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<LandLordModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<LandLordDto>>(_apiBaseUrl);
        if (items is null)
            return new List<LandLordModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
    }

    public async Task<LandLordDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<LandLordDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<LandLordDto?> CreateAsync(LandLordCreateDto landLord)
    {
        return await _httpClient.PostAsync<LandLordCreateDto, LandLordDto>(_apiBaseUrl, landLord);
    }

    public async Task<LandLordDto?> UpdateAsync(LandLordUpdateDto landLord)
    {
        return await _httpClient.PutAsync<LandLordUpdateDto, LandLordDto>(_apiBaseUrl, landLord);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}