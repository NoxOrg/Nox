using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CountriesDataGrid : ComponentBase
{
    private List<CountryModel> Countries = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            Countries = await CountriesService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}