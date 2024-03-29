﻿using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class TransactionsDataGrid : ComponentBase
{
    private List<TransactionModel> Transactions = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
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
}