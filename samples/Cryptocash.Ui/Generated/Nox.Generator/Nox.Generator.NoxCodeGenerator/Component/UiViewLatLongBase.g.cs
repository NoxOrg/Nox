using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewLatLongBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public LatLongDto LatLong { get; set; }

        [Parameter]
        public string Format { get; set; } = "{0:0.########}";

        public string DisplayLatitude { 
            
            get
            {
                if (LatLong != null)
                {
                    return String.Format(Format, LatLong.Latitude);
                }

                return String.Empty;
            }
        }

        public string DisplayLongitude
        {

            get
            {
                if (LatLong != null)
                {
                    return String.Format(Format, LatLong.Longitude);
                }

                return String.Empty;
            }
        }

        #endregion
    }
}