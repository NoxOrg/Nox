using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CurrenciesDataGrid : ComponentBase
{
    private List<CurrencyModel> Currencies = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            Currencies = await CurrenciesService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}