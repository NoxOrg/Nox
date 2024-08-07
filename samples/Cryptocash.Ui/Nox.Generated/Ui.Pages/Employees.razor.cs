﻿using Nox.Ui.Blazor.Lib.Components.Generic;
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

public partial class Employees : ComponentBase
{

    public ApiUiService CurrentApiUiService { get; set; } = new();

    private EmployeesDataGrid? referencedDataGrid;

    protected override void OnInitialized()
    {
        CurrentApiUiService = EmployeesService.IntialiseApiUiService();
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

    private bool IsOpenSearchFilterDrawer = false;

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

    private async Task AddEmployeeSubmit()
    {
        showAddDialog = false;        
        await Search();
    }
#endregion ADD
#region EDIT
    private bool showEditDialog = false;   
    
    [Parameter]
    public EmployeeModel? SelectedEntity { get; set; }   

    private void ShowEditDialog(EmployeeModel? currentSelected)
    {
        SelectedEntity = currentSelected;
        showEditDialog = true;
    }

    private void HideEditDialog()
    {
        showEditDialog = false;
    }

    private async Task EditEmployeeSubmit()
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
    public EmployeeModel? DeleteEntity { get; set; }   

    public DialogOptions ConfirmationDialogOptions { get; set; } = new()
    {
        BackgroundClass = "dialog-blur-class",
        BackdropClick = true,
        Position = DialogPosition.TopCenter,
        MaxWidth = MaxWidth.Medium
    };

    private void ShowDeleteConfirmation(EmployeeModel? currentSelected)
    {
        DeleteEntity = currentSelected;
        showDeleteDialog = true;
    }

    private void HideDeleteConfirmation()
    {
        showDeleteDialog = false;
    }

    private async Task DeleteEmployeeSubmit()
    {
        try
        {
            IsDeleteLoading = true;

            if (DeleteEntity != null)
            {
                await EmployeesService.DeleteAsync(DeleteEntity);
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