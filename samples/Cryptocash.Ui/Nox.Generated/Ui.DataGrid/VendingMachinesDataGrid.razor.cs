﻿using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class VendingMachinesDataGrid : ComponentBase
{
    private List<VendingMachineModel> VendingMachines = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            VendingMachines = await VendingMachinesService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}