using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiViewEntityExactlyOneLandLordBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public LandLordDto? LandLord { get; set; }

        #endregion

        public string DisplayLandLord
        {

            get
            {
                if (LandLord != null
                    && !String.IsNullOrWhiteSpace(LandLord.Name))
                {
                    return LandLord.Name;
                }

                return String.Empty;
            }
        }
    }
}