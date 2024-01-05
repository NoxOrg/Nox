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
    public WeightUnit WeightUnit { get; set; } = WeightUnit.Kilogram;

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
        if (WeightUnit == WeightUnit.Pound)
        {
            return WeightUnit.Pound.Symbol;
        }

        if (WeightUnit == WeightUnit.Kilogram)
        {
            return WeightUnit.Kilogram.Symbol;
        }

        return String.Empty;
    }

    #endregion
}