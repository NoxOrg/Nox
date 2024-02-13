using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CommissionsDataGrid : ComponentBase
{
    private List<CommissionModel> Commissions = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            Commissions = await CommissionsService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}