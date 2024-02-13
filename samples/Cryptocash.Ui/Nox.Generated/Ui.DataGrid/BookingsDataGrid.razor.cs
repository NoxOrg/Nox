using Microsoft.AspNetCore.Components;

using Cryptocash.Ui.Models;

namespace Cryptocash.Ui.DataGrid;

public partial class BookingsDataGrid : ComponentBase
{
    private List<BookingModel> Bookings = new(); 
    private bool IsLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true;
            Bookings = await BookingsService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}