// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ICurrenciesService
{
    public Task<List<CurrencyModel>> GetAllAsync();
    public Task<EntityData<CurrencyModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<CurrencyModel?> GetByIdAsync(string id);
    public Task<CurrencyModel?> CreateAsync(CurrencyModel currency);
    public Task<CurrencyModel?> UpdateAsync(CurrencyModel currency);
    public Task DeleteAsync(CurrencyModel currency);
    public ApiUiService IntialiseApiUiService();
}

internal partial class CurrenciesService : CurrenciesServiceBase
{
    public CurrenciesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CurrencyModel, CurrencyDto> dtoConverter,
        IModelConverter<CurrencyModel, CurrencyCreateDto> createDtoConverter,
        IModelConverter<CurrencyModel, CurrencyUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CurrenciesServiceBase : ICurrenciesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CurrencyModel, CurrencyDto> _dtoConverter;
    private readonly IModelConverter<CurrencyModel, CurrencyCreateDto> _createDtoConverter;
    private readonly IModelConverter<CurrencyModel, CurrencyUpdateDto> _updateDtoConverter;

    protected CurrenciesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CurrencyModel, CurrencyDto> dtoConverter,
        IModelConverter<CurrencyModel, CurrencyCreateDto> createDtoConverter,
        IModelConverter<CurrencyModel, CurrencyUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CurrenciesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CurrencyModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CurrencyDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CurrencyModel>();
    }

    public async Task<EntityData<CurrencyModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<CurrencyDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<CurrencyModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CurrencyModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<CurrencyModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CurrencyDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CurrencyModel?> CreateAsync(CurrencyModel currency)
    {
        var item = await _httpClient.PostAsync<CurrencyCreateDto, CurrencyDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(currency));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CurrencyModel?> UpdateAsync(CurrencyModel currency)
    {
        if (currency.Etag != Guid.Empty)
        {
            string currentEtag = currency.Etag.ToString();

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
        if (currency.Id != null)
        {
            currentID = currency.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CurrencyUpdateDto, CurrencyDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(currency));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CurrencyModel currency)
    {
        if (currency.Etag != Guid.Empty)
        {
            string currentEtag = currency.Etag.ToString();

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
        if (currency.Id != null)
        {
            currentID = currency.Id.ToString();
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
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "CurrencyIsoNumeric",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Symbol",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "ThousandsSeparator",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "DecimalSeparator",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "SpaceBetweenAmountAndSymbol",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "SymbolOnLeft",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "DecimalDigits",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MajorName",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MajorSymbol",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MinorName",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MinorSymbol",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MinorToMajorValue",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DecimalDigits",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DecimalDigits",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CurrencyIsoNumeric",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CurrencyIsoNumeric",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Symbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Symbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "ThousandsSeparator",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "ThousandsSeparator",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DecimalSeparator",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DecimalSeparator",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "SpaceBetweenAmountAndSymbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "SpaceBetweenAmountAndSymbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "SymbolOnLeft",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "SymbolOnLeft",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DecimalDigits",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "DecimalDigits",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MajorName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MajorName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MajorSymbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MajorSymbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MinorName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MinorName",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MinorSymbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MinorSymbol",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MinorToMajorValue",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MinorToMajorValue",
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