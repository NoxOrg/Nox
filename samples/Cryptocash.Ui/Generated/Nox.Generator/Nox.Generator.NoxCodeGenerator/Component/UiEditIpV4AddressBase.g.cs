using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditIpV4AddressBase : ComponentBase
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
                return Title + " is required";
            }
        }

        [Parameter]
        public int MaxLength { get; set; } = 63;

        #endregion

        protected async Task OnIpAddressChanged(string newValue)
        {
            IpAddress = newValue;

            await IpAddressChanged.InvokeAsync(IpAddress);
        }

        public IMask DisplayMask()
        {
            return RegexMask.IPv4();
        }
    }
}