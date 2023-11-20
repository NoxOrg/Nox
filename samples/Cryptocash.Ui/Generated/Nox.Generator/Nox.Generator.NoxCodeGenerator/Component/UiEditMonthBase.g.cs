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

    public class UiEditMonthBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public byte? Month { get; set; }        

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public EventCallback<byte?> MonthChanged { get; set; }

        public Dictionary<byte, string?>? MonthSelectionList { get; set; } = new Dictionary<byte, string?>();

        public string? CurrentMonthStr { get; set; }

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            var months = Enumerable.Range(1, 12).Select(i => new { I = i, M = CultureInfo.GetCultureInfo(CultureInfo.LCID).DateTimeFormat?.GetMonthName(i) });

            if (months != null)
            {
                foreach (var CurrentMonth in months)
                {
                    MonthSelectionList?.Add((byte)CurrentMonth.I, CurrentMonth.M);
                }
            }
        }

        protected async Task OnMonthChanged(string newValue)
        {
            byte CurrentMonth = 0;

            if (!string.IsNullOrWhiteSpace(newValue)
                && byte.TryParse(newValue, out CurrentMonth))
            {
                if (CurrentMonth >= 1
                    && CurrentMonth <= 12)
                {
                    Month = CurrentMonth;
                    CurrentMonthStr = Month.ToString();
                    await MonthChanged.InvokeAsync(Month);
                }               
            }            
        }

        protected async Task OnClear()
        {
            Month = null;
            CurrentMonthStr = null;
            await MonthChanged.InvokeAsync(Month);
        }

        protected string ErrorRequiredMessage(string? CurrentTitle)
        {
            return CurrentTitle + " is required";
        }
    }
}