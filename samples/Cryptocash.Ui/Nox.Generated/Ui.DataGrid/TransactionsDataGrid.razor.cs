using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class TransactionsDataGrid : ComponentBase
{
    private List<TransactionModel> Transactions = new(); 
    private bool IsLoading = true;

    [Parameter]
    public EventCallback<TransactionModel?> OnSelectionChanged { get; set; }

    [Parameter]
    public EventCallback<TransactionModel?> OnDeleteChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
    {
        try
        {
            IsLoading = true;
            Transactions = await TransactionsService.GetAllAsync();
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

    public async Task SelectedOnClick(TransactionModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnSelectionChanged.InvokeAsync(currentSelection);
        }        
    }

    public async Task DeleteOnClick(TransactionModel? currentSelection)
    {
        if (currentSelection != null)
        {
            await OnDeleteChanged.InvokeAsync(currentSelection);
        }        
    }
}