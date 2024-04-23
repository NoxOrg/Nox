using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditWeight : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Weight { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public EventCallback<decimal?> WeightChanged { get; set; }

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
    public WeightTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public double MinValue { get; set; } = 0;

    [Parameter]
    public double MaxValue { get; set; } = 100;

    [Parameter]
    public WeightTypeUnit Units { get; set; } = WeightTypeUnit.Kilogram;

    [Parameter]
    public WeightTypeUnit PersistAs { get; set; } = WeightTypeUnit.Kilogram;

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            MinValue = TypeOptions.MinValue;
            MaxValue = TypeOptions.MaxValue;
            Units = TypeOptions.Units;
            PersistAs = TypeOptions.PersistAs;
        }
    }

    protected async Task OnWeightChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDecimal))
        {
            Weight = parsedDecimal;
        }
        else
        {
            Weight = null;
        }

        await WeightChanged.InvokeAsync(Weight);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (Units == WeightTypeUnit.Pound)
        {
            return Icon.WeightUnit_Pound;
        }

        if (Units == WeightTypeUnit.Kilogram)
        {
            return Icon.WeightUnit_Kilogram;
        }

        return String.Empty;
    }
}