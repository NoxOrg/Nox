// Generated

#nullable enable

using Nox.Extensions;
using Nox.Ui.Blazor.Lib.Contracts;

using Cryptocash.Application.Dto;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Enum;

namespace Cryptocash.Ui.Services;

public interface ICountriesService
{
    public Task<List<CountryModel>> GetAllAsync();
    public Task<EntityData<CountryModel>?> GetAllFilteredPagedAsync(string? query);
    public Task<CountryModel?> GetByIdAsync(string id);
    public Task<CountryModel?> CreateAsync(CountryModel country);
    public Task<CountryModel?> UpdateAsync(CountryModel country);
    public Task DeleteAsync(CountryModel country);
    public ApiUiService IntialiseApiUiService();
}

internal partial class CountriesService : CountriesServiceBase
{
    public CountriesService(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CountryModel, CountryDto> dtoConverter,
        IModelConverter<CountryModel, CountryCreateDto> createDtoConverter,
        IModelConverter<CountryModel, CountryUpdateDto> updateDtoConverter)
        : base(httpClient, endpointsProvider, dtoConverter, createDtoConverter, updateDtoConverter)
    {
    }
}

internal abstract partial class CountriesServiceBase : ICountriesService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly IModelConverter<CountryModel, CountryDto> _dtoConverter;
    private readonly IModelConverter<CountryModel, CountryCreateDto> _createDtoConverter;
    private readonly IModelConverter<CountryModel, CountryUpdateDto> _updateDtoConverter;

    protected CountriesServiceBase(HttpClient httpClient, 
        IEndpointsProvider endpointsProvider,
        IModelConverter<CountryModel, CountryDto> dtoConverter,
        IModelConverter<CountryModel, CountryCreateDto> createDtoConverter,
        IModelConverter<CountryModel, CountryUpdateDto> updateDtoConverter)
    {
        _httpClient = httpClient;
        _apiBaseUrl = endpointsProvider.CountriesUrl;
        _dtoConverter = dtoConverter;
        _createDtoConverter = createDtoConverter;
        _updateDtoConverter = updateDtoConverter;
    }

    public async Task<List<CountryModel>> GetAllAsync()
    {
        var items = await _httpClient.GetODataCollectionResponseAsync<List<CountryDto>>(_apiBaseUrl);
        return items?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CountryModel>();
    }

    public async Task<EntityData<CountryModel>?> GetAllFilteredPagedAsync(string? query)
    {
        var items = await _httpClient.GetODataSimpleResponseAsync<EntityData<CountryDto>>(_apiBaseUrl + query);

        if (items != null)
        {
            EntityData<CountryModel> rtnItems = new();
            rtnItems.EntityTotal = items.EntityTotal;
            rtnItems.EntityList = items?.EntityList?.Select(i => _dtoConverter.ConvertToModel(i)).ToList() ?? new List<CountryModel>();

            return rtnItems;
        }

        return null;
    }

    public async Task<CountryModel?> GetByIdAsync(string id)
    {
        var item = await _httpClient.GetODataSimpleResponseAsync<CountryDto>($"{_apiBaseUrl}/{id}");
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CountryModel?> CreateAsync(CountryModel country)
    {
        var item = await _httpClient.PostAsync<CountryCreateDto, CountryDto>(_apiBaseUrl, _createDtoConverter.ConvertToDto(country));
        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task<CountryModel?> UpdateAsync(CountryModel country)
    {
        if (country.Etag != Guid.Empty)
        {
            string currentEtag = country.Etag.ToString();

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
        if (country.Id != null)
        {
            currentID = country.Id.ToString();
        }

        var item = await _httpClient.PutAsync<CountryUpdateDto, CountryDto>(_apiBaseUrl + $"/{currentID}", _updateDtoConverter.ConvertToDto(country));

        return item != null ? _dtoConverter.ConvertToModel(item) : null;
    }

    public async Task DeleteAsync(CountryModel country)
    {
        if (country.Etag != Guid.Empty)
        {
            string currentEtag = country.Etag.ToString();

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
        if (country.Id != null)
        {
            currentID = country.Id.ToString();
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
                PropertyName = "OfficialName",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "CountryIsoNumeric",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "CountryIsoAlpha3",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });
            rtnApiUiService.OrderList.Add(new SortOrder()
            {
                PropertyName = "Population",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            });

        rtnApiUiService.SearchFilterList = new List<SearchFilter>();
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Population",
                DisplayLabel = "Population",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Population",
                DisplayLabel = "Population",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Name",
                DisplayLabel = "Country Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Name",
                DisplayLabel = "Country Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "OfficialName",
                DisplayLabel = "Official Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "OfficialName",
                DisplayLabel = "Official Name",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CountryIsoNumeric",
                DisplayLabel = "Country Id",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CountryIsoNumeric",
                DisplayLabel = "Country Id",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CountryIsoAlpha3",
                DisplayLabel = "Country Code",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "CountryIsoAlpha3",
                DisplayLabel = "Country Code",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "GeoCoords",
                DisplayLabel = "Geo Coordinates",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "GeoCoords",
                DisplayLabel = "Geo Coordinates",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "StartOfWeek",
                DisplayLabel = "Start of Week",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "StartOfWeek",
                DisplayLabel = "Start of Week",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });
            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Population",
                DisplayLabel = "Population",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            });

            rtnApiUiService.SearchFilterList.Add(new SearchFilter()
            {
                PropertyName = "Population",
                DisplayLabel = "Population",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.FilterSearch
            });               

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption>();
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "FlagEmoji",
                DisplayLabel = "Flag Emoji",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "FlagSvg",
                DisplayLabel = "Flag SVG",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "FlagPng",
                DisplayLabel = "Flag PNG",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "CoatOfArmsSvg",
                DisplayLabel = "Coat of Arms SVG",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "CoatOfArmsPng",
                DisplayLabel = "Coat of Arms PNG",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "GoogleMapsUrl",
                DisplayLabel = "Google Maps URL",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "OpenStreetMapsUrl",
                DisplayLabel = "Open Street Maps URL",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOffByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "Name",
                DisplayLabel = "Country Name",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "OfficialName",
                DisplayLabel = "Official Name",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "CountryIsoNumeric",
                DisplayLabel = "Country Id",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "CountryIsoAlpha3",
                DisplayLabel = "Country Code",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "GeoCoords",
                DisplayLabel = "Geo Coordinates",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "StartOfWeek",
                DisplayLabel = "Start of Week",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            });
            rtnApiUiService.ViewList.Add(new ShowInSearchResultsOption()
            {
                PropertyName = "Population",
                DisplayLabel = "Population",
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