using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditNumberBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Number { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Format { get; set; } = "#.##";

        [Parameter]
        public Decimal? Minimum { get; set; }

        [Parameter]
        public Decimal? Maximum { get; set; }

        [Parameter]
        public EventCallback<Decimal?> NumberChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title + " is required";
            }
        }

        #endregion

        protected async Task OnNumberChanged(string newValue)
        {
            if (!string.IsNullOrWhiteSpace(newValue))
            {
                Decimal parsedInt;
                Decimal.TryParse(newValue, out parsedInt);

                Number = parsedInt;
            }
            else
            {
                Number = null;
            }            

            await NumberChanged.InvokeAsync(Number);
        }
    }
}