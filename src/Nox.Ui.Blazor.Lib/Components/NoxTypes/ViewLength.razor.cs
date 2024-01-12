using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewLength : ComponentBase
{
    #region Declarations

    [Parameter]
    public Decimal? Length { get; set; }

    [Parameter]
    public LengthUnit LengthUnit { get; set; } = LengthUnit.Meter;

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayLength
    {

        get
        {
            if (Length != null
                && Length > 0)
            {
                return Length?.ToString(Format) + " " + DisplayLengthUnit();
            }

            return String.Empty;
        }
    }

    private string DisplayLengthUnit()
    {
        if (LengthUnit == LengthUnit.Foot)
        {
            return LengthUnit.Foot.Symbol;
        }

        if (LengthUnit == LengthUnit.Meter)
        {
            return LengthUnit.Meter.Symbol;
        }

        return String.Empty;
    }

    #endregion
}