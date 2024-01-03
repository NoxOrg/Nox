using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditVolume : ComponentBase
{
    #region Declarations

    [Parameter]
    public decimal? Volume { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public VolumeUnit VolumeUnit { get; set; } = VolumeUnit.CubicMeter;

    [Parameter]
    public EventCallback<decimal?> VolumeChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return Title + " is required";
        }
    }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    [Parameter]
    public string? AdornmentIcon { get; set; }

    #endregion

    protected async Task OnVolumeChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDecimal))
        {
            Volume = parsedDecimal;
        }
        else
        {
            Volume = null;
        }

        await VolumeChanged.InvokeAsync(Volume);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (VolumeUnit == VolumeUnit.CubicFoot)
        {
            return Icon.VolumeUnit_CubicFoot;
        }

        if (VolumeUnit == VolumeUnit.CubicMeter)
        {
            return Icon.VolumeUnit_CubicMeter;
        }

        return String.Empty;
    }
}