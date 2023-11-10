using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewVolumeBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public Decimal? Volume { get; set; }

        [Parameter]
        public VolumeUnit VolumeUnit { get; set; } = VolumeUnit.CubicMeter;

        [Parameter]
        public string Format { get; set; } = "#.##";

        public string DisplayVolume { 
            
            get
            {
                if (Volume != null)
                {
                    switch (Volume)
                    {
                        case < 0:
                            float rtnMinusVolume = 0;
                            return rtnMinusVolume.ToString(Format) + DisplayVolumeUnit();                        
                        default:
                            return Volume?.ToString(Format) + DisplayVolumeUnit();
                    }
                }

                return String.Empty;
            }
        }

        private string DisplayVolumeUnit()
        {
            if (VolumeUnit == VolumeUnit.CubicMeter)
            {
                return " " + VolumeUnit.CubicMeter.Symbol;
            }

            if (VolumeUnit == VolumeUnit.CubicFoot)
            {
                return " " + VolumeUnit.CubicFoot.Symbol;
            }

            return String.Empty;
        }

        #endregion
    }
}