using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CountriesDataGrid : ComponentBase
{
    private List<CountryModel> Countries = new(); 
    private bool IsLoading = true;

    [Parameter]
    public EventCallback<CountryModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<CountryModel?> OnDeleteChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
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

    public async Task RefreshDataGrid()
    {
        await LoadData();
        StateHasChanged();
    }

    public async Task SelectedOnClick(CountryModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    public async Task DeleteOnClick(CountryModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }
}