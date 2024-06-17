using Nox.Ui.Blazor.Lib.Components.Generic;
using Nox.Ui.Blazor.Lib.Services;
using Nox.Ui.Blazor.Lib.Resources;
using Cryptocash.Ui.Forms.Add;
using Cryptocash.Ui.Forms.Edit;
using Cryptocash.Ui.DataGrid;
using Cryptocash.Ui.Models;
using NoxResources = Nox.Ui.Blazor.Lib.Resources.Resources;
using Cryptocash.Ui.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cryptocash.Ui.Pages;

public partial class CashStockOrders : ComponentBase
{

private CashStockOrdersDataGrid? referencedDataGrid;

#region ADD
    private bool showAddDialog = false;

    private void ShowAddDialog()
    {
        showAddDialog = true;
    }

    private void HideAddDialog()
    {
        showAddDialog = false;
    }

    private void AddCashStockOrderSubmit()
    {
        showAddDialog = false;        
        referencedDataGrid?.RefreshDataGrid();
    }
#endregion ADD
#region EDIT
    private bool showEditDialog = false;   
    
    [Parameter]
    public CashStockOrderModel? SelectedEntity { get; set; }   

    private void ShowEditDialog(CashStockOrderModel? currentSelected)
    {
        SelectedEntity = currentSelected;
        showEditDialog = true;
    }

    private void HideEditDialog()
    {
        showEditDialog = false;
    }

    private void EditCashStockOrderSubmit()
    {
        showEditDialog = false;    
        SelectedEntity = null;
        referencedDataGrid?.RefreshDataGrid();        
    }
#endregion EDIT
#region DELETE
    private bool showDeleteDialog = false; 
    
    private bool IsDeleteLoading = false;

    private bool HasDeleteError = false;
    
    [Parameter]
    public CashStockOrderModel? DeleteEntity { get; set; }   

    public DialogOptions ConfirmationDialogOptions { get; set; } = new()
    {
        ClassBackground = "dialog-blur-class",
        DisableBackdropClick = true,
        Position = DialogPosition.TopCenter,
        MaxWidth = MaxWidth.Medium
    };

    private void ShowDeleteConfirmation(CashStockOrderModel? currentSelected)
    {
        DeleteEntity = currentSelected;
        showDeleteDialog = true;
    }

    private void HideDeleteConfirmation()
    {
        showDeleteDialog = false;
    }

    private async Task DeleteCashStockOrderSubmit()
    {
        try
        {
            IsDeleteLoading = true;

            if (DeleteEntity != null)
            {
                await CashStockOrdersService.DeleteAsync(DeleteEntity);
            }
            else
            {
                HasDeleteError = true;
            }
        }
        catch
        {
            HasDeleteError = true;
        }
        finally
        {
            IsDeleteLoading = false;
            showDeleteDialog = false;    
            DeleteEntity = null;
            referencedDataGrid?.RefreshDataGrid(); 
        }               
    }
#endregion DELETE
}