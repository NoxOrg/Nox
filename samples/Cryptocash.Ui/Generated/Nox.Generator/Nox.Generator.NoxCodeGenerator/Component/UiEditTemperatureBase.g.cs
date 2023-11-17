using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Nox.Types.Common;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditTemperatureBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Temperature { get; set; }

        [Parameter]
        public string Title { get; set; }

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
        public string AdornmentIcon { get; set; }     

        #endregion

        protected async Task OnTemperatureChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedDouble;
                Decimal.TryParse(newValue, out parsedDouble);

                Temperature = parsedDouble;
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
                return "<path d=\"m8.11,11.34c0,1.86-1.24,2.67-2.41,2.67-1.31,0-2.32-1-2.32-2.58,0-1.68,1.06-2.67,2.4-2.67s2.33,1.05,2.33,2.58Zm-3.84.05c0,1.1.61,1.93,1.47,1.93s1.47-.82,1.47-1.95c0-.85-.41-1.93-1.45-1.93s-1.49,1-1.49,1.95Z\"/><path d=\"m9.79,8.83h6.22v1.3h-4.73v3.99h4.37v1.28h-4.37v5.43h-1.49v-11.99Z\"/>";
            }

            if (TemperatureUnit == TemperatureUnit.Celsius)
            {
                return "<path d=\"m7.11,11.34c0,1.86-1.24,2.67-2.41,2.67-1.31,0-2.32-1-2.32-2.58,0-1.68,1.06-2.67,2.4-2.67s2.33,1.05,2.33,2.58Zm-3.84.05c0,1.1.61,1.93,1.47,1.93s1.47-.82,1.47-1.95c0-.85-.41-1.93-1.45-1.93s-1.49,1-1.49,1.95Z\"/><path d=\"m16.86,20.42c-.55.29-1.64.57-3.05.57-3.26,0-5.71-2.13-5.71-6.07s2.45-6.3,6.03-6.3c1.44,0,2.35.32,2.74.53l-.36,1.26c-.57-.28-1.37-.5-2.33-.5-2.71,0-4.51,1.8-4.51,4.95,0,2.94,1.63,4.82,4.44,4.82.91,0,1.83-.2,2.43-.5l.31,1.23Z\"/>";
            }

            return String.Empty;            
        }
    }
}