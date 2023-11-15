using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using Nox.Types.Common;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditVolumeBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Volume { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public VolumeUnit VolumeUnit { get; set; } = VolumeUnit.CubicMeter;

        [Parameter]
        public EventCallback<Decimal?> VolumeChanged { get; set; }

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

        protected async Task OnVolumeChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedDouble;
                Decimal.TryParse(newValue, out parsedDouble);

                Volume = parsedDouble;
            }
            else
            {
                Volume = null;
            }            

            await VolumeChanged.InvokeAsync(Volume);
        }

        public string GetAdornmentIcon()
        {
            if (!string.IsNullOrWhiteSpace(AdornmentIcon))
            {
                return AdornmentIcon;
            }

            if (VolumeUnit == VolumeUnit.CubicFoot)
            {
                return "<path d=\"m5.42,18.58v-7.42h-1.17v-1.19h1.17v-.41c0-1.21.26-2.31.96-3.01.57-.57,1.32-.8,2.02-.8.53,0,.99.12,1.29.25l-.21,1.21c-.22-.11-.53-.2-.96-.2-1.29,0-1.61,1.17-1.61,2.49v.46h2v1.19h-2v7.42h-1.49Z\"/><path d=\"m12.27,7.49v2.47h2.16v1.19h-2.16v4.64c0,1.07.29,1.67,1.13,1.67.39,0,.69-.05.87-.11l.07,1.17c-.29.12-.75.21-1.34.21-.7,0-1.27-.23-1.63-.66-.43-.46-.58-1.23-.58-2.24v-4.7h-1.29v-1.19h1.29v-2.06l1.47-.41Z\"/><path d=\"m15.36,7.37c.39-.27,1.13-.55,1.97-.55,1.47,0,2.09.82,2.09,1.67,0,.71-.5,1.32-1.32,1.6v.04c.94.14,1.59.82,1.59,1.73,0,1.1-.96,2.08-2.71,2.08-.82,0-1.58-.23-1.95-.5l.31-.89c.27.2.94.46,1.59.46,1.04,0,1.51-.64,1.49-1.19,0-.89-.91-1.25-1.82-1.25h-.46v-.82h.48c.63,0,1.54-.3,1.56-1.14,0-.43-.31-.87-1.08-.87-.62,0-1.18.27-1.46.46l-.29-.84Z\"/>";
            }

            if (VolumeUnit == VolumeUnit.CubicMeter)
            {
                return "<path d=\"m3.26,12.3c0-.89-.02-1.62-.07-2.33h1.32l.07,1.39h.05c.46-.82,1.23-1.58,2.6-1.58,1.13,0,1.99.71,2.35,1.73h.03c.26-.48.58-.85.93-1.12.5-.39,1.04-.6,1.83-.6,1.1,0,2.72.75,2.72,3.74v5.07h-1.47v-4.88c0-1.65-.58-2.65-1.8-2.65-.86,0-1.53.66-1.78,1.42-.07.21-.12.5-.12.78v5.32h-1.47v-5.16c0-1.37-.58-2.37-1.73-2.37-.94,0-1.63.78-1.87,1.57-.09.23-.12.5-.12.76v5.2h-1.47v-6.28Z\"/><path d=\"m16.79,7.37c.39-.27,1.13-.55,1.97-.55,1.47,0,2.09.82,2.09,1.67,0,.71-.5,1.32-1.32,1.6v.04c.94.14,1.59.82,1.59,1.73,0,1.1-.96,2.08-2.71,2.08-.82,0-1.58-.23-1.95-.5l.31-.89c.27.2.94.46,1.59.46,1.04,0,1.51-.64,1.49-1.19,0-.89-.91-1.25-1.82-1.25h-.46v-.82h.48c.63,0,1.54-.3,1.56-1.14,0-.43-.31-.87-1.08-.87-.62,0-1.18.27-1.46.46l-.29-.84Z\"/>";
            }

            return String.Empty;            
        }
    }
}