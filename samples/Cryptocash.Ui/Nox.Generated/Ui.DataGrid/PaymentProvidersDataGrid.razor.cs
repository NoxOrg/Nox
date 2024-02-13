using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class PaymentProvidersDataGrid : ComponentBase
{
    private List<PaymentProviderModel> PaymentProviders = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            PaymentProviders = await PaymentProvidersService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}