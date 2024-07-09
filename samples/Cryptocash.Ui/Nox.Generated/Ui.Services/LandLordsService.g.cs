// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ILandLordsService
{
    public Task<List<LandLordModel>> GetAllAsync();
    public Task<EntityData<LandLordModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<LandLordModel?> GetByIdAsync(string id);
    public Task<LandLordModel?> CreateAsync(LandLordModel landLord);
    public Task<LandLordModel?> UpdateAsync(LandLordModel landLord);
    public Task DeleteAsync(LandLordModel landLord);
    public ApiUiService IntialiseApiUiService();
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

    public async Task<EntityData<LandLordModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<LandLordDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<LandLordModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<LandLordModel>();

            return rtnItems;
        }

        return null;
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

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Name",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Name",
                DisplayLabel = "Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Address",
                DisplayLabel = "Address",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Name",
                DisplayLabel = "Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Address",
                DisplayLabel = "Address",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });  

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "Name",
                DisplayLabel = "Name",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "Address",
                DisplayLabel = "Address",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });        

        rtnApiUiService.Paging = new Paging()
        {
            CurrentPage = 0,
            CurrentPageSize = 5,
            EntityTotal = 0,
            PageSizeList = new List<int> {
                3,
                5,
                10,
                20
            }
        };

        return rtnApiUiService;
    }
}