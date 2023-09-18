using Cryptocash.Ui.Generated.Data.Generic;
using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiHeaderBase : ComponentBase
    {
        #region Declarations

        /// <summary>
        /// Use to reference and display global data in this the page title based on current Api being used
        /// </summary>
        [CascadingParameter]
        public GlobalData? GlobalData { get; set; }

        #endregion

        #region Main Page Functions

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            if (GlobalData != null)
            {
                GlobalData.ValuesChanged += () => StateHasChanged();
            }
        }

        #endregion
    }
}