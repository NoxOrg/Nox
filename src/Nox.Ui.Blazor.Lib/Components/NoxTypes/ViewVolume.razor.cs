using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewVolume : ComponentBase
{

    #region Declarations

    [Parameter]
    public Decimal? Volume { get; set; }

    [Parameter]
    public VolumeTypeUnit Units { get; set; } = VolumeTypeUnit.CubicMeter;

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayVolume
    {

        get
        {
            if (Volume != null
                && Volume >= 0)
            {
                return Volume?.ToString(Format) + " " + DisplayVolumeUnit();
            }

            return String.Empty;
        }
    }

    private string DisplayVolumeUnit()
    {
        if (Units == VolumeTypeUnit.CubicMeter)
        {
            return VolumeUnit.CubicMeter.Symbol;
        }

        if (Units == VolumeTypeUnit.CubicFoot)
        {
            return VolumeUnit.CubicFoot.Symbol;
        }

        return String.Empty;
    }

    #endregion
}