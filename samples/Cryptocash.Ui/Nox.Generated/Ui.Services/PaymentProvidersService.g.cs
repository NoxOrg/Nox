// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface IPaymentProvidersService
{
    public Task<List<PaymentProviderModel>> GetAllAsync();
    public Task<EntityData<PaymentProviderModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<PaymentProviderModel?> GetByIdAsync(string id);
    public Task<PaymentProviderModel?> CreateAsync(PaymentProviderModel paymentProvider);
    public Task<PaymentProviderModel?> UpdateAsync(PaymentProviderModel paymentProvider);
    public Task DeleteAsync(PaymentProviderModel paymentProvider);
    public ApiUiService IntialiseApiUiService();
}

internal partial class PaymentProvidersService : PaymentProvidersServiceBase
{
    public PaymentProvidersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentProviderModel, PaymentProviderDto> dtoConverter,
        IModelConverter<PaymentProviderModel, PaymentProviderCreateDto> createDtoConverter,
        IModelConverter<PaymentProviderModel, PaymentProviderUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class PaymentProvidersServiceBase : IPaymentProvidersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<PaymentProviderModel, PaymentProviderDto> _dtoConverter;
    private readonly IModelConverter<PaymentProviderModel, PaymentProviderCreateDto> _createDtoConverter;
    private readonly IModelConverter<PaymentProviderModel, PaymentProviderUpdateDto> _updateDtoConverter;

    protected PaymentProvidersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<PaymentProviderModel, PaymentProviderDto> dtoConverter,
        IModelConverter<PaymentProviderModel, PaymentProviderCreateDto> createDtoConverter,
        IModelConverter<PaymentProviderModel, PaymentProviderUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.PaymentProvidersUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<PaymentProviderModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<PaymentProviderDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<PaymentProviderModel>();
    }

    public async Task<EntityData<PaymentProviderModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<PaymentProviderDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<PaymentProviderModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<PaymentProviderModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<PaymentProviderModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<PaymentProviderDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<PaymentProviderModel?> CreateAsync(PaymentProviderModel paymentProvider)
    {
        var item = await _httpClient.PostAsync<PaymentProviderCreateDto, PaymentProviderDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(paymentProvider));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<PaymentProviderModel?> UpdateAsync(PaymentProviderModel paymentProvider)
    {
        if (paymentProvider.Etag != Guid.Empty)
        {
            string currentEtag = paymentProvider.Etag.ToString();

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
        if (paymentProvider.Id != null)
        {
            currentID = paymentProvider.Id.ToString();
        }

        var item = await _httpClient.PutAsync<PaymentProviderUpdateDto, PaymentProviderDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(paymentProvider));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(PaymentProviderModel paymentProvider)
    {
        if (paymentProvider.Etag != Guid.Empty)
        {
            string currentEtag = paymentProvider.Etag.ToString();

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
        if (paymentProvider.Id != null)
        {
            currentID = paymentProvider.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "PaymentProviderName",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "PaymentProviderType",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PaymentProviderName",
                DisplayLabel = "Payment Provider",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PaymentProviderType",
                DisplayLabel = "Provider Type",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PaymentProviderName",
                DisplayLabel = "Payment Provider",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PaymentProviderType",
                DisplayLabel = "Provider Type",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });  

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "PaymentProviderName",
                DisplayLabel = "Payment Provider",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "PaymentProviderType",
                DisplayLabel = "Provider Type",
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