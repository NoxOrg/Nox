using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class CustomersDataGrid : ComponentBase
{
    private List<CustomerModel> Customers = new(); 
    private bool IsLoading = true;

    [Parameter]
    public EventCallback<CustomerModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<CustomerModel?> OnDeleteChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
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

    public async Task RefreshDataGrid()
    {
        await LoadData();
        StateHasChanged();
    }

    public async Task SelectedOnClick(CustomerModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    public async Task DeleteOnClick(CustomerModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }
}