// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ITransactionsService
{
    public Task<List<TransactionModel>> GetAllAsync();
    public Task<EntityData<TransactionModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<TransactionModel?> GetByIdAsync(string id);
    public Task<TransactionModel?> CreateAsync(TransactionModel transaction);
    public Task<TransactionModel?> UpdateAsync(TransactionModel transaction);
    public Task DeleteAsync(TransactionModel transaction);
    public ApiUiService IntialiseApiUiService();
}

internal partial class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<TransactionModel, TransactionDto> dtoConverter,
        IModelConverter<TransactionModel, TransactionCreateDto> createDtoConverter,
        IModelConverter<TransactionModel, TransactionUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class TransactionsServiceBase : ITransactionsService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<TransactionModel, TransactionDto> _dtoConverter;
    private readonly IModelConverter<TransactionModel, TransactionCreateDto> _createDtoConverter;
    private readonly IModelConverter<TransactionModel, TransactionUpdateDto> _updateDtoConverter;

    protected TransactionsServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<TransactionModel, TransactionDto> dtoConverter,
        IModelConverter<TransactionModel, TransactionCreateDto> createDtoConverter,
        IModelConverter<TransactionModel, TransactionUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.TransactionsUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<TransactionModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<TransactionDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<TransactionModel>();
    }

    public async Task<EntityData<TransactionModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<TransactionDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<TransactionModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<TransactionModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<TransactionModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<TransactionDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<TransactionModel?> CreateAsync(TransactionModel transaction)
    {
        var item = await _httpClient.PostAsync<TransactionCreateDto, TransactionDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(transaction));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<TransactionModel?> UpdateAsync(TransactionModel transaction)
    {
        if (transaction.Etag != Guid.Empty)
        {
            string currentEtag = transaction.Etag.ToString();

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
        if (transaction.Id != null)
        {
            currentID = transaction.Id.ToString();
        }

        var item = await _httpClient.PutAsync<TransactionUpdateDto, TransactionDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(transaction));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(TransactionModel transaction)
    {
        if (transaction.Etag != Guid.Empty)
        {
            string currentEtag = transaction.Etag.ToString();

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
        if (transaction.Id != null)
        {
            currentID = transaction.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "TransactionType",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "ProcessedOnDateTime",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Amount",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Reference",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "TransactionType",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "TransactionType",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "ProcessedOnDateTime",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "ProcessedOnDateTime",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
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
                PropertyName = "Reference",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Reference",
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