// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.Services;

public interface ILandLordsService
{
    public Task<List<LandLordModel>> GetAllAsync();
    public Task<LandLordModel?> GetByIdAsync(string id);
    public Task<LandLordModel?> CreateAsync(LandLordModel landLord);
    public Task<LandLordModel?> UpdateAsync(LandLordModel landLord);
    public Task DeleteAsync(LandLordModel landLord);
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
        if (landLord.Etag != Guid.Empty)
        {
            string currentEtag = landLord.Etag.ToString();

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
        if (landLord.Id != null)
        {
            currentID = landLord.Id.ToString();
        }

        var item = await _httpClient.PutAsync<LandLordUpdateDto, LandLordDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(landLord));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(LandLordModel landLord)
    {
        if (landLord.Etag != Guid.Empty)
        {
            string currentEtag = landLord.Etag.ToString();

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
        if (landLord.Id != null)
        {
            currentID = landLord.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }
}