using Microsoft.AspNetCore.Components;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewYearBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Int16? Year { get; set; }

        const string Format = "####";

        const Int16 Minimum = 0;

        const Int16 Maximum = 9999;

        public string DisplayYear { 
            
            get
            {
                if (Year != null)
                {
                    switch (Year)
                    {
                        case < Minimum:
                            return Minimum.ToString(Format);
                        case > Maximum:
                            return Maximum.ToString(Format);
                        default:
                            return Year?.ToString(Format);
                    }
                }

                return String.Empty;
            }
        }

        #endregion
    }
}