using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewAreaBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Area { get; set; }

        [Parameter]
        public AreaUnit AreaUnit { get; set; } = AreaUnit.SquareMeter;

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayArea { 
            
            get
            {
                if (Area != null)
                {
                    switch (Area)
                    {
                        case < 0:
                            float rtnMinusArea = 0;
                            return rtnMinusArea.ToString(Format) + DisplayAreaUnit();                        
                        default:
                            return Area?.ToString(Format) + DisplayAreaUnit();
                    }
                }

                return String.Empty;
            }
        }

        private string DisplayAreaUnit()
        {
            if (AreaUnit == AreaUnit.SquareFoot)
            {
                return " " + AreaUnit.SquareFoot.Symbol;
            }

            if (AreaUnit == AreaUnit.SquareMeter)
            {
                return " " + AreaUnit.SquareMeter.Symbol;
            }

            return String.Empty;
        }

        #endregion
    }
}