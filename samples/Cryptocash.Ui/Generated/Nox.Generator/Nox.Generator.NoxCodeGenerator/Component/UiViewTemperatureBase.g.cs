using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewTemperatureBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Temperature { get; set; }

        [Parameter]
        public TemperatureUnit TemperatureUnit { get; set; } = TemperatureUnit.Celsius;

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayTemperature { 
            
            get
            {
                if (Temperature != null)
                {
                    switch (Temperature)
                    {
                        case < 0:
                            float rtnMinusTemperature = 0;
                            return rtnMinusTemperature.ToString(Format) + DisplayTemperatureUnit();                        
                        default:
                            return Temperature?.ToString(Format) + DisplayTemperatureUnit();
                    }
                }

                return String.Empty;
            }
        }

        private string DisplayTemperatureUnit()
        {
            if (TemperatureUnit == TemperatureUnit.Fahrenheit)
            {
                return " " + TemperatureUnit.Fahrenheit.Symbol;
            }

            if (TemperatureUnit == TemperatureUnit.Celsius)
            {
                return " " + TemperatureUnit.Celsius.Symbol;
            }

            return String.Empty;
        }

        #endregion
    }
}