using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiInputTextBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<string> TextChanged { get; set; }

        public string ErrorRequiredMessage
        {
            get
            {
                return Title += " is required";
            }
        }

        #endregion

        protected async Task OnTextChanged(string newValue)
        {
            Text = newValue;

            await TextChanged.InvokeAsync(Text);
        }
    }
}