using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Nox.Types.Common;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditWeightBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Weight { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public WeightUnit WeightUnit { get; set; } = WeightUnit.Kilogram;

        [Parameter]
        public EventCallback<Decimal?> WeightChanged { get; set; }

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

        protected async Task OnWeightChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedDouble;
                Decimal.TryParse(newValue, out parsedDouble);

                Weight = parsedDouble;
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

            if (WeightUnit == WeightUnit.Pound)
            {
                return "<path d=\"m6.44,6.13h1.51v12.63h-1.51V6.13Z\"/><path d=\"m10.42,18.76c.03-.59.07-1.46.07-2.22V6.13h1.49v5.41h.03c.53-.96,1.49-1.58,2.83-1.58,2.06,0,3.51,1.78,3.5,4.4,0,3.08-1.87,4.61-3.72,4.61-1.2,0-2.16-.48-2.78-1.62h-.05l-.07,1.42h-1.3Zm1.56-3.45c0,.2.03.39.07.57.29,1.08,1.17,1.83,2.26,1.83,1.58,0,2.52-1.33,2.52-3.31,0-1.73-.86-3.2-2.47-3.2-1.03,0-1.99.73-2.3,1.92-.03.18-.09.39-.09.64v1.55Z\"/>";
            }

            if (WeightUnit == WeightUnit.Kilogram)
            {
                return "<path d=\"m5.93,14.1h.03c.21-.3.5-.68.74-.98l2.43-2.97h1.82l-3.2,3.54,3.65,5.07h-1.83l-2.86-4.13-.77.89v3.24h-1.49V6.13h1.49v7.97Z\"/><path d=\"m19.62,10.15c-.03.62-.07,1.32-.07,2.37v5c0,1.97-.38,3.18-1.18,3.93-.81.78-1.97,1.03-3.02,1.03s-2.09-.25-2.76-.71l.38-1.19c.55.36,1.41.68,2.43.68,1.54,0,2.67-.84,2.67-3.01v-.96h-.04c-.46.8-1.35,1.44-2.64,1.44-2.06,0-3.53-1.82-3.53-4.2,0-2.92,1.83-4.57,3.73-4.57,1.44,0,2.23.78,2.59,1.49h.04l.07-1.3h1.32Zm-1.56,3.4c0-.27-.02-.5-.09-.71-.27-.91-1.01-1.65-2.11-1.65-1.44,0-2.47,1.26-2.47,3.26,0,1.69.82,3.1,2.45,3.1.93,0,1.77-.61,2.09-1.6.09-.27.12-.57.12-.84v-1.55Z\"/>";
            }

            return String.Empty;            
        }
    }
}