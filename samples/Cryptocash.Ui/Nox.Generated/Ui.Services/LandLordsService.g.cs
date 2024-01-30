// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface ILandLordsService
{
    public Task<List<LandLordDto>> GetAllAsync();
    public Task<LandLordDto?> GetByIdAsync(string id);
    public Task<LandLordDto?> CreateAsync(LandLordCreateDto landLord);
    public Task<LandLordDto?> UpdateAsync(LandLordUpdateDto landLord);
    public Task DeleteAsync(string id);
}

internal partial class LandLordsService : LandLordsServiceBase
{
    public LandLordsService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class LandLordsServiceBase : ILandLordsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected LandLordsServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.LandLordsUrl;
    }

    public async Task<List<LandLordDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<LandLordDto>>(_apiBaseUrl);
        return items ?? new List<LandLordDto>();
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