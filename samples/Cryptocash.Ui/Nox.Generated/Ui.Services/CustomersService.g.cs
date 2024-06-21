// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ICustomersService
{
    public Task<List<CustomerModel>> GetAllAsync();
    public Task<EntityData<CustomerModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<CustomerModel?> GetByIdAsync(string id);
    public Task<CustomerModel?> CreateAsync(CustomerModel customer);
    public Task<CustomerModel?> UpdateAsync(CustomerModel customer);
    public Task DeleteAsync(CustomerModel customer);
    public ApiUiService IntialiseApiUiService();
}

internal partial class CustomersService : CustomersServiceBase
{
    public CustomersService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CustomerModel, CustomerDto> dtoConverter,
        IModelConverter<CustomerModel, CustomerCreateDto> createDtoConverter,
        IModelConverter<CustomerModel, CustomerUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CustomersServiceBase : ICustomersService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CustomerModel, CustomerDto> _dtoConverter;
    private readonly IModelConverter<CustomerModel, CustomerCreateDto> _createDtoConverter;
    private readonly IModelConverter<CustomerModel, CustomerUpdateDto> _updateDtoConverter;

    protected CustomersServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CustomerModel, CustomerDto> dtoConverter,
        IModelConverter<CustomerModel, CustomerCreateDto> createDtoConverter,
        IModelConverter<CustomerModel, CustomerUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CustomersUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CustomerModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CustomerDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CustomerModel>();
    }

    public async Task<EntityData<CustomerModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<CustomerDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<CustomerModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CustomerModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<CustomerModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CustomerDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CustomerModel?> CreateAsync(CustomerModel customer)
    {
        var item = await _httpClient.PostAsync<CustomerCreateDto, CustomerDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(customer));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CustomerModel?> UpdateAsync(CustomerModel customer)
    {
        if (customer.Etag != Guid.Empty)
        {
            string currentEtag = customer.Etag.ToString();

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
        if (customer.Id != null)
        {
            currentID = customer.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CustomerUpdateDto, CustomerDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(customer));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CustomerModel customer)
    {
        if (customer.Etag != Guid.Empty)
        {
            string currentEtag = customer.Etag.ToString();

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
        if (customer.Id != null)
        {
            currentID = customer.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "FirstName",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "LastName",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "EmailAddress",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Address",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MobileNumber",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "FirstName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "FirstName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "LastName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "LastName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "EmailAddress",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "EmailAddress",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Address",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Address",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MobileNumber",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MobileNumber",
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