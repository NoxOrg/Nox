// Generated

using System.Collections.Generic;
using System;

using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.ApiSetting;
using Cryptocash.Ui.Generated.Data.Enum;

namespace Cryptocash.Ui.Generated.Data.Generic.VendingMachineService;

/// <summary>
/// Bespoke Class generated by Nox.Generator used to define ApiUiService and Get Api results
/// </summary>
public class VendingMachineService : IEntityService
{
    /// <summary>
    /// Bespoke Class generated by Nox.Generator used to define ApiUiService which defines URL access and Search Filter, View, Order, Paging and Action settings
    /// </summary>
    public ApiUiService IntialiseApiUiService()
    {
        ApiUiService rtnApiUiService = new();

        rtnApiUiService.Url = "https://localhost:44310/api/VendingMachines";

        rtnApiUiService.OrderList = new List<SortOrder> {
            new SortOrder()
            {
                PropertyName = "SerialNumber",
                DefaultOrderDirection = SortOrderDirection.Descending,
                CanSort = true
            },
            new SortOrder()
            {
                PropertyName = "MacAddress",
                DefaultOrderDirection = SortOrderDirection.None,
                CanSort = true
            },
            new SortOrder()
            {
                PropertyName = "PublicIp",
                DefaultOrderDirection = SortOrderDirection.None,
                CanSort = true
            }
        };

        rtnApiUiService.SearchFilterList = new List<SearchFilter> {
            new SearchFilter()
            {
                PropertyName = "SerialNumber",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            },
            new SearchFilter()
            {
                PropertyName = "MacAddress",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            },
            new SearchFilter()
            {
                PropertyName = "PublicIp",
                SearchFilterType = SearchFilterType.Contains,
                SearchFilterLocation = SearchFilterLocation.MainSearch
            },
            new SearchFilter()
            {
                PropertyName = "SerialNumber",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.FilterSearch,
            },
            new SearchFilter()
            {
                PropertyName = "MacAddress",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.FilterSearch,
            },
            new SearchFilter()
            {
                PropertyName = "PublicIp",
                SearchFilterType = SearchFilterType.Eq,
                SearchFilterLocation = SearchFilterLocation.FilterSearch,
            }
        };        

        rtnApiUiService.ViewList = new List<ShowInSearchResultsOption> {
            new ShowInSearchResultsOption() {
                PropertyName = "SerialNumber",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.Always
            },
            new ShowInSearchResultsOption() {
                PropertyName = "MacAddress",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            },
            new ShowInSearchResultsOption() {
                PropertyName = "PublicIp",
                DefaultShowInSearchResultsOption = ShowInSearchResultsType.OptionalAndOnByDefault
            }
        };

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