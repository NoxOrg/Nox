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
    public TemperatureUnit TemperatureUnit { get; set; } = TemperatureUnit.Celsius;

    [Parameter]
    public EventCallback<Decimal?> TemperatureChanged { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return Title + " is required";
        }
    }

    [Parameter]
    public string Format { get; set; } = "#.##";

    [Parameter]
    public string? AdornmentIcon { get; set; }

    #endregion

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

        if (TemperatureUnit == TemperatureUnit.Fahrenheit)
        {
            return Icon.TemperatureUnit_Fahrenheit;
        }

        if (TemperatureUnit == TemperatureUnit.Celsius)
        {
            return Icon.TemperatureUnit_Celsius;
        }

        return String.Empty;
    }
}