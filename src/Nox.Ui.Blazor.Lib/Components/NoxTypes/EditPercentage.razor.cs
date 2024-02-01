using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditPercentage : ComponentBase
{
    #region Declarations

    [Parameter]
    public float? Percentage { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<float?> PercentageChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    [Parameter]
    public string Format { get; set; } = "#.##";

    [Parameter]
    public string AdornmentIcon { get; set; } = Icon.Percentage;

    #endregion

    protected async Task OnPercentageChanged(string newValue)
    {
        if (float.TryParse(newValue, out float parsedValue))
        {
            Percentage = parsedValue;
        }
        else
        {
            Percentage = null;
        }

        await PercentageChanged.InvokeAsync(Percentage);
    }
}