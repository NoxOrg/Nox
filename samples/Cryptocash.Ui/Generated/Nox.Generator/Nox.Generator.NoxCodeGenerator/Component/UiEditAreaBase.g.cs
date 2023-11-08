using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditAreaBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Area { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<Decimal?> AreaChanged { get; set; }

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
        public string AdornmentIcon { get; set; } = "<style>.cls-1{fill:none;}.cls-2{fill:#1d1d1b;}</style></defs><g id=\"Layer_1\" focusable=\"false\"><path class=\"cls-1\" d=\"m0,0h24v24H0V0Z\"/><path class=\"cls-2\" d=\"m3.1,12.56c0-.85-.02-1.55-.07-2.23h1.31l.07,1.33h.05c.46-.78,1.23-1.52,2.59-1.52,1.13,0,1.98.68,2.34,1.65h.03c.26-.46.58-.82.92-1.07.49-.38,1.04-.58,1.82-.58,1.09,0,2.71.72,2.71,3.58v4.86h-1.47v-4.67c0-1.59-.58-2.54-1.79-2.54-.85,0-1.52.63-1.77,1.36-.07.2-.12.48-.12.75v5.1h-1.47v-4.94c0-1.31-.58-2.27-1.72-2.27-.94,0-1.62.75-1.86,1.5-.08.22-.12.48-.12.73v4.98h-1.47v-6.02Z\"/><path class=\"cls-2\" d=\"m16.53,12.9v-.54l.69-.67c1.65-1.57,2.39-2.4,2.4-3.38,0-.66-.32-1.26-1.28-1.26-.59,0-1.07.3-1.37.55l-.28-.62c.45-.38,1.08-.66,1.83-.66,1.39,0,1.98.95,1.98,1.88,0,1.19-.86,2.15-2.23,3.47l-.52.48v.02h2.9v.73h-4.12Z\"/></g>";

        #endregion

        protected async Task OnAreaChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedDouble;
                Decimal.TryParse(newValue, out parsedDouble);

                Area = parsedDouble;
            }
            else
            {
                Area = null;
            }            

            await AreaChanged.InvokeAsync(Area);
        }
    }
}