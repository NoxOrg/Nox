using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Nox.Types.Common;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditDistanceBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Distance { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public DistanceUnit DistanceUnit { get; set; } = DistanceUnit.Kilometer;

        [Parameter]
        public EventCallback<Decimal?> DistanceChanged { get; set; }

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

        protected async Task OnDistanceChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedDouble;
                Decimal.TryParse(newValue, out parsedDouble);

                Distance = parsedDouble;
            }
            else
            {
                Distance = null;
            }            

            await DistanceChanged.InvokeAsync(Distance);
        }

        public string GetAdornmentIcon()
        {
            if (!string.IsNullOrWhiteSpace(AdornmentIcon))
            {
                return AdornmentIcon;
            }

            if (DistanceUnit == DistanceUnit.Mile)
            {
                return "<path d=\"m3.26,12.3c0-.89-.02-1.62-.07-2.33h1.32l.07,1.39h.05c.46-.82,1.23-1.58,2.6-1.58,1.13,0,1.99.71,2.35,1.73h.03c.26-.48.58-.85.93-1.12.5-.39,1.04-.6,1.83-.6,1.1,0,2.72.75,2.72,3.74v5.07h-1.47v-4.88c0-1.65-.58-2.65-1.8-2.65-.86,0-1.53.66-1.78,1.42-.07.21-.12.5-.12.78v5.32h-1.47v-5.16c0-1.37-.58-2.37-1.73-2.37-.94,0-1.63.78-1.87,1.57-.09.23-.12.5-.12.76v5.2h-1.47v-6.28Z\"/><path d=\"m19.24,7.55c.02.53-.36.96-.96.96-.53,0-.91-.43-.91-.96s.39-.98.94-.98.93.43.93.98Zm-1.68,11.03v-8.61h1.51v8.61h-1.51Z\"/>";
            }

            if (DistanceUnit == DistanceUnit.Kilometer)
            {
                return "<path d=\"m2.75,13.92h.03c.21-.3.5-.68.74-.98l2.43-2.97h1.82l-3.2,3.54,3.65,5.07h-1.83l-2.86-4.13-.77.89v3.24h-1.49V5.94h1.49v7.97Z\"/><path d=\"m9.59,12.3c0-.89-.02-1.62-.07-2.33h1.32l.07,1.39h.05c.46-.82,1.23-1.58,2.6-1.58,1.13,0,1.99.71,2.35,1.73h.03c.26-.48.58-.85.92-1.12.5-.39,1.05-.6,1.83-.6,1.1,0,2.72.75,2.72,3.74v5.07h-1.47v-4.88c0-1.65-.58-2.65-1.8-2.65-.86,0-1.52.66-1.78,1.42-.07.21-.12.5-.12.78v5.32h-1.47v-5.16c0-1.37-.58-2.37-1.73-2.37-.94,0-1.63.78-1.87,1.57-.09.23-.12.5-.12.76v5.2h-1.47v-6.28Z\"/>";
            }

            return String.Empty;            
        }
    }
}