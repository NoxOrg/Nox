using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Cryptocash.Ui.Generated.Data.Generic;
using Cryptocash.Ui.Generated.Data.Generic.Service;
using MudBlazor;
using Nox.Types;
using Cryptocash.Ui.Generated.Data.ApiSetting;
using System.Globalization;
using System;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiEditDateTimeBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public System.DateTime? DateTime { get; set; }       

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = System.Globalization.CultureInfo.CurrentCulture;

        [Parameter]
        public string? TitleDateTime { get; set; }

        [Parameter]
        public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

        [Parameter]
        public EventCallback<System.DateTime?> DateTimeChanged { get; set; }

        [Parameter]
        public int? Hour { get; set; }

        [Parameter]
        public int? Minute { get; set; }

        [Parameter]
        public int? Second { get; set; }

        [Parameter]
        public int? Millisecond { get; set; }

        [Parameter]
        public bool DisplayMinute { get; set; } = true;

        [Parameter]
        public bool DisplaySecond { get; set; } = true;

        [Parameter]
        public bool DisplayMillisecond { get; set; } = false;

        [Parameter]
        public string? TitleHour { get; set; }

        [Parameter]
        public string? TitleMinute { get; set; }

        [Parameter]
        public string? TitleSecond { get; set; }

        [Parameter]
        public string? TitleMillisecond { get; set; }

        public string? CurrentHourStr { get; set; }

        public string? CurrentMinuteStr { get; set; }

        public string? CurrentSecondStr { get; set; }

        public string? CurrentMillisecondStr { get; set; }

        public Dictionary<int, string?>? HourSelectionList { get; set; } = new Dictionary<int, string?>();

        public Dictionary<int, string?>? MinuteSelectionList { get; set; } = new Dictionary<int, string?>();

        public Dictionary<int, string?>? SecondSelectionList { get; set; } = new Dictionary<int, string?>();

        public Dictionary<int, string?>? MillisecondSelectionList { get; set; } = new Dictionary<int, string?>();

        #endregion

        /// <summary>
        /// Handles initial loading
        /// </summary>
        protected override void OnInitialized()
        {
            for (int i = 0; i < 24; i++)
            {
                HourSelectionList?.Add(i, String.Format("{0:00}", i));
            }

            for (int i = 0; i < 60; i++)
            {
                MinuteSelectionList?.Add(i, String.Format("{0:00}", i));
                SecondSelectionList?.Add(i, String.Format("{0:00}", i));
            }

            if (DisplayMillisecond)
            {
                for (int i = 0; i < 100; i++)
                {
                    MillisecondSelectionList?.Add(i, String.Format("{0:00}", i));
                }
            }
        }

        protected async Task OnDateTimeChanged(string newValue)
        {
            System.DateTime CurrentDate;

            if (!string.IsNullOrWhiteSpace(newValue)
                && System.DateTime.TryParse(newValue, out CurrentDate))
            {
                DateTime = CurrentDate;

                Hour = DateTime.Value.Hour; 
                Minute = DateTime.Value.Minute; 
                Second = DateTime.Value.Second; 
                Millisecond = DateTime.Value.Millisecond;

                CurrentHourStr = Hour.ToString();
                CurrentMinuteStr = Minute.ToString();
                CurrentSecondStr = Second.ToString();
                CurrentMillisecondStr = Millisecond.ToString();
            }
            else
            {
                DateTime = null;
            }

            await UpdateDateTime();
        }        

        protected string ErrorRequiredMessage(string? CurrentTitle)
        {
            return CurrentTitle + " is required";
        }

        public string DisplayPlaceholder
        {
            get
            {
                return Format.ToUpper();
            }
        }

        public int GetSpacingWidth
        {
            get
            {
                int CurrentItems = 1;

                if (DisplayMinute)
                {
                    CurrentItems += 1;
                }

                if (DisplaySecond)
                {
                    CurrentItems += 1;
                }

                if (DisplayMillisecond)
                {
                    CurrentItems += 1;
                }

                return 12 / CurrentItems;
            }
        }

        protected async Task OnHourChanged(string newValue)
        {
            int CurrentHour = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentHour))
            {
                if (CurrentHour >= 0
                    && CurrentHour <= 23)
                {
                    Hour = CurrentHour;
                    CurrentHourStr = Hour.ToString();
                    await UpdateDateTime();
                }
            }
        }

        protected async Task OnMinuteChanged(string newValue)
        {
            int CurrentMinute = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentMinute))
            {
                if (CurrentMinute >= 0
                    && CurrentMinute <= 59)
                {
                    Minute = CurrentMinute;
                    CurrentMinuteStr = Minute.ToString();
                    await UpdateDateTime();
                }
            }
        }

        protected async Task OnSecondChanged(string newValue)
        {
            int CurrentSecond = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentSecond))
            {
                if (CurrentSecond >= 0
                    && CurrentSecond <= 59)
                {
                    Second = CurrentSecond;
                    CurrentSecondStr = Second.ToString();
                    await UpdateDateTime();
                }
            }
        }

        protected async Task OnMillisecondChanged(string newValue)
        {
            int CurrentMillisecond = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentMillisecond))
            {
                if (CurrentMillisecond >= 0
                    && CurrentMillisecond <= 100)
                {
                    Millisecond = CurrentMillisecond;
                    CurrentMillisecondStr = Millisecond.ToString();
                    await UpdateDateTime();
                }
            }
        }

        protected async Task OnClearHour()
        {
            Hour = null;
            CurrentHourStr = null;
            await UpdateDateTime();
        }

        protected async Task OnClearMinute()
        {
            Minute = null;
            CurrentMinuteStr = null;
            await UpdateDateTime();
        }

        protected async Task OnClearSecond()
        {
            Second = null;
            CurrentSecondStr = null;
            await UpdateDateTime();
        }

        protected async Task OnClearMillisecond()
        {
            Millisecond = null;
            CurrentMillisecondStr = null;
            await UpdateDateTime();
        }

        protected async Task UpdateDateTime()
        {
            if (DateTime != null)
            {
                int tempHour = Hour ?? 0;
                int tempMinute = Minute ?? 0;
                int tempSecond = Second ?? 0; 
                int tempMillisecond = Millisecond ?? 0;

                DateTime = new System.DateTime(DateTime.Value.Year, DateTime.Value.Month, DateTime.Value.Day, tempHour, tempMinute, tempSecond, tempMillisecond);
            }

            await DateTimeChanged.InvokeAsync(DateTime);
        }
    }
}