using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewBooleanBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public bool? Boolean { get; set; }

        [Parameter]
        public string TitleTrue { get; set; } = "True";

        [Parameter]
        public string TitleFalse { get; set; } = "False";

        public string DisplayBoolean { 
            
            get
            {
                if (Boolean != null)
                {
                    if ((bool)Boolean)
                    {
                        return TitleTrue;
                    }
                    else
                    {
                        return TitleFalse;
                    }
                }

                return String.Empty;
            }
        }

        #endregion
    }
}