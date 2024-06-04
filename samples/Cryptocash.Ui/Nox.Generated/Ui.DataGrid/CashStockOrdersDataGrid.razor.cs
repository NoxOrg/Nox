using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CashStockOrdersDataGrid : ComponentBase
{
    private List<CashStockOrderModel> CashStockOrders = new(); 
    private bool IsLoading = true;

    [Parameter]
    public EventCallback<CashStockOrderModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<CashStockOrderModel?> OnDeleteChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
    {
        try
        {
            IsLoading = true;
            CashStockOrders = await CashStockOrdersService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }

    public async Task RefreshDataGrid()
    {
        await LoadData();
        StateHasChanged();
    }

    public async Task SelectedOnClick(CashStockOrderModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    public async Task DeleteOnClick(CashStockOrderModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }
}