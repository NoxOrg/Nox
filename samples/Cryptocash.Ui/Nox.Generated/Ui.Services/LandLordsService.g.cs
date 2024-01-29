// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class LandLordsService : LandLordsServiceBase
{
    public LandLordsService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class LandLordsServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected LandLordsServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
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