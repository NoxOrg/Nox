﻿using Microsoft.AspNetCore.Components;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using Cryptocash.Ui.Services;
using Cryptocash.Ui.Enum;
using MudBlazor;

namespace Cryptocash.Ui.DataGrid;

public partial class TransactionsDataGrid : ComponentBase
{
    private List<TransactionModel> TransactionsData = new(); 

    public EntityData<TransactionModel>? TransactionEntityData { get; set; }

    private IEnumerable<TransactionModel>? PagedData = null;

    private MudTable<TransactionModel>? TransactionDataGridTable;

    private bool IsLoading = true;

    [Parameter]
    public ApiUiService CurrentApiUiService { get; set; } = new();

    [Parameter]
    public EventCallback<TransactionModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<TransactionModel?> OnDeleteChanged { get; set; }    

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

    public async Task<TableData<TransactionModel>> ServerReload(TableState State, CancellationToken cancellationToken)
    {
        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.SetCurrentPage(State.Page);
            CurrentApiUiService!.Paging!.SetCurrentPageSize(State.PageSize);
        }

        await GetApiEntityData();

        return new TableData<TransactionModel>() { TotalItems = Convert.ToInt32(TransactionEntityData?.EntityTotal), Items = PagedData };
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

        if (TransactionEntityData == null
            || String.IsNullOrEmpty(PreviousAPiQuery)
            || !String.Equals(PreviousAPiQuery, CurrentApiQuery, StringComparison.OrdinalIgnoreCase))
        {
            TransactionEntityData = await TransactionsService!.GetAllFilteredPagedAsync(CurrentApiQuery);

            PreviousAPiQuery = CurrentApiQuery;

            if (IsPagingPopulated)
            {
                CurrentApiUiService!.Paging!.SetEntityTotal(TransactionEntityData?.EntityTotal);
            }

            PagedData = TransactionEntityData?.EntityList;
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

        if (TransactionDataGridTable != null)
        {
            await TransactionDataGridTable!.ReloadServerData();
        }

        IsLoading = false;
    }

    #endregion

    #region Edit

    public async Task SelectedOnClick(TransactionModel? currentSelection)
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

            if (TransactionDataGridTable != null)
            {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component. 
                TransactionDataGridTable!.CurrentPage = 0; //only reliable way to reset page on reorder
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                await TransactionDataGridTable!.ReloadServerData();
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

    public async Task DeleteOnClick(TransactionModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }

    #endregion
}