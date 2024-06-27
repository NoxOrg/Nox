// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface IBookingsService
{
    public Task<List<BookingModel>> GetAllAsync();
    public Task<EntityData<BookingModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<BookingModel?> GetByIdAsync(string id);
    public Task<BookingModel?> CreateAsync(BookingModel booking);
    public Task<BookingModel?> UpdateAsync(BookingModel booking);
    public Task DeleteAsync(BookingModel booking);
    public ApiUiService IntialiseApiUiService();
}

internal partial class BookingsService : BookingsServiceBase
{
    public BookingsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<BookingModel, BookingDto> dtoConverter,
        IModelConverter<BookingModel, BookingCreateDto> createDtoConverter,
        IModelConverter<BookingModel, BookingUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class BookingsServiceBase : IBookingsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<BookingModel, BookingDto> _dtoConverter;
    private readonly IModelConverter<BookingModel, BookingCreateDto> _createDtoConverter;
    private readonly IModelConverter<BookingModel, BookingUpdateDto> _updateDtoConverter;

    protected BookingsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<BookingModel, BookingDto> dtoConverter,
        IModelConverter<BookingModel, BookingCreateDto> createDtoConverter,
        IModelConverter<BookingModel, BookingUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.BookingsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<BookingModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<BookingDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<BookingModel>();
    }

    public async Task<EntityData<BookingModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<BookingDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<BookingModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<BookingModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<BookingModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<BookingDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<BookingModel?> CreateAsync(BookingModel booking)
    {
        var item = await _httpClient.PostAsync<BookingCreateDto, BookingDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(booking));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<BookingModel?> UpdateAsync(BookingModel booking)
    {
        if (booking.Etag != Guid.Empty)
        {
            string currentEtag = booking.Etag.ToString();

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
        if (booking.Id != null)
        {
            currentID = booking.Id.ToString();
        }

        var item = await _httpClient.PutAsync<BookingUpdateDto, BookingDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(booking));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(BookingModel booking)
    {
        if (booking.Etag != Guid.Empty)
        {
            string currentEtag = booking.Etag.ToString();

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
        if (booking.Id != null)
        {
            currentID = booking.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "ExpiryDateTime",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "CancelledDateTime",
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
                PropertyName = "AmountFrom",
                DisplayLabel = "Amount From",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "AmountTo",
                DisplayLabel = "Amount To",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "RequestedPickUpDate",
                DisplayLabel = "Requested Pick Up Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PickedUpDateTime",
                DisplayLabel = "Picked Up Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "ExpiryDateTime",
                DisplayLabel = "Expiry Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CancelledDateTime",
                DisplayLabel = "Cancelled Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Status",
                DisplayLabel = "Status",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "VatNumber",
                DisplayLabel = "Vat Number",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "AmountFrom",
                DisplayLabel = "Amount From",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "AmountTo",
                DisplayLabel = "Amount To",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "RequestedPickUpDate",
                DisplayLabel = "Requested Pick Up Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PickedUpDateTime",
                DisplayLabel = "Picked Up Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "ExpiryDateTime",
                DisplayLabel = "Expiry Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CancelledDateTime",
                DisplayLabel = "Cancelled Date",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Status",
                DisplayLabel = "Status",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "VatNumber",
                DisplayLabel = "Vat Number",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });  

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "AmountFrom",
                DisplayLabel = "Amount From",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "AmountTo",
                DisplayLabel = "Amount To",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "RequestedPickUpDate",
                DisplayLabel = "Requested Pick Up Date",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "PickedUpDateTime",
                DisplayLabel = "Picked Up Date",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "ExpiryDateTime",
                DisplayLabel = "Expiry Date",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "CancelledDateTime",
                DisplayLabel = "Cancelled Date",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "Status",
                DisplayLabel = "Status",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "VatNumber",
                DisplayLabel = "Vat Number",
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