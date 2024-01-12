using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditWeight : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Weight { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public WeightUnit WeightUnit { get; set; } = WeightUnit.Kilogram;

    [Parameter]
    public EventCallback<decimal?> WeightChanged { get; set; }

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

    protected async Task OnWeightChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDecimal))
        {
            Weight = parsedDecimal;
        }
        else
        {
            Weight = null;
        }

        await WeightChanged.InvokeAsync(Weight);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (WeightUnit == WeightUnit.Pound)
        {
            return Icon.WeightUnit_Pound;
        }

        if (WeightUnit == WeightUnit.Kilogram)
        {
            return Icon.WeightUnit_Kilogram;
        }

        return String.Empty;
    }
}