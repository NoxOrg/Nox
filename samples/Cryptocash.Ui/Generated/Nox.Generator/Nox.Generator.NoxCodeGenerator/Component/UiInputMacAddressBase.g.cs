using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiInputMacAddressBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public string MacAddress { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<string> MacAddressChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title += " is required";
            }
        }

        #endregion

        protected async Task OnMacAddressChanged(string newValue)
        {
            MacAddress = newValue;

            await MacAddressChanged.InvokeAsync(MacAddress);
        }
    }
}