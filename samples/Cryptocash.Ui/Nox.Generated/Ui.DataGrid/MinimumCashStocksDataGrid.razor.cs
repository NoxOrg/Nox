using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class MinimumCashStocksDataGrid : ComponentBase
{
    private List<MinimumCashStockModel> MinimumCashStocks = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
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
}