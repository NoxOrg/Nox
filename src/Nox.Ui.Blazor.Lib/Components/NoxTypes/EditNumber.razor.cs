using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditNumber : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Number { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    [Parameter]
    public decimal? Minimum { get; set; }

    [Parameter]
    public decimal? Maximum { get; set; }

    [Parameter]
    public EventCallback<decimal?> NumberChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return Title + " is required";
        }
    }

    #endregion

    protected async Task OnNumberChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedInt))
        {
            Number = parsedInt;
        }
        else
        {
            Number = null;
        }

        await NumberChanged.InvokeAsync(Number);
    }
}