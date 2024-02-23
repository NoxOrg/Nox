using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class LandLordsDataGrid : ComponentBase
{
    private List<LandLordModel> LandLords = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            LandLords = await LandLordsService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}