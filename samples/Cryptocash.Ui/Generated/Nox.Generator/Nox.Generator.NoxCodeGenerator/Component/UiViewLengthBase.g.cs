using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewLengthBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Length { get; set; }

        [Parameter]
        public LengthUnit LengthUnit { get; set; } = LengthUnit.Meter;

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayLength { 
            
            get
            {
                if (Length != null)
                {
                    switch (Length)
                    {
                        case < 0:
                            float rtnMinusLength = 0;
                            return rtnMinusLength.ToString(Format) + DisplayLengthUnit();                        
                        default:
                            return Length?.ToString(Format) + DisplayLengthUnit();
                    }
                }

                return String.Empty;
            }
        }

        private string DisplayLengthUnit()
        {
            if (LengthUnit == LengthUnit.Foot)
            {
                return " " + LengthUnit.Foot.Symbol;
            }

            if (LengthUnit == LengthUnit.Meter)
            {
                return " " + LengthUnit.Meter.Symbol;
            }

            return String.Empty;
        }

        #endregion
    }
}