// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ICashStockOrdersService
{
    public Task<List<CashStockOrderModel>> GetAllAsync();
    public Task<EntityData<CashStockOrderModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<CashStockOrderModel?> GetByIdAsync(string id);
    public Task<CashStockOrderModel?> CreateAsync(CashStockOrderModel cashStockOrder);
    public Task<CashStockOrderModel?> UpdateAsync(CashStockOrderModel cashStockOrder);
    public Task DeleteAsync(CashStockOrderModel cashStockOrder);
    public ApiUiService IntialiseApiUiService();
}

internal partial class CashStockOrdersService : CashStockOrdersServiceBase
{
    public CashStockOrdersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CashStockOrderModel, CashStockOrderDto> dtoConverter,
        IModelConverter<CashStockOrderModel, CashStockOrderCreateDto> createDtoConverter,
        IModelConverter<CashStockOrderModel, CashStockOrderUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CashStockOrdersServiceBase : ICashStockOrdersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CashStockOrderModel, CashStockOrderDto> _dtoConverter;
    private readonly IModelConverter<CashStockOrderModel, CashStockOrderCreateDto> _createDtoConverter;
    private readonly IModelConverter<CashStockOrderModel, CashStockOrderUpdateDto> _updateDtoConverter;

    protected CashStockOrdersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CashStockOrderModel, CashStockOrderDto> dtoConverter,
        IModelConverter<CashStockOrderModel, CashStockOrderCreateDto> createDtoConverter,
        IModelConverter<CashStockOrderModel, CashStockOrderUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CashStockOrdersUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CashStockOrderModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CashStockOrderDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CashStockOrderModel>();
    }

    public async Task<EntityData<CashStockOrderModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<CashStockOrderDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<CashStockOrderModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CashStockOrderModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<CashStockOrderModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CashStockOrderDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CashStockOrderModel?> CreateAsync(CashStockOrderModel cashStockOrder)
    {
        var item = await _httpClient.PostAsync<CashStockOrderCreateDto, CashStockOrderDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(cashStockOrder));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CashStockOrderModel?> UpdateAsync(CashStockOrderModel cashStockOrder)
    {
        if (cashStockOrder.Etag != Guid.Empty)
        {
            string currentEtag = cashStockOrder.Etag.ToString();

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
        if (cashStockOrder.Id != null)
        {
            currentID = cashStockOrder.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CashStockOrderUpdateDto, CashStockOrderDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(cashStockOrder));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CashStockOrderModel cashStockOrder)
    {
        if (cashStockOrder.Etag != Guid.Empty)
        {
            string currentEtag = cashStockOrder.Etag.ToString();

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
        if (cashStockOrder.Id != null)
        {
            currentID = cashStockOrder.Id.ToString();
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
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "RequestedDeliveryDate",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "DeliveryDateTime",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Status",
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
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "RequestedDeliveryDate",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "RequestedDeliveryDate",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DeliveryDateTime",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DeliveryDateTime",
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