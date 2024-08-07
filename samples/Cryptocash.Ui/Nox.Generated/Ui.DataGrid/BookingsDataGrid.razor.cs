﻿using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Services;
using Cryptocash.Ui.Enum;
using MudBlazor;

namespace Cryptocash.Ui.DataGrid;

public partial class BookingsDataGrid : ComponentBase
{
    private List<BookingModel> BookingsData = new(); 

    public EntityData<BookingModel>? BookingEntityData { get; set; }

    private IEnumerable<BookingModel>? PagedData = null;

    private MudTable<BookingModel>? BookingDataGridTable;

    private bool IsLoading = true;

    [Parameter]
    public ApiUiService CurrentApiUiService { get; set; } = new();

    [Parameter]
    public EventCallback<BookingModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<BookingModel?> OnDeleteChanged { get; set; }    

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

    public async Task<TableData<BookingModel>> ServerReload(TableState State, CancellationToken cancellationToken)
    {
        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.SetCurrentPage(State.Page);
            CurrentApiUiService!.Paging!.SetCurrentPageSize(State.PageSize);
        }

        await GetApiEntityData();

        return new TableData<BookingModel>() { TotalItems = Convert.ToInt32(BookingEntityData?.EntityTotal), Items = PagedData };
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

        if (BookingEntityData == null
            || String.IsNullOrEmpty(PreviousAPiQuery)
            || !String.Equals(PreviousAPiQuery, CurrentApiQuery, StringComparison.OrdinalIgnoreCase))
        {
            BookingEntityData = await BookingsService!.GetAllFilteredPagedAsync(CurrentApiQuery);

            PreviousAPiQuery = CurrentApiQuery;

            if (IsPagingPopulated)
            {
                CurrentApiUiService!.Paging!.SetEntityTotal(BookingEntityData?.EntityTotal);
            }

            PagedData = BookingEntityData?.EntityList;
        }
    }

    #endregion

    #region Search

    public bool IsSearchFilterPopulated
    {
         get
        {
            return CurrentApiUiService.SearchFilterList != null
                && CurrentApiUiService.SearchFilterList.Count > 0;
        }
    }

    public async Task Search()
    {
        IsLoading = true;

        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.ResetPaging();
        }

        if (BookingDataGridTable != null)
        {
            await BookingDataGridTable!.ReloadServerData();
        }

        IsLoading = false;
    }

    #endregion

    #region Edit

    public async Task SelectedOnClick(BookingModel? currentSelection)
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
                    && CurrentApiUiService.OrderList.Count > 0;
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

            if (BookingDataGridTable != null)
            {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component. 
                BookingDataGridTable!.CurrentPage = 0; //only reliable way to reset page on reorder
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                await BookingDataGridTable!.ReloadServerData();
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

    public async Task DeleteOnClick(BookingModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }

    #endregion
}