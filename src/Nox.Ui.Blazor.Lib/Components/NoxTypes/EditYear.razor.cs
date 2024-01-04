using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditYear : ComponentBase
{

    #region Declarations

    [Parameter]
    public int? Year { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<int?> YearChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return Title + " is required";
        }
    }

    private readonly string Format = "####";

    #endregion

    protected async Task OnYearChanged(string newValue)
    {
        if (int.TryParse(newValue, out int parsedInt))
        {
            Year = parsedInt;
        }
        else
        {
            Year = null;
        }

        await YearChanged.InvokeAsync(Year);
    }
}