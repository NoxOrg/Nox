using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class EmployeesDataGrid : ComponentBase
{
    private List<EmployeeModel> Employees = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            Employees = await EmployeesService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}