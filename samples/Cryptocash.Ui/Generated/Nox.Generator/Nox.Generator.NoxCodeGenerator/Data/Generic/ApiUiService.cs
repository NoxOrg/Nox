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
        /// Property Name used for target Api name display on Ui
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Property IsDefault used for which ApiUiService is the default one to display in Ui
        /// </summary>
        public bool IsDefault { get; set; } = false;

        /// <summary>
        /// Property Url used for access to target Api
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Property Icon used for display of Api navigation link
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Property Link used for href of Api navigation link
        /// </summary>
        public string? PageLink { get; set; }

        /// <summary>
        /// Property UiActionOptionList used to define if Api overall handles Add, Edit or Delete actions
        /// </summary>
        public List<ApiUiActionType>? UiActionOptionList { get; set; }

        /// <summary>
        /// Property SearchFilterList for listing search filters used within Api search queries
        /// </summary>
        public List<ApiSearchFilter>? SearchFilterList { get; set; }

        /// <summary>
        /// Property ViewList for listing view used with Ui datagrid to show or hide columns
        /// </summary>
        public List<ApiView>? ViewList { get; set; }

        /// <summary>
        /// Propery OrderList to define list of column order used to order Ui datagrid columns
        /// </summary>
        public List<ApiOrder>? OrderList { get; set; }

        /// <summary>
        /// Property Paging to define Ui datagird pagination 
        /// </summary>
        public ApiPaging? Paging { get; set; }

        #endregion

        #region Api

        /// <summary>
        /// Propery ApiQuery to define connection url to api including all query parameters
        /// </summary>
        public string ApiGetQuery
        {
            get
            {
                string MainSearchFilters = ApiSearchFilterQuery(ApiSearchFilterLocation.MainSearch);
                string FilterSearchFilters = ApiSearchFilterQuery(ApiSearchFilterLocation.FilterSearch);

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
                    Order?.CurrentOrderDirection == ApiOrderDirection.Ascending
                    || Order?.CurrentOrderDirection == ApiOrderDirection.Descending).Any())
                {
                    RtnQuery += "&$orderby=";

                    string OrderItem = string.Empty;

                    foreach (ApiOrder? CurrentOrder in OrderList.Where(Order =>
                    Order?.CurrentOrderDirection == ApiOrderDirection.Ascending
                    || Order?.CurrentOrderDirection == ApiOrderDirection.Descending).ToList())
                    {
                        if (!string.IsNullOrWhiteSpace(OrderItem))
                        {
                            OrderItem += ", ";
                        }
                        OrderItem += CurrentOrder?.PropertyName;

                        if (CurrentOrder?.CurrentOrderDirection == ApiOrderDirection.Ascending)
                        {
                            OrderItem += " asc";
                        }

                        if (CurrentOrder?.CurrentOrderDirection == ApiOrderDirection.Descending)
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
        public string ApiSearchFilterQuery(ApiSearchFilterLocation FilterLocation)
        {
            string RtnQuery = string.Empty;

            if (SearchFilterList != null)
            {
                bool FreshFilter = true;

                foreach (ApiSearchFilter? CurrentFilter in SearchFilterList
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
                        if (FilterLocation == ApiSearchFilterLocation.MainSearch)
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
                        case ApiSearchFilterType.Contains:

                            RtnQuery += string.Format("contains({0}, '{1}')", CurrentFilter?.PropertyName, CurrentFilter?.CurrentSearchFilterValue);
                            break;

                        case ApiSearchFilterType.Eq:
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
        public IEnumerable<string> GetSearchFilterValueList(ApiSearchFilter? Filter)
        {
            if (Filter != null
                && IsSearchFilterPopulated)
            {
                ApiSearchFilter? FoundFilter = SearchFilterList
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
        public string GetSearchFilterValue(ApiSearchFilter? Filter)
        {
            if (Filter != null
                && IsSearchFilterPopulated)
            {
                ApiSearchFilter? FoundFilter = SearchFilterList
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
        public void UpdateSearchFilter(string CurrentValue, ApiSearchFilter CurrentFilter)
        {
            if (CurrentFilter != null
                && !string.IsNullOrWhiteSpace(CurrentFilter.PropertyName)
                && IsSearchFilterPopulated)
            {
                var Index = SearchFilterList!.FindIndex(Filter => Filter.PropertyName != null
                && Filter.PropertyName.Equals(CurrentFilter.PropertyName, StringComparison.OrdinalIgnoreCase)
                && Filter.SearchFilterLocation == ApiSearchFilterLocation.FilterSearch);
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
                    if (SearchFilterList[i].SearchFilterLocation == ApiSearchFilterLocation.MainSearch)
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
                    if (SearchFilterList[i].SearchFilterLocation == ApiSearchFilterLocation.FilterSearch)
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
                    if (SearchFilterList[i].SearchFilterLocation.Equals(ApiSearchFilterLocation.FilterSearch))
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
                    if (SearchFilterList[i].SearchFilterLocation.Equals(ApiSearchFilterLocation.MainSearch))
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
                && Order.OrderType.Equals(ApiOrderType.Ordered));
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
                        && OrderList[i].OrderType.Equals(ApiOrderType.Ordered))
                    {
                        OrderList![i].UpdateCurrentOrderDirection(ApiOrderDirection.None);
                    }
                }
            }
        }

        /// <summary>
        /// Method to return the current order type against a property
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>ApiOrderDirection?</returns>
        public ApiOrderDirection? GetCurrentOrderType(string PropertyName)
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

        #region View

        /// <summary>
        /// Property to check view populated used to avoid nulls
        /// </summary>
        public bool IsViewPopulated
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
        public void ApplyViewList()
        {
            if (IsViewPopulated)
            {
                for (int i = 0; i < ViewList!.Count; i++)
                {
                    ViewList![i].CurrentView = ViewList[i].SetView;
                }
            }
        }

        /// <summary>
        /// Method to reurn if property column is viewed and display in Ui datagrid
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <returns>bool</returns>
        public bool IsPropertyViewable(string PropertyName)
        {
            if (IsViewPopulated)
            {
                return ViewList!.Any(View => View.PropertyName != null
                && View.PropertyName.Equals(PropertyName)
                && View.CurrentView.Equals(ApiViewType.Displayed));
            }

            return false;
        }

        /// <summary>
        /// Method to update the view with a new value
        /// </summary>
        /// <param name="IsViewValue"></param>
        /// <param name="CurrentView"></param>
        public void UpdateView(bool IsViewValue, ApiView CurrentView)
        {
            if (CurrentView != null
                && !string.IsNullOrWhiteSpace(CurrentView.PropertyName)
                && IsViewPopulated)
            {
                var Index = ViewList!.FindIndex(View => View.PropertyName != null
                && View.PropertyName.Equals(CurrentView.PropertyName, StringComparison.OrdinalIgnoreCase));
                if (Index > -1)
                {
                    ViewList![Convert.ToInt32(Index)].UpdateSetView(
                        IsViewValue
                        && CurrentView.ViewOptionList != null
                        && CurrentView.ViewOptionList.Contains(ApiViewType.Displayed)
                        ? ApiViewType.Displayed
                : ApiViewType.Hidden);
                }
            }
        }

        /// <summary>
        /// Method to reset view on the Ui datagrid to default values
        /// </summary>
        public void ResetViewList()
        {
            if (IsViewPopulated)
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