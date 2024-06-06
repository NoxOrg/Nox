using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class MinimumCashStocksDataGrid : ComponentBase
{
    private List<MinimumCashStockModel> MinimumCashStocks = new(); 
    private bool IsLoading = true;

    [Parameter]
    public EventCallback<MinimumCashStockModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<MinimumCashStockModel?> OnDeleteChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
    {
        try
        {
            IsLoading = true;
            MinimumCashStocks = await MinimumCashStocksService.GetAllAsync();
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

    public async Task SelectedOnClick(MinimumCashStockModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    public async Task DeleteOnClick(MinimumCashStockModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }
}