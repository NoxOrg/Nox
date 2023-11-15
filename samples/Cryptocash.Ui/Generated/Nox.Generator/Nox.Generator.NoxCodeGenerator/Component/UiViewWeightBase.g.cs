using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewWeightBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Weight { get; set; }

        [Parameter]
        public WeightUnit WeightUnit { get; set; } = WeightUnit.Kilogram;

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayWeight { 
            
            get
            {
                if (Weight != null)
                {
                    switch (Weight)
                    {
                        case < 0:
                            float rtnMinusWeight = 0;
                            return rtnMinusWeight.ToString(Format) + DisplayWeightUnit();                        
                        default:
                            return Weight?.ToString(Format) + DisplayWeightUnit();
                    }
                }

                return String.Empty;
            }
        }

        private string DisplayWeightUnit()
        {
            if (WeightUnit == WeightUnit.Pound)
            {
                return " " + WeightUnit.Pound.Symbol;
            }

            if (WeightUnit == WeightUnit.Kilogram)
            {
                return " " + WeightUnit.Kilogram.Symbol;
            }

            return String.Empty;
        }

        #endregion
    }
}