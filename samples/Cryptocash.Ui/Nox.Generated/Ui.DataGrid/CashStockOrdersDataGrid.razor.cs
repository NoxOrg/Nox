using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CashStockOrdersDataGrid : ComponentBase
{
    private List<CashStockOrderModel> CashStockOrders = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
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
}