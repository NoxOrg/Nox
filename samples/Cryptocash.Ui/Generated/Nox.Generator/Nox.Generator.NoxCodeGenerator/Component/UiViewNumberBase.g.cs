using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewNumberBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Number { get; set; }

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayNumber { 
            
            get
            {
                if (Number != null)
                {
                    return Number?.ToString(Format);
                }

                return String.Empty;
            }
        }

        #endregion
    }
}