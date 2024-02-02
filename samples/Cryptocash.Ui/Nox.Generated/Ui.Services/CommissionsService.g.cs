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
    public Task<CommissionDto?> GetByIdAsync(string id);
    public Task<CommissionDto?> CreateAsync(CommissionCreateDto commission);
    public Task<CommissionDto?> UpdateAsync(CommissionUpdateDto commission);
    public Task DeleteAsync(string id);
}

internal partial class CommissionsService : CommissionsServiceBase
{
    public CommissionsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CommissionModel, CommissionDto> modelConverter)
        : base(httpClient, endpointsProvider, modelConverter)
    {
    }
}

internal abstract partial class CommissionsServiceBase : ICommissionsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CommissionModel, CommissionDto> _modelConverter;

    protected CommissionsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CommissionModel, CommissionDto> modelConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CommissionsUrl;
        _modelConverter = modelConverter;
    }

    public async Task<List<CommissionModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CommissionDto>>(_apiBaseUrl);
        if (items is null)
            return new List<CommissionModel>();

        return items.Select(i => _modelConverter.ConvertToModel(i)).ToList();
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