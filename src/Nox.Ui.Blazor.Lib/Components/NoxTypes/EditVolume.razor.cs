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
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public EventCallback<decimal?> VolumeChanged { get; set; }

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

    [Parameter]
    public VolumeTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public double MinValue { get; set; } = 0;

    [Parameter]
    public double MaxValue { get; set; } = 100;

    [Parameter]
    public VolumeTypeUnit Units { get; set; } = VolumeTypeUnit.CubicMeter;

    [Parameter]
    public VolumeTypeUnit PersistAs { get; set; } = VolumeTypeUnit.CubicMeter;

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
            Units = TypeOptions.Unit;
            PersistAs = TypeOptions.PersistAs;
        }
    }

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

        if (Units == VolumeTypeUnit.CubicFoot)
        {
            return Icon.VolumeUnit_CubicFoot;
        }

        if (Units == VolumeTypeUnit.CubicMeter)
        {
            return Icon.VolumeUnit_CubicMeter;
        }

        return String.Empty;
    }
}