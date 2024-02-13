using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class PaymentDetailsDataGrid : ComponentBase
{
    private List<PaymentDetailModel> PaymentDetails = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            PaymentDetails = await PaymentDetailsService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}