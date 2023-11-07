using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditYearBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Int32? Year { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<Int32?> YearChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title + " is required";
            }
        }

        public string Format = "####";

        #endregion

        protected async Task OnYearChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Int32 parsedInt;
                Int32.TryParse(newValue, out parsedInt);

                Year = parsedInt;
            }
            else
            {
                Year = null;
            }            

            await YearChanged.InvokeAsync(Year);
        }
    }
}