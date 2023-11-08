using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditBooleanBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public bool? Boolean { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public EventCallback<bool?> BooleanChanged { get; set; }

        #endregion

        protected async Task OnBooleanChanged(bool? newValue)
        {
            Boolean = newValue;

            await BooleanChanged.InvokeAsync(Boolean);
        }
    }
}