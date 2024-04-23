using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditTemperature : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Temperature { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public EventCallback<Decimal?> TemperatureChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    [Parameter]
    public string Format { get; set; } = "#.##";

    [Parameter]
    public string? AdornmentIcon { get; set; }

    [Parameter]
    public TemperatureTypeOptions? TypeOptions { get; set; }

    [Parameter]
    public TemperatureTypeUnit Units { get; set; } = TemperatureTypeUnit.Celsius;

    [Parameter]
    public TemperatureTypeUnit PersistAs { get; set; } = TemperatureTypeUnit.Celsius;

    #endregion

    protected override void OnInitialized()
    {
        if (TypeOptions is not null)
        {
            Units = TypeOptions.Units;
            PersistAs = TypeOptions.PersistAs;
        }
    }

    protected async Task OnTemperatureChanged(string newValue)
    {
        if (decimal.TryParse(newValue, out decimal parsedDecimal))
        {
            Temperature = parsedDecimal;
        }
        else
        {
            Temperature = null;
        }

        await TemperatureChanged.InvokeAsync(Temperature);
    }

    public string GetAdornmentIcon()
    {
        if (!string.IsNullOrWhiteSpace(AdornmentIcon))
        {
            return AdornmentIcon;
        }

        if (Units == TemperatureTypeUnit.Fahrenheit)
        {
            return Icon.TemperatureUnit_Fahrenheit;
        }

        if (Units == TemperatureTypeUnit.Celsius)
        {
            return Icon.TemperatureUnit_Celsius;
        }

        return String.Empty;
    }
}