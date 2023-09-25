using Cryptocash.Ui.Generated.Data.ApiSetting;
using Cryptocash.Ui.Generated.Data.Enum;
using Cryptocash.Ui.Generated.Data.Helper;

namespace Cryptocash.Ui.Generated.Data.Generic
{
    /// <summary>
    /// ApiUiService which defines and manages Api Data access and Search Filter, View, Order, Paging and Action Settings
    /// </summary>
    public class ApiUiService
    {
        #region Declarations

        /// <summary>
        /// Property Url used for access to target Api
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Property SearchFilterList for listing search filters used within Api search queries
        /// </summary>
        public List<SearchFilter>? SearchFilterList { get; set; }

        /// <summary>
        /// Property ViewList for listing view used with Ui datagrid to show or hide columns
        /// </summary>
        public List<ShowInSearchResultsOption>? ViewList { get; set; }

        /// <summary>
        /// Propery OrderList to define list of column order used to order Ui datagrid columns
        /// </summary>
        public List<SortOrder>? OrderList { get; set; }

        /// <summary>
        /// Property Paging to define Ui datagird pagination 
        /// </summary>
        public Paging? Paging { get; set; }

        #endregion

        #region Api

        /// <summary>
        /// Propery ApiQuery to define connection url to api including all query parameters
        /// </summary>
        public string ApiGetQuery
        {
            get
            {
                string MainSearchFilters = ApiSearchFilterQuery(SearchFilterLocation.MainSearch);
                string FilterSearchFilters = ApiSearchFilterQuery(SearchFilterLocation.FilterSearch);

                string RtnSearchFilters = string.Empty;
                if (!string.IsNullOrWhiteSpace(MainSearchFilters)
                    || !string.IsNullOrWhiteSpace(FilterSearchFilters))
                {
                    RtnSearchFilters += "&$filter=";

                    if (string.IsNullOrWhiteSpace(MainSearchFilters))
                    {
                        RtnSearchFilters += FilterSearchFilters;
                    }
                    else
                    {
                        RtnSearchFilters += MainSearchFilters;
                        if (!string.IsNullOrWhiteSpace(FilterSearchFilters))
                        {
                            RtnSearchFilters += " and " + FilterSearchFilters;
                        }
                    }
                }

                return Url
                    + ApiPagingQuery
                    + ApiOrderQuery
                    + RtnSearchFilters;
            }
        }

        /// <summary>
        /// Property ApiPagingQuery to define paging related Api query parameters
        /// </summary>
        public string ApiPagingQuery
        {
            get
            {
                string RtnQuery = "?$count=true";

                if (Paging != null)
                {
                    int? UseTop = Paging!.CurrentPageSize;
                    if (UseTop > 0)
                    {
                        RtnQuery += string.Format("&$top={0}", UseTop);
                    }
                    int? UseSkip = UseTop * Paging!.CurrentPage;
                    if (UseSkip > 0)
                    {
                        RtnQuery += string.Format("&$skip={0}", UseSkip);
                    }
                }

                return RtnQuery;
            }
        }

        /// <summary>
        /// Property ApiOrderQuery to define order related Api query parameters
        /// </summary>
        public string ApiOrderQuery
        {
            get
            {
                string RtnQuery = string.Empty;

                if (OrderList != null
                    && OrderList.Where(Order =>
                    Order?.CurrentOrderDirection == SortOrderDirection.Ascending
                    || Order?.CurrentOrderDirection == SortOrderDirection.Descending).Any())
                {
                    RtnQuery += "&$orderby=";

                    string OrderItem = string.Empty;

                    foreach (SortOrder? CurrentOrder in OrderList.Where(Order =>
                    Order?.CurrentOrderDirection == SortOrderDirection.Ascending
                    || Order?.CurrentOrderDirection == SortOrderDirection.Descending).ToList())
                    {
                        if (!string.IsNullOrWhiteSpace(OrderItem))
                        {
                            OrderItem += ", ";
                        }
                        OrderItem += CurrentOrder?.PropertyName;

                        if (CurrentOrder?.CurrentOrderDirection == SortOrderDirection.Ascending)
                        {
                            OrderItem += " asc";
                        }

                        if (CurrentOrder?.CurrentOrderDirection == SortOrderDirection.Descending)
                        {
                            OrderItem += " desc";
                        }
                    }

                    RtnQuery += OrderItem;
                }

                return RtnQuery;
            }
        }

        /// <summary>
        /// Method ApiSearchFilterQuery to define search related Api query parameters 
        /// Note: if Search Filter Location is MainSearch then use OR concatenation otherwise use AND concatenation for multiple search filters
        /// </summary>
        public string ApiSearchFilterQuery(SearchFilterLocation FilterLocation)
        {
            string RtnQuery = string.Empty;

            if (SearchFilterList != null)
            {
                bool FreshFilter = true;

                foreach (SearchFilter? CurrentFilter in SearchFilterList
                    .Where(SearchFilter => !string.IsNullOrWhiteSpace(SearchFilter?.CurrentSearchFilterValue)
                    && !string.IsNullOrWhiteSpace(SearchFilter?.PropertyName)
                    && SearchFilter.SearchFilterLocation == FilterLocation))
                {
                    if (FreshFilter)
                    {
                        FreshFilter = false;
                    }
                    else
                    {
                        if (FilterLocation == SearchFilterLocation.MainSearch)
                        {
                            RtnQuery += " or ";
                        }
                        else
                        {
                            RtnQuery += " and ";
                        }
                    }

                    switch (CurrentFilter?.SearchFilterType)
                    {
                        case SearchFilterType.Contains:

                            RtnQuery += string.Format("contains({0}, '{1}')", CurrentFilter?.PropertyName, CurrentFilter?.CurrentSearchFilterValue);
                            break;

                        case SearchFilterType.Eq:
                            RtnQuery += string.Format("{0} eq '{1}'", CurrentFilter?.PropertyName, CurrentFilter?.CurrentSearchFilterValue);
                            break;
                    }
                }
            }

            return RtnQuery;
        }

        /// <summary>
        /// Property ApiCreateQuery used to pass create Api Entity related query string params to Api
        /// </summary>
        public string ApiCreateQuery
        {
            get
            {
                return Url
                    + ApiCreateQueryData;
            }
        }

        /// <summary>
        /// Property ApiCreateQueryData used to store create Api Entity related params
        /// </summary>
        public string? ApiCreateQueryData { get; set; }

        #endregion

        #region SearchFilter

        /// <summary>
        /// Property to check search filter populated used to avoid nulls
        /// </summary>
        public bool IsSearchFilterPopulated
        {
            get
            {
                return SearchFilterList != null
                    && SearchFilterList.Any();
            }
        }

        /// <summary>
        /// Method to search for a search filter value 
        /// Note some Ui Controls require an IEnumerable<string> input as they possibly handle multiple selection
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public IEnumerable<string> GetSearchFilterValueList(SearchFilter? Filter)
        {
            if (Filter != null
                && IsSearchFilterPopulated)
            {
                SearchFilter? FoundFilter = SearchFilterList
                    !.FirstOrDefault(SearchFilter => string.Equals(SearchFilter.PropertyName, Filter.PropertyName, StringComparison.OrdinalIgnoreCase)
                    && SearchFilter.SearchFilterLocation.Equals(Filter.SearchFilterLocation));

                if (FoundFilter != null
                    && !string.IsNullOrWhiteSpace(FoundFilter.SetSearchFilterValue))
                {
                    List<string> FoundValue = new()
                    {
                        FoundFilter?.SetSearchFilterValue!
                    };
                    return FoundValue;
                }
            }

            return new List<string>().ToArray();
        }

        /// <summary>
        /// Method to search for a search filter value 
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public string GetSearchFilterValue(SearchFilter? Filter)
        {
            if (Filter != null
                && IsSearchFilterPopulated)
            {
                SearchFilter? FoundFilter = SearchFilterList
                    !.FirstOrDefault(SearchFilter => string.Equals(SearchFilter.PropertyName, Filter.PropertyName, StringComparison.OrdinalIgnoreCase)
                    && SearchFilter.SearchFilterLocation.Equals(Filter.SearchFilterLocation));

                if (FoundFilter != null
                    && !string.IsNullOrWhiteSpace(FoundFilter.SetSearchFilterValue))
                {
                    return FoundFilter?.SetSearchFilterValue!;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Property SearchLabel used to display search property names as a list on search text prompt
        /// </summary>
        public string SearchLabel
        {
            get
            {
                if (SearchFilterList != null)
                {
                    string RtnFilterNameList = string.Empty;

                    var SearchNameList = SearchFilterList!.Select(SearchFilter => SearchFilter.PropertyName).ToList();

                    var DistinctNameList = UtilityHelper.GetDistinctNameList(SearchNameList, true);

                    if (DistinctNameList != null)
                    {
                        foreach (string? CurrentFilter in DistinctNameList)
                        {
                            if (!string.IsNullOrWhiteSpace(CurrentFilter))
                            {
                                RtnFilterNameList += CurrentFilter + ", ";
                            }
                        }

                        return RtnFilterNameList.TrimEnd(new char[] { ',', ' ' });
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Method to update the current search filter with a new value
        /// </summary>
        /// <param name="CurrentValue"></param>
        /// <param name="CurrentFilter"></param>
        public void UpdateSearchFilter(string CurrentValue, SearchFilter CurrentFilter)
        {
            if (CurrentFilter != null
                && !string.IsNullOrWhiteSpace(CurrentFilter.PropertyName)
                && IsSearchFilterPopulated)
            {
                var Index = SearchFilterList!.FindIndex(Filter => Filter.PropertyName != null
                && Filter.PropertyName.Equals(CurrentFilter.PropertyName, StringComparison.OrdinalIgnoreCase)
                && Filter.SearchFilterLocation == SearchFilterLocation.FilterSearch);
                if (Index > -1)
                {
                    SearchFilterList?[Convert.ToInt32(Index)].UpdateSetSearchFilterValue(CurrentValue);
                }
            }
        }

        /// <summary>
        /// Method to update all main search textbox related search filters
        /// </summary>
        /// <param name="CurrentValue"></param>
        public void UpdateMainSearchFilterList(string CurrentValue)
        {
            if (IsSearchFilterPopulated)
            {
                for (int i = 0; i < SearchFilterList!.Count; i++)
                {
                    if (SearchFilterList[i].SearchFilterLocation == SearchFilterLocation.MainSearch)
                    {
                        SearchFilterList[i].CurrentSearchFilterValue = CurrentValue;
                    }
                }
            }
        }

        /// <summary>
        /// Method to update all filter popup related search filters
        /// </summary>
        /// <param name="CurrentValue"></param>
        public void UpdateFilterSearchFilterList()
        {
            if (IsSearchFilterPopulated)
            {
                for (int i = 0; i < SearchFilterList!.Count; i++)
                {
                    if (SearchFilterList[i].SearchFilterLocation == SearchFilterLocation.FilterSearch)
                    {
                        SearchFilterList[i].CurrentSearchFilterValue = SearchFilterList[i].SetSearchFilterValue;
                    }
                }
            }
        }

        /// <summary>
        /// Method to reset search filters related to filter popup
        /// </summary>
        public void ResetFilterSearchFilterList()
        {
            if (IsSearchFilterPopulated)
            {
                for (int i = 0; i < SearchFilterList!.Count; i++)
                {
                    if (SearchFilterList[i].SearchFilterLocation.Equals(SearchFilterLocation.FilterSearch))
                    {
                        SearchFilterList[i].ResetSearchFilter();
                    }
                }
            }
        }

        /// <summary>
        /// Method to reset search filters related to main search textbox
        /// </summary>
        public void ResetMainSearchFilterList()
        {
            if (IsSearchFilterPopulated)
            {
                for (int i = 0; i < SearchFilterList!.Count; i++)
                {
                    if (SearchFilterList[i].SearchFilterLocation.Equals(SearchFilterLocation.MainSearch))
                    {
                        SearchFilterList[i].ResetSearchFilter();
                    }
                }
            }
        }

        /// <summary>
        /// Method to reset all search filters
        /// </summary>
        public void ResetAllSearchFilterList()
        {
            if (IsSearchFilterPopulated)
            {
                ResetMainSearchFilterList();
                ResetFilterSearchFilterList();
            }
        }

        #endregion

        #region Order

        /// <summary>
        /// Property to check column order is populated used to avoid nulls
        /// </summary>
        public bool IsOrderPopulated
        {
            get
            {
                return OrderList != null
                     && OrderList.Any();
            }
        }

        /// <summary>
        /// method to reset the column order back to default settings
        /// </summary>
        public void ResetOrderList()
        {
            if (IsOrderPopulated)
            {
                for (int i = 0; i < OrderList!.Count; i++)
                {
                    OrderList[i].ResetOrderDirection();
                }
            }
        }

        /// <summary>
        /// Method to display the datagrid column as an ordered column
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>bool</returns>
        public bool IsPropertyOrdered(string PropertyName)
        {
            if (IsOrderPopulated)
            {
                return OrderList!.Any(Order => Order.PropertyName != null
                && Order.PropertyName.Equals(PropertyName, StringComparison.OrdinalIgnoreCase)
                && Order.CanSort);
            }

            return false;
        }

        /// <summary>
        /// Method to reset all other order when an order is set ensuring only one order active at a time
        /// </summary>
        /// <param name="PropertyName"></param>
        public void SwitchOffOtherOrderList(string PropertyName)
        {
            if (!string.IsNullOrWhiteSpace(PropertyName)
                && IsOrderPopulated)
            {
                for (int i = 0; i < OrderList!.Count; i++)
                {
                    var MatchName = OrderList![i].PropertyName?.Equals(PropertyName, StringComparison.OrdinalIgnoreCase);

                    if (MatchName != null
                        && MatchName == false
                        && OrderList[i].CanSort)
                    {
                        OrderList![i].UpdateCurrentOrderDirection(SortOrderDirection.None);
                    }
                }
            }
        }

        /// <summary>
        /// Method to return the current order type against a property
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>ApiOrderDirection?</returns>
        public SortOrderDirection? GetCurrentOrderType(string PropertyName)
        {
            if (!string.IsNullOrWhiteSpace(PropertyName)
                && IsOrderPopulated)
            {
                var Index = OrderList!.FindIndex(Order => Order.PropertyName != null
                && Order.PropertyName.Equals(PropertyName, StringComparison.OrdinalIgnoreCase));
                if (Index > -1)
                {
                    return OrderList?[Convert.ToInt32(Index)].CurrentOrderDirection;
                }
            }

            return null;
        }

        #endregion

        #region ShowInSearchResult

        /// <summary>
        /// Property to check view populated used to avoid nulls
        /// </summary>
        public bool IsShowInSearchPopulated
        {
            get
            {
                return ViewList != null
                     && ViewList.Any();
            }
        }

        /// <summary>
        /// Method to apply view settings to the Ui datagrid
        /// </summary>
        public void ApplyShowInSearchList()
        {
            if (IsShowInSearchPopulated)
            {
                for (int i = 0; i < ViewList!.Count; i++)
                {
                    ViewList![i].CurrentShowInSearchResultsOption = ViewList[i].SetShowInSearchResultsOption;
                }
            }
        }

        /// <summary>
        /// Method to reurn if property column is viewed and display in Ui datagrid
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>bool</returns>
        public bool IsPropertyShowInSearch(string PropertyName)
        {
            if (IsShowInSearchPopulated)
            {
                return ViewList!.Any(View => View.PropertyName != null
                && View.PropertyName.Equals(PropertyName)
                && (View.CurrentShowInSearchResultsOption.Equals(ShowInSearchResultsType.Always) || View.CurrentShowInSearchResultsOption.Equals(ShowInSearchResultsType.OptionalAndOnByDefault)));
            }

            return false;
        }

        /// <summary>
        /// Method to update the view with a new value
        /// </summary>
        /// <param name="IsViewValue"></param>
        /// <param name="CurrentView"></param>
        public void UpdateShowInSearch(bool IsViewValue, ShowInSearchResultsOption CurrentView)
        {
            if (CurrentView != null
                && !string.IsNullOrWhiteSpace(CurrentView.PropertyName)
                && IsShowInSearchPopulated)
            {
                var Index = ViewList!.FindIndex(View => View.PropertyName != null
                && View.PropertyName.Equals(CurrentView.PropertyName, StringComparison.OrdinalIgnoreCase));
                if (Index > -1)
                {
                    ShowInSearchResultsType CurrentShowInSearchResultsOptionType = ShowInSearchResultsType.OptionalAndOffByDefault;
                    if (IsViewValue)
                    {
                        CurrentShowInSearchResultsOptionType = ShowInSearchResultsType.OptionalAndOnByDefault;
                    }

                    ViewList![Convert.ToInt32(Index)].UpdateSetView(CurrentShowInSearchResultsOptionType);
                }
            }
        }

        /// <summary>
        /// Method to reset view on the Ui datagrid to default values
        /// </summary>
        public void ResetShowInSearchList()
        {
            if (IsShowInSearchPopulated)
            {
                for (int i = 0; i < ViewList!.Count; i++)
                {
                    ViewList![i].ResetView();
                }
            }
        }

        #endregion
    }
}