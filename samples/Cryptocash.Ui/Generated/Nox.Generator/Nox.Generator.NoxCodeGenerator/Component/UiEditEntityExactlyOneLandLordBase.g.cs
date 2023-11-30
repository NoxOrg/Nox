using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditEntityExactlyOneLandLordBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public LandLordDto LandLord { get; set; }

        [Parameter]
        public System.Guid? LandLordId { get; set; }

        public string CurrentLandLordIdStr { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<LandLordDto> LandLordSelectionList { get; set; } = null;

        [Parameter]
        public EventCallback<LandLordDto> LandLordChanged { get; set; }

        [Parameter]
        public EventCallback<System.Guid?> LandLordIdChanged { get; set; }

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            CurrentLandLordIdStr = LandLordId.ToString();
        }

        protected async Task OnLandLordIdChanged(string newValue)
        {
            CurrentLandLordIdStr = newValue;

            if (!string.IsNullOrWhiteSpace(CurrentLandLordIdStr))
            {
                LandLord = LandLordSelectionList.FirstOrDefault(LandLord => LandLord.Id.ToString().Equals(CurrentLandLordIdStr));
                await LandLordChanged.InvokeAsync(LandLord);

                if (LandLord != null)
                {
                    LandLordId = LandLord.Id;
                    await LandLordIdChanged.InvokeAsync(LandLordId);
                }   
            }            
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle + " is required";
        }
    }
}