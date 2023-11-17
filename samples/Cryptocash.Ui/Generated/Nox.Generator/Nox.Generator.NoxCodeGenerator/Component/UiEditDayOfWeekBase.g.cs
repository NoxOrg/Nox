using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiEditDayOfWeekBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public byte? DayOfWeek { get; set; }        

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public EventCallback<byte?> DayOfWeekChanged { get; set; }

        public Dictionary<byte, string?>? DayOfWeekSelectionList { get; set; } = new Dictionary<byte, string?>();

        public string? CurrentDayOfWeekStr { get; set; }

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            var days = Enumerable.Range(0, 7).Select(i => new { I = i, M = CultureInfo.GetCultureInfo(CultureInfo.LCID).DateTimeFormat?.GetDayName((System.DayOfWeek)i) });

            if (days != null)
            {
                foreach (var CurrentDay in days)
                {
                    DayOfWeekSelectionList?.Add((byte)CurrentDay.I, CurrentDay.M);
                }
            }
        }

        protected async Task OnDayOfWeekChanged(string newValue)
        {
            byte CurrentDay = 0;

            if (!string.IsNullOrWhiteSpace(newValue)
                && byte.TryParse(newValue, out CurrentDay))
            {
                if (CurrentDay >= 0
                    && CurrentDay <= 7)
                {
                    DayOfWeek = CurrentDay;
                    CurrentDayOfWeekStr = DayOfWeek.ToString();
                    await DayOfWeekChanged.InvokeAsync(DayOfWeek);
                }               
            }            
        }

        protected async Task OnClear()
        {
            DayOfWeek = null;
            CurrentDayOfWeekStr = null;
            await DayOfWeekChanged.InvokeAsync(DayOfWeek);
        }

        protected string ErrorRequiredMessage(string? CurrentTitle)
        {
            return CurrentTitle + " is required";
        }
    }
}