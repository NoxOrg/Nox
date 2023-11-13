using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewDistanceBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Distance { get; set; }

        [Parameter]
        public DistanceUnit DistanceUnit { get; set; } = DistanceUnit.Kilometer;

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayDistance { 
            
            get
            {
                if (Distance != null)
                {
                    switch (Distance)
                    {
                        case < 0:
                            float rtnMinusDistance = 0;
                            return rtnMinusDistance.ToString(Format) + DisplayDistanceUnit();                        
                        default:
                            return Distance?.ToString(Format) + DisplayDistanceUnit();
                    }
                }

                return String.Empty;
            }
        }

        private string DisplayDistanceUnit()
        {
            if (DistanceUnit == DistanceUnit.Kilometer)
            {
                return " " + DistanceUnit.Kilometer.Symbol;
            }

            if (DistanceUnit == DistanceUnit.Mile)
            {
                return " " + DistanceUnit.Mile.Symbol;
            }

            return String.Empty;
        }

        #endregion
    }
}