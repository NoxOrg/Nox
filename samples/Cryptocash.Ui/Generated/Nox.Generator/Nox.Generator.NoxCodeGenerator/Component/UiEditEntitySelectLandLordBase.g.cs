using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiEditEntitySelectLandLordBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public LandLordDto LandLord { get; set; }

        [Parameter]
        public System.Int64? LandLordId { get; set; }

        [Parameter]
        public System.Int64 LandLordIdLong { get; set; }

        public string CurrentLandLordIdStr { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public List<LandLordDto> LandLordSelectionList { get; set; } = null;

        [Parameter]
        public EventCallback<LandLordDto> LandLordChanged { get; set; }

        [Parameter]
        public EventCallback<System.Int64?> LandLordIdChanged { get; set; }

        [Parameter]
        public EventCallback<System.Int64> LandLordIdLongChanged { get; set; }

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            if (LandLordIdLong > 0)
            {
                LandLordId = LandLordIdLong;
                CurrentLandLordIdStr = LandLordIdLong.ToString();
            }
        }

        protected async Task OnLandLordIdChanged(string newValue)
        {
            CurrentLandLordIdStr = newValue;

            long CurrentLandLordId = 0;

            if (!string.IsNullOrWhiteSpace(CurrentLandLordIdStr)
                && long.TryParse(CurrentLandLordIdStr, out CurrentLandLordId))
            {
                LandLord = LandLordSelectionList.FirstOrDefault(LandLord => long.Equals(LandLord.Id, CurrentLandLordId));
                await LandLordChanged.InvokeAsync(LandLord);

                if (LandLord != null)
                {
                    LandLordId = LandLord.Id;
                    LandLordIdLong = (long)LandLordId;
                    await LandLordIdChanged.InvokeAsync(LandLordId);
                    await LandLordIdLongChanged.InvokeAsync(LandLordIdLong);
                }   
            }            
        }

        protected string ErrorRequiredMessage(string CurrentTitle)
        {
            return CurrentTitle += " is required";
        }
    }
}