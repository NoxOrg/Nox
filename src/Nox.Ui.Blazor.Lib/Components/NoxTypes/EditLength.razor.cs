using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditLength : ComponentBase
{

    #region Declarations

    [Parameter]
    public Decimal? Length { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public EventCallback<Decimal?> LengthChanged { get; set; }

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
    public LengthTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public double MinValue { get; set; } = 0;

    [Parameter]
    public double MaxValue { get; set; } = 100;

    [Parameter]
    public LengthTypeUnit Units { get; set; } = LengthTypeUnit.Meter;

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
            Units = TypeOptions.Units;
        }
    }

    protected async Task OnLengthChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDouble))
        { 
            Length = parsedDouble;
        }
        else
        {
            Length = null;
        }

        await LengthChanged.InvokeAsync(Length);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (Units == LengthTypeUnit.Foot)
        {
            return Icon.LengthUnit_Foot;
        }

        if (Units == LengthTypeUnit.Meter)
        {
            return Icon.LengthUnit_Meter;
        }

        return String.Empty;

    }
}