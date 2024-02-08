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
    public LengthTypeUnit Units { get; set; } = LengthTypeUnit.Meter;

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
        if (Units == LengthTypeUnit.Foot)
        {
            return LengthUnit.Foot.Symbol;
        }

        if (Units == LengthTypeUnit.Meter)
        {
            return LengthUnit.Meter.Symbol;
        }

        return String.Empty;
    }

    #endregion
}