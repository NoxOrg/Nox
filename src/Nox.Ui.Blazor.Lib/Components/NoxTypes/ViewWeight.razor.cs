using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewWeight : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Weight { get; set; }

    [Parameter]
    public WeightTypeUnit Units { get; set; } = WeightTypeUnit.Kilogram;

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayWeight
    {
        get
        {
            if (Weight != null
                && Weight >= 0)
            {
                return Weight?.ToString(Format) + " " + DisplayWeightUnit();
            }

            return String.Empty;
        }
    }

    private string DisplayWeightUnit()
    {
        if (Units == WeightTypeUnit.Pound)
        {
            return WeightUnit.Pound.Symbol;
        }

        if (Units == WeightTypeUnit.Kilogram)
        {
            return WeightUnit.Kilogram.Symbol;
        }

        return String.Empty;
    }

    #endregion
}