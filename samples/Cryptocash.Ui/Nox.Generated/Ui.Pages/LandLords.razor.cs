using Nox.Ui.Blazor.Lib.Components.Generic;
using Nox.Ui.Blazor.Lib.Services;
using Nox.Ui.Blazor.Lib.Resources;
using Cryptocash.Ui.Forms.Add;
using Cryptocash.Ui.Forms.Edit;
using Cryptocash.Ui.DataGrid;
using Cryptocash.Ui.Models;
using Cryptocash.Ui.Data;
using NoxResources = Nox.Ui.Blazor.Lib.Resources.Resources;
using Cryptocash.Ui.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace Cryptocash.Ui.Pages;

public partial class LandLords : ComponentBase
{

    public ApiUiService CurrentApiUiService { get; set; } = new();

    private LandLordsDataGrid? referencedDataGrid;



    protected override void OnInitialized()
    {
        CurrentApiUiService = LandLordsService.IntialiseApiUiService();
    }

#region Paging

   public bool IsPagingPopulated
    {
        get
        {
            return CurrentApiUiService.Paging != null;
        }
    }

#endregion

#region Search

    private bool IsOpenSearchFilterDrawer = false;

    public string SearchMainValue { get; set; } = string.Empty;

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
        IsOpenSearchFilterDrawer = false;

        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.ResetPaging();
        }

        if (IsSearchFilterPopulated)
        {
            CurrentApiUiService!.ResetFilterSearchFilterList();
            CurrentApiUiService!.UpdateMainSearchFilterList(SearchMainValue);
            CurrentApiUiService!.UpdateFilterSearchFilterList();
        }

        if (referencedDataGrid != null)
        {
            await referencedDataGrid.RefreshDataGrid();
        }
    }

    public async Task SearchEnterSubmit(KeyboardEventArgs CurrentEvent)
    {
        if (CurrentEvent != null && referencedDataGrid != null && (CurrentEvent.Code == "Enter" || CurrentEvent.Code == "NumpadEnter"))
        {
            await Search();
        }
    }

    public void OpenSearchFilterDrawer(bool Open)
    {
        IsOpenSearchFilterDrawer = Open;
    }

    public async Task ApplySearchFilterList()
    {
        IsOpenSearchFilterDrawer = false;

        if (IsPagingPopulated)
        {
            CurrentApiUiService!.Paging!.ResetPaging();
        }

        if (IsSearchFilterPopulated)
        {
            SearchMainValue = string.Empty;
            CurrentApiUiService!.ResetMainSearchFilterList();
            CurrentApiUiService!.UpdateMainSearchFilterList(SearchMainValue);
            CurrentApiUiService!.UpdateFilterSearchFilterList();
        }

        if (referencedDataGrid != null)
        {
            await referencedDataGrid.RefreshDataGrid();
        }
    }

    public void ClearSearchFilter(MouseEventArgs CurrentValue, SearchFilter CurrentFilter)
    {
        if (CurrentFilter != null
            && CurrentValue != null
            && !string.IsNullOrWhiteSpace(CurrentFilter.PropertyName)
            && IsSearchFilterPopulated)
        {
            CurrentApiUiService!.UpdateSearchFilter(String.Empty, CurrentFilter);
        }
    }

    public void ClearMainSearchFilterList()
    {
        if (IsSearchFilterPopulated)
        {
            SearchMainValue = string.Empty;
            CurrentApiUiService!.ResetMainSearchFilterList();
        }
    }

#endregion

#region View

    private bool IsOpenViewDrawer = false;

    public bool IsViewPopulated
    {
        get
        {
            return CurrentApiUiService.ViewList != null
                    && CurrentApiUiService.ViewList.Count > 0;
        }
    }

    public void OpenViewDrawer(bool Open)
    {
        IsOpenViewDrawer = Open;
    }

    public void ApplyViewList()
    {
        IsOpenViewDrawer = false;

        if (IsViewPopulated)
        {
            CurrentApiUiService!.ApplyShowInSearchList();
        }
    }

    public void ResetViewList()
    {
        IsOpenViewDrawer = false;

        if (IsViewPopulated)
        {
            CurrentApiUiService!.ResetShowInSearchList();
        }
    }

#endregion    

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

    private async Task AddLandLordSubmit()
    {
        showAddDialog = false;        
        await Search();
    }
#endregion ADD
#region EDIT
    private bool showEditDialog = false;   
    
    [Parameter]
    public LandLordModel? SelectedEntity { get; set; }   

    private void ShowEditDialog(LandLordModel? currentSelected)
    {
        SelectedEntity = currentSelected;
        showEditDialog = true;
    }

    private void HideEditDialog()
    {
        showEditDialog = false;
    }

    private async Task EditLandLordSubmit()
    {
        showEditDialog = false;    
        SelectedEntity = null;
        await Search();        
    }
#endregion EDIT
#region DELETE
    private bool showDeleteDialog = false; 
    
    private bool IsDeleteLoading = false;

    private bool HasDeleteError = false;
    
    [Parameter]
    public LandLordModel? DeleteEntity { get; set; }   

    public DialogOptions ConfirmationDialogOptions { get; set; } = new()
    {
        ClassBackground = "dialog-blur-class",
        DisableBackdropClick = true,
        Position = DialogPosition.TopCenter,
        MaxWidth = MaxWidth.Medium
    };

    private void ShowDeleteConfirmation(LandLordModel? currentSelected)
    {
        DeleteEntity = currentSelected;
        showDeleteDialog = true;
    }

    private void HideDeleteConfirmation()
    {
        showDeleteDialog = false;
    }

    private async Task DeleteLandLordSubmit()
    {
        try
        {
            IsDeleteLoading = true;

            if (DeleteEntity != null)
            {
                await LandLordsService.DeleteAsync(DeleteEntity);
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
            await Search(); 
        }               
    }
#endregion DELETE
}