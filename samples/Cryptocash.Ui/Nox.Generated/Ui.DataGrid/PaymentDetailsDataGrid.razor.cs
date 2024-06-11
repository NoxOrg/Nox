using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class PaymentDetailsDataGrid : ComponentBase
{
    private List<PaymentDetailModel> PaymentDetails = new(); 
    private bool IsLoading = true;

    [Parameter]
    public EventCallback<PaymentDetailModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<PaymentDetailModel?> OnDeleteChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
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

    public async Task RefreshDataGrid()
    {
        await LoadData();
        StateHasChanged();
    }

    public async Task SelectedOnClick(PaymentDetailModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    public async Task DeleteOnClick(PaymentDetailModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }
}