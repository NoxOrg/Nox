using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewPercentageBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public float? Percentage { get; set; }

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayPercentage { 
            
            get
            {
                if (Percentage != null)
                {
                    switch (Percentage)
                    {
                        case < -100:
                            float rtnMinusPercentage = -100;
                            return rtnMinusPercentage.ToString(Format) + "%";
                        case > 100:
                            return ((float)100).ToString(Format) + "%";
                        default:
                            return Percentage?.ToString(Format) + "%";
                    }
                }

                return String.Empty;
            }
        }

        #endregion
    }
}