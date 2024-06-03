// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ICommissionsService
{
    public Task<List<CommissionModel>> GetAllAsync();
    public Task<CommissionModel?> GetByIdAsync(string id);
    public Task<CommissionModel?> CreateAsync(CommissionModel commission);
    public Task<CommissionModel?> UpdateAsync(CommissionModel commission);
    public Task DeleteAsync(CommissionModel commission);
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
        if (commission.Etag != Guid.Empty)
        {
            string currentEtag = commission.Etag.ToString();

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
        if (commission.Id != null)
        {
            currentID = commission.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CommissionUpdateDto, CommissionDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(commission));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CommissionModel commission)
    {
        if (commission.Etag != Guid.Empty)
        {
            string currentEtag = commission.Etag.ToString();

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
        if (commission.Id != null)
        {
            currentID = commission.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}