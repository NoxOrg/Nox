using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Services;
using Cryptocash.Ui.Enum;
using MudBlazor;

namespace Cryptocash.Ui.DataGrid;

public partial class CustomersDataGrid : ComponentBase
{
    private List<CustomerModel> CustomersData = new(); 

    public EntityData<CustomerModel>? CustomerEntityData { get; set; }

    public IEnumerable<CustomerModel>? PagedData = null;

    public MudTable<CustomerModel>? CustomerDataGridTable;

    private bool IsLoading = true;

    [Parameter]
    public ApiUiService CurrentApiUiService { get; set; } = new();

    [Parameter]
    public EventCallback<CustomerModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<CustomerModel?> OnDeleteChanged { get; set; }    

    private string PreviousAPiQuery = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        IsLoading = true;

        CurrentApiUiService.ResetAllSearchFilterList();
        CurrentApiUiService.ResetOrderList();  
        CurrentApiUiService.ResetShowInSearchList();

        await Search();

        IsLoading = false;
    }

    public async Task RefreshDataGrid()
    {
        PreviousAPiQuery = String.Empty;
        await Search();
        StateHasChanged();
    }

    #region Data

    public async Task<TableData<CustomerModel>> ServerReload(TableState State)
    {
        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.SetCurrentPage(State.Page);
            CurrentApiUiService!.Paging!.SetCurrentPageSize(State.PageSize);
        }

        await GetApiEntityData();

        return new TableData<CustomerModel>() { TotalItems = Convert.ToInt32(CustomerEntityData?.EntityTotal), Items = PagedData };
    }

    public bool IsPagingPopulated
    {
        get
        {
            return CurrentApiUiService.Paging != null;
        }
    }

    private async Task GetApiEntityData()
    {
        string CurrentApiQuery = CurrentApiUiService!.ApiGetQuery;

        if (CustomerEntityData == null
            || String.IsNullOrEmpty(PreviousAPiQuery)
            || !String.Equals(PreviousAPiQuery, CurrentApiQuery, StringComparison.OrdinalIgnoreCase))
        {
            CustomerEntityData = await CustomersService!.GetAllFilteredPagedAsync(CurrentApiQuery);

            PreviousAPiQuery = CurrentApiQuery;

            if (IsPagingPopulated)
            {
                CurrentApiUiService!.Paging!.SetEntityTotal(CustomerEntityData?.EntityTotal);
            }

            PagedData = CustomerEntityData?.EntityList;
        }
    }

    #endregion

    #region Search

    public bool IsSearchFilterPopulated
    {
        get
        {
            return CurrentApiUiService.SearchFilterList != null
                && CurrentApiUiService.SearchFilterList.Any();
        }
    }

    public async Task Search()
    {
        IsLoading = true;

        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.ResetPaging();
        }

        if (CustomerDataGridTable != null)
        {
            await CustomerDataGridTable!.ReloadServerData();
        }

        IsLoading = false;
    }

    #endregion

    #region Edit

    public async Task SelectedOnClick(CustomerModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    #endregion

    #region Order

    public bool IsOrderPopulated
    {
        get
        {
            return CurrentApiUiService.OrderList != null
                    && CurrentApiUiService.OrderList.Any();
        }
    }

    public async Task UpdateOrder(string OrderTypeValue, string PropertyName)
    {
        IsLoading = true;

        if (!string.IsNullOrWhiteSpace(PropertyName)
            && IsOrderPopulated)
        {
            var Index = CurrentApiUiService!.OrderList!.FindIndex(Order =>
            Order.PropertyName != null
            && Order.PropertyName.Equals(PropertyName, StringComparison.OrdinalIgnoreCase));
            if (Index > -1)
            {
                SortOrderDirection OrderType = SortOrderDirection.None;
                switch (OrderTypeValue.ToLower())
                {
                    case "ascending":
                        OrderType = SortOrderDirection.Ascending;
                        break;
                    case "descending":
                        OrderType = SortOrderDirection.Descending;
                        break;
                }
                CurrentApiUiService.OrderList?[Convert.ToInt32(Index)].UpdateCurrentOrderDirection(OrderType);
            }

            CurrentApiUiService!.SwitchOffOtherOrderList(PropertyName);

            if (CustomerDataGridTable != null)
            {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component. 
                CustomerDataGridTable!.CurrentPage = 0; //only reliable way to reset page on reorder
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                await CustomerDataGridTable!.ReloadServerData();
            }
        }

        IsLoading = false;
    }

    public SortDirection GetPropertyMudSortDirection(string PropertyName)
    {
        SortDirection GetSortDirection = SortDirection.None;

        if (IsOrderPopulated)
        {
            switch (CurrentApiUiService!.GetCurrentOrderType(PropertyName))
            {
                case SortOrderDirection.Ascending:
                    GetSortDirection = SortDirection.Ascending;
                    break;
                case SortOrderDirection.Descending:
                    GetSortDirection = SortDirection.Descending;
                    break;
            }
        }

        return GetSortDirection;
    }

    #endregion

    #region Delete

    public async Task DeleteOnClick(CustomerModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }

    #endregion
}