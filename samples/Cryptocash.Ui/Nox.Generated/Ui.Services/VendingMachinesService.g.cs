// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface IVendingMachinesService
{
    public Task<List<VendingMachineModel>> GetAllAsync();
    public Task<EntityData<VendingMachineModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<VendingMachineModel?> GetByIdAsync(string id);
    public Task<VendingMachineModel?> CreateAsync(VendingMachineModel vendingMachine);
    public Task<VendingMachineModel?> UpdateAsync(VendingMachineModel vendingMachine);
    public Task DeleteAsync(VendingMachineModel vendingMachine);
    public ApiUiService IntialiseApiUiService();
}

internal partial class VendingMachinesService : VendingMachinesServiceBase
{
    public VendingMachinesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<VendingMachineModel, VendingMachineDto> dtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineCreateDto> createDtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class VendingMachinesServiceBase : IVendingMachinesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<VendingMachineModel, VendingMachineDto> _dtoConverter;
    private readonly IModelConverter<VendingMachineModel, VendingMachineCreateDto> _createDtoConverter;
    private readonly IModelConverter<VendingMachineModel, VendingMachineUpdateDto> _updateDtoConverter;

    protected VendingMachinesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<VendingMachineModel, VendingMachineDto> dtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineCreateDto> createDtoConverter,
        IModelConverter<VendingMachineModel, VendingMachineUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.VendingMachinesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<VendingMachineModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<VendingMachineDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<VendingMachineModel>();
    }

    public async Task<EntityData<VendingMachineModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<VendingMachineDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<VendingMachineModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<VendingMachineModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<VendingMachineModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<VendingMachineDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<VendingMachineModel?> CreateAsync(VendingMachineModel vendingMachine)
    {
        var item = await _httpClient.PostAsync<VendingMachineCreateDto, VendingMachineDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(vendingMachine));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<VendingMachineModel?> UpdateAsync(VendingMachineModel vendingMachine)
    {
        if (vendingMachine.Etag != Guid.Empty)
        {
            string currentEtag = vendingMachine.Etag.ToString();

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
        if (vendingMachine.Id != null)
        {
            currentID = vendingMachine.Id.ToString();
        }

        var item = await _httpClient.PutAsync<VendingMachineUpdateDto, VendingMachineDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(vendingMachine));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(VendingMachineModel vendingMachine)
    {
        if (vendingMachine.Etag != Guid.Empty)
        {
            string currentEtag = vendingMachine.Etag.ToString();

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
        if (vendingMachine.Id != null)
        {
            currentID = vendingMachine.Id.ToString();
        }

        await _httpClient.DeleteAsync($"{_apiBaseUrl}/{currentID}");
    }

    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.OrderList = new List<SortOrder>();
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "MacAddress",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "PublicIp",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "SerialNumber",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MacAddress",
                DisplayLabel = "MacAddress",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "MacAddress",
                DisplayLabel = "MacAddress",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PublicIp",
                DisplayLabel = "Public Ip",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "PublicIp",
                DisplayLabel = "Public Ip",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "GeoLocation",
                DisplayLabel = "GeoLocation",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "GeoLocation",
                DisplayLabel = "GeoLocation",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "StreetAddress",
                DisplayLabel = "Address",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "StreetAddress",
                DisplayLabel = "Address",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "SerialNumber",
                DisplayLabel = "Serial Number",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "SerialNumber",
                DisplayLabel = "Serial Number",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "InstallationFootPrint",
                DisplayLabel = "Installation Area",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "InstallationFootPrint",
                DisplayLabel = "Installation Area",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "RentPerSquareMetre",
                DisplayLabel = "Rent per Square Metre",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "RentPerSquareMetre",
                DisplayLabel = "Rent per Square Metre",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });               

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "MacAddress",
                DisplayLabel = "MacAddress",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "PublicIp",
                DisplayLabel = "Public Ip",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "GeoLocation",
                DisplayLabel = "GeoLocation",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "StreetAddress",
                DisplayLabel = "Address",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "SerialNumber",
                DisplayLabel = "Serial Number",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "InstallationFootPrint",
                DisplayLabel = "Installation Area",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "RentPerSquareMetre",
                DisplayLabel = "Rent per Square Metre",
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