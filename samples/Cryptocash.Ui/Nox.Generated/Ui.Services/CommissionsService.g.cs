// Generated

#nullable enable

using Cryptocash.Application.Dto;
using Nox.Ui.Blazor.Lib.Extensions;

namespace Cryptocash.Ui.Services;

public interface ICommissionsService
{
    public Task<List<CommissionDto>> GetAllAsync();
    public Task<CommissionDto?> GetByIdAsync(string id);
    public Task<CommissionDto?> CreateAsync(CommissionCreateDto commission);
    public Task<CommissionDto?> UpdateAsync(CommissionUpdateDto commission);
    public Task DeleteAsync(string id);
}

internal partial class CommissionsService : CommissionsServiceBase
{
    public CommissionsService(HttpClient httpClient, IEndpointsProvider endpointsProvider)
        : base(httpClient, endpointsProvider)
    {
    }
}

internal abstract partial class CommissionsServiceBase : ICommissionsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    protected CommissionsServiceBase(HttpClient httpClient, IEndpointsProvider endpointsProvider)
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