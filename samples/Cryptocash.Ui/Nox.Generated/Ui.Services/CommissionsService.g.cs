// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public partial class CommissionsService : CommissionsServiceBase
{
    public CommissionsService(HttpClient httpClient, EndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

public abstract partial class CommissionsServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CommissionsServiceBase(HttpClient httpClient, EndpointsProvider endpointsProvider)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CommissionsUrl;
    }

    public async Task<List<CommissionDto>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CommissionDto>>(_apiBaseUrl);
        return items ?? new List<CommissionDto>();
    }

    public async Task<CommissionDto?> GetByIdAsync(string id)
    {
        return await _httpClient.GetODataSimpleResponseAsync<CommissionDto>($"{_apiBaseUrl}/{id}");
    }

    public async Task<CommissionDto?> CreateAsync(CommissionCreateDto commission)
    {
        return await _httpClient.PostAsync<CommissionCreateDto, CommissionDto>(_apiBaseUrl, commission);
    }

    public async Task<CommissionDto?> UpdateAsync(CommissionUpdateDto commission)
    {
        return await _httpClient.PutAsync<CommissionUpdateDto, CommissionDto>(_apiBaseUrl, commission);
    }

    public async Task DeleteAsync(string id)
    {
        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
    }
}