// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface IMinimumCashStocksService
{
    public Task<List<MinimumCashStockModel>> GetAllAsync();
    public Task<EntityData<MinimumCashStockModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<MinimumCashStockModel?> GetByIdAsync(string id);
    public Task<MinimumCashStockModel?> CreateAsync(MinimumCashStockModel minimumCashStock);
    public Task<MinimumCashStockModel?> UpdateAsync(MinimumCashStockModel minimumCashStock);
    public Task DeleteAsync(MinimumCashStockModel minimumCashStock);
    public ApiUiService IntialiseApiUiService();
}

internal partial class MinimumCashStocksService : MinimumCashStocksServiceBase
{
    public MinimumCashStocksService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<MinimumCashStockModel, MinimumCashStockDto> dtoConverter,
        IModelConverter<MinimumCashStockModel, MinimumCashStockCreateDto> createDtoConverter,
        IModelConverter<MinimumCashStockModel, MinimumCashStockUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class MinimumCashStocksServiceBase : IMinimumCashStocksService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<MinimumCashStockModel, MinimumCashStockDto> _dtoConverter;
    private readonly IModelConverter<MinimumCashStockModel, MinimumCashStockCreateDto> _createDtoConverter;
    private readonly IModelConverter<MinimumCashStockModel, MinimumCashStockUpdateDto> _updateDtoConverter;

    protected MinimumCashStocksServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<MinimumCashStockModel, MinimumCashStockDto> dtoConverter,
        IModelConverter<MinimumCashStockModel, MinimumCashStockCreateDto> createDtoConverter,
        IModelConverter<MinimumCashStockModel, MinimumCashStockUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.MinimumCashStocksUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<MinimumCashStockModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<MinimumCashStockDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<MinimumCashStockModel>();
    }

    public async Task<EntityData<MinimumCashStockModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<MinimumCashStockDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<MinimumCashStockModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<MinimumCashStockModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<MinimumCashStockModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<MinimumCashStockDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<MinimumCashStockModel?> CreateAsync(MinimumCashStockModel minimumCashStock)
    {
        var item = await _httpClient.PostAsync<MinimumCashStockCreateDto, MinimumCashStockDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(minimumCashStock));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<MinimumCashStockModel?> UpdateAsync(MinimumCashStockModel minimumCashStock)
    {
        if (minimumCashStock.Etag != Guid.Empty)
        {
            string currentEtag = minimumCashStock.Etag.ToString();

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
        if (minimumCashStock.Id != null)
        {
            currentID = minimumCashStock.Id.ToString();
        }

        var item = await _httpClient.PutAsync<MinimumCashStockUpdateDto, MinimumCashStockDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(minimumCashStock));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(MinimumCashStockModel minimumCashStock)
    {
        if (minimumCashStock.Etag != Guid.Empty)
        {
            string currentEtag = minimumCashStock.Etag.ToString();

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
        if (minimumCashStock.Id != null)
        {
            currentID = minimumCashStock.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Amount",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Amount",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Amount",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });               

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();        

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