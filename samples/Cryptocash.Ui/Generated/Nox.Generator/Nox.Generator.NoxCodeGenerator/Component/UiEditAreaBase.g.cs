using Microsoft.AspNetCore.Components;

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
                return Title += " is required";
            }
        }

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