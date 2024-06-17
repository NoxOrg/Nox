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

public partial class Countries : ComponentBase
{

private CountriesDataGrid? referencedDataGrid;

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

    private void AddCountrySubmit()
    {
        showAddDialog = false;        
        referencedDataGrid?.RefreshDataGrid();
    }
#endregion ADD
#region EDIT
    private bool showEditDialog = false;   
    
    [Parameter]
    public CountryModel? SelectedEntity { get; set; }   

    private void ShowEditDialog(CountryModel? currentSelected)
    {
        SelectedEntity = currentSelected;
        showEditDialog = true;
    }

    private void HideEditDialog()
    {
        showEditDialog = false;
    }

    private void EditCountrySubmit()
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
    public CountryModel? DeleteEntity { get; set; }   

    public DialogOptions ConfirmationDialogOptions { get; set; } = new()
    {
        ClassBackground = "dialog-blur-class",
        DisableBackdropClick = true,
        Position = DialogPosition.TopCenter,
        MaxWidth = MaxWidth.Medium
    };

    private void ShowDeleteConfirmation(CountryModel? currentSelected)
    {
        DeleteEntity = currentSelected;
        showDeleteDialog = true;
    }

    private void HideDeleteConfirmation()
    {
        showDeleteDialog = false;
    }

    private async Task DeleteCountrySubmit()
    {
        try
        {
            IsDeleteLoading = true;

            if (DeleteEntity != null)
            {
                await CountriesService.DeleteAsync(DeleteEntity);
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