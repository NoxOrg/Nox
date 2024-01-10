using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDistance : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Distance { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public DistanceUnit DistanceUnit { get; set; } = DistanceUnit.Kilometer;

    [Parameter]
    public EventCallback<decimal?> DistanceChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    [Parameter]
    public string? AdornmentIcon { get; set; }

    #endregion

    protected async Task OnDistanceChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDouble))
        { 

            Distance = parsedDouble;
        }
        else
        {
            Distance = null;
        }

        await DistanceChanged.InvokeAsync(Distance);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (DistanceUnit == DistanceUnit.Mile)
        {
            return Icon.DistanceUnit_Mile;
        }

        if (DistanceUnit == DistanceUnit.Kilometer)
        {
            return Icon.DistanceUnit_Kilometer;
        }

        return String.Empty;
    }
}