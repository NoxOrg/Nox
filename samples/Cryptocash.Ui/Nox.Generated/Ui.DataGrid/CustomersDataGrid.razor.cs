using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CustomersDataGrid : ComponentBase
{
    private List<CustomerModel> Customers = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            Customers = await CustomersService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}