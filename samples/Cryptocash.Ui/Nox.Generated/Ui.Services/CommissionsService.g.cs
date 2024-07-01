// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ICommissionsService
{
    public Task<List<CommissionModel>> GetAllAsync();
    public Task<EntityData<CommissionModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<CommissionModel?> GetByIdAsync(string id);
    public Task<CommissionModel?> CreateAsync(CommissionModel commission);
    public Task<CommissionModel?> UpdateAsync(CommissionModel commission);
    public Task DeleteAsync(CommissionModel commission);
    public ApiUiService IntialiseApiUiService();
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

    public async Task<EntityData<CommissionModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<CommissionDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<CommissionModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CommissionModel>();

            return rtnItems;
        }

        return null;
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

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Rate",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "EffectiveAt",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Rate",
                DisplayLabel = "Commission Rate",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "EffectiveAt",
                DisplayLabel = "Effective At",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Rate",
                DisplayLabel = "Commission Rate",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "EffectiveAt",
                DisplayLabel = "Effective At",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });  

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "Rate",
                DisplayLabel = "Commission Rate",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "EffectiveAt",
                DisplayLabel = "Effective At",
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