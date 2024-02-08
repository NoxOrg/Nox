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
    public DistanceTypeUnit Units { get; set; } = DistanceTypeUnit.Kilometer;

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayDistance
    {
        get
        {
            if (Distance != null
                && Distance > 0)
            {
                return Distance?.ToString(Format) + " " + DisplayDistanceUnit();
            }

            return String.Empty;
        }
    }

    private string DisplayDistanceUnit()
    {
        if (Units == DistanceTypeUnit.Kilometer)
        {
            return DistanceUnit.Kilometer.Symbol;
        }

        if (Units == DistanceTypeUnit.Mile)
        {
            return DistanceUnit.Mile.Symbol;
        }

        return String.Empty;
    }

    #endregion
}