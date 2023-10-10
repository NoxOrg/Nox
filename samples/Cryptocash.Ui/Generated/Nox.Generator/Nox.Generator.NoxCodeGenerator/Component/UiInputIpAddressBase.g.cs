using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiInputIpAddressBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public string IpAddress { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<string> IpAddressChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title += " is required";
            }
        }

        #endregion

        protected async Task OnIpAddressChanged(string newValue)
        {
            IpAddress = newValue;

            await IpAddressChanged.InvokeAsync(IpAddress);
        }
    }
}