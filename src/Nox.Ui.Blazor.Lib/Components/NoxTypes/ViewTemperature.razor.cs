using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewTemperature : ComponentBase
{
    #region Declarations

    [Parameter]
    public decimal? Temperature { get; set; }

    [Parameter]
    public TemperatureTypeUnit Units { get; set; } = TemperatureTypeUnit.Celsius;

    [Parameter]
    public string Format { get; set; } = "#.##";

    public string DisplayTemperature
    {

        get
        {
            if (Temperature.HasValue)
            {
                return Temperature.Value.ToString(Format) + " " + DisplayTemperatureUnit();
            }

            return String.Empty;
        }
    }

    private string DisplayTemperatureUnit()
    {
        if (Units == TemperatureTypeUnit.Fahrenheit)
        {
            return TemperatureUnit.Fahrenheit.Symbol;
        }

        if (Units == TemperatureTypeUnit.Celsius)
        {
            return TemperatureUnit.Celsius.Symbol;
        }

        return String.Empty;
    }

    #endregion
}