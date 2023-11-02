#nullable enable

using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiErrorSummaryBase : ComponentBase
    {
        #region Declarations

        /// <summary>
        /// Property Errors to handle Form errors for display
        /// </summary>
        [Parameter]
        public Dictionary<string, IEnumerable<string>>? Errors { get; set; } = new();

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            Errors = new();
        }
    }
}