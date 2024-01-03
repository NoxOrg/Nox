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
    public VolumeUnit VolumeUnit { get; set; } = VolumeUnit.CubicMeter;

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
        if (VolumeUnit == VolumeUnit.CubicMeter)
        {
            return VolumeUnit.CubicMeter.Symbol;
        }

        if (VolumeUnit == VolumeUnit.CubicFoot)
        {
            return VolumeUnit.CubicFoot.Symbol;
        }

        return String.Empty;
    }

    #endregion
}