using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDistance : ComponentBase
{
    #region Declarations

    [Parameter]
    public Decimal? Distance { get; set; }

    [Parameter]
    public DistanceUnit DistanceUnit { get; set; } = DistanceUnit.Kilometer;

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayDistance
    {

        get
        {
            if (Distance != null)
            {
                switch (Distance)
                {
                    case < 0:
                        float rtnMinusDistance = 0;
                        return rtnMinusDistance.ToString(Format) + DisplayDistanceUnit();
                    default:
                        return Distance?.ToString(Format) + DisplayDistanceUnit();
                }
            }

            return String.Empty;
        }
    }

    private string DisplayDistanceUnit()
    {
        if (DistanceUnit == DistanceUnit.Kilometer)
        {
            return " " + DistanceUnit.Kilometer.Symbol;
        }

        if (DistanceUnit == DistanceUnit.Mile)
        {
            return " " + DistanceUnit.Mile.Symbol;
        }

        return String.Empty;
    }

    #endregion
}