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

    public class UiEditDateTimeRangeBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public DateRange? DateTimeRange { get; set; }

        [Parameter]
        public System.DateTime? DateTimeStart { get; set; }

        [Parameter]
        public System.DateTime? DateTimeEnd { get; set; }        

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = System.Globalization.CultureInfo.CurrentCulture;

        [Parameter]
        public string? TitleDateTimeRange { get; set; }

        [Parameter]
        public string Format { get; set; } = "dd/MM/yyyy";

        [Parameter]
        public EventCallback<System.DateTime?> DateTimeStartChanged { get; set; }

        [Parameter]
        public EventCallback<System.DateTime?> DateTimeEndChanged { get; set; }

        [Parameter]
        public int? HourStart { get; set; }

        [Parameter]
        public int? MinuteStart { get; set; }

        [Parameter]
        public int? SecondStart { get; set; }

        [Parameter]
        public int? MillisecondStart { get; set; }

        [Parameter]
        public string? TitleHourStart { get; set; }

        [Parameter]
        public string? TitleMinuteStart { get; set; }

        [Parameter]
        public string? TitleSecondStart { get; set; }

        [Parameter]
        public string? TitleMillisecondStart { get; set; }

        public string? CurrentHourStartStr { get; set; }

        public string? CurrentMinuteStartStr { get; set; }

        public string? CurrentSecondStartStr { get; set; }

        public string? CurrentMillisecondStartStr { get; set; }

        [Parameter]
        public int? HourEnd { get; set; }

        [Parameter]
        public int? MinuteEnd { get; set; }

        [Parameter]
        public int? SecondEnd { get; set; }

        [Parameter]
        public int? MillisecondEnd { get; set; }

        [Parameter]
        public string? TitleHourEnd { get; set; }

        [Parameter]
        public string? TitleMinuteEnd { get; set; }

        [Parameter]
        public string? TitleSecondEnd { get; set; }

        [Parameter]
        public string? TitleMillisecondEnd { get; set; }

        public string? CurrentHourEndStr { get; set; }

        public string? CurrentMinuteEndStr { get; set; }

        public string? CurrentSecondEndStr { get; set; }

        public string? CurrentMillisecondEndStr { get; set; }

        [Parameter]
        public bool DisplayMinute { get; set; } = true;

        [Parameter]
        public bool DisplaySecond { get; set; } = true;

        [Parameter]
        public bool DisplayMillisecond { get; set; } = false;

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

        protected async Task OnDateTimeRangeChanged(string newValue)
        {   
            if (!String.IsNullOrWhiteSpace(newValue)
                && newValue.Contains(';'))
            {
                string tempDateRangeStr = newValue.Replace("]", String.Empty).Replace("[", String.Empty);

                List<string> tempDateRangeList = tempDateRangeStr.Split(';').ToList();

                if (tempDateRangeList.Count == 2)
                {
                    System.DateTime CurrentDateTimeStart;

                    if (!string.IsNullOrWhiteSpace(tempDateRangeList[0])
                    && System.DateTime.TryParse(tempDateRangeList[0], out CurrentDateTimeStart))
                    {
                        DateTimeStart = CurrentDateTimeStart;

                        HourStart = DateTimeStart.Value.Hour;
                        MinuteStart = DateTimeStart.Value.Minute;
                        SecondStart = DateTimeStart.Value.Second;
                        MillisecondStart = DateTimeStart.Value.Millisecond;

                        CurrentHourStartStr = HourStart.ToString();
                        CurrentMinuteStartStr = MinuteStart.ToString();
                        CurrentSecondStartStr = SecondStart.ToString();
                        CurrentMillisecondStartStr = MillisecondStart.ToString();
                    }

                    System.DateTime CurrentDateTimeEnd;

                    if (!string.IsNullOrWhiteSpace(tempDateRangeList[1])
                    && System.DateTime.TryParse(tempDateRangeList[1], out CurrentDateTimeEnd))
                    {
                        DateTimeEnd = CurrentDateTimeEnd;

                        HourEnd = DateTimeEnd.Value.Hour;
                        MinuteEnd = DateTimeEnd.Value.Minute;
                        SecondEnd = DateTimeEnd.Value.Second;
                        MillisecondEnd = DateTimeEnd.Value.Millisecond;

                        CurrentHourEndStr = HourEnd.ToString();
                        CurrentMinuteEndStr = MinuteEnd.ToString();
                        CurrentSecondEndStr = SecondEnd.ToString();
                        CurrentMillisecondEndStr = MillisecondEnd.ToString();
                    }

                    await UpdateDateTimeRange();
                }
            } 
        }        

        protected string ErrorRequiredMessage(string? CurrentTitle)
        {
            return CurrentTitle + " is required";
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

        protected async Task OnHourStartChanged(string newValue)
        {
            int CurrentHour = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentHour))
            {
                if (CurrentHour >= 0
                    && CurrentHour <= 23)
                {
                    HourStart = CurrentHour;
                    CurrentHourStartStr = HourStart.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnMinuteStartChanged(string newValue)
        {
            int CurrentMinute = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentMinute))
            {
                if (CurrentMinute >= 0
                    && CurrentMinute <= 59)
                {
                    MinuteStart = CurrentMinute;
                    CurrentMinuteStartStr = MinuteStart.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnSecondStartChanged(string newValue)
        {
            int CurrentSecond = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentSecond))
            {
                if (CurrentSecond >= 0
                    && CurrentSecond <= 59)
                {
                    SecondStart = CurrentSecond;
                    CurrentSecondStartStr = SecondStart.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnMillisecondStartChanged(string newValue)
        {
            int CurrentMillisecond = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentMillisecond))
            {
                if (CurrentMillisecond >= 0
                    && CurrentMillisecond <= 100)
                {
                    MillisecondStart = CurrentMillisecond;
                    CurrentMillisecondStartStr = MillisecondStart.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnClearHourStart()
        {
            HourStart = null;
            CurrentHourStartStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnClearMinuteStart()
        {
            MinuteStart = null;
            CurrentMinuteStartStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnClearSecondStart()
        {
            SecondStart = null;
            CurrentSecondStartStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnClearMillisecondStart()
        {
            MillisecondStart = null;
            CurrentMillisecondStartStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnHourEndChanged(string newValue)
        {
            int CurrentHour = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentHour))
            {
                if (CurrentHour >= 0
                    && CurrentHour <= 23)
                {
                    HourEnd = CurrentHour;
                    CurrentHourEndStr = HourEnd.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnMinuteEndChanged(string newValue)
        {
            int CurrentMinute = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentMinute))
            {
                if (CurrentMinute >= 0
                    && CurrentMinute <= 59)
                {
                    MinuteEnd = CurrentMinute;
                    CurrentMinuteEndStr = MinuteEnd.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnSecondEndChanged(string newValue)
        {
            int CurrentSecond = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentSecond))
            {
                if (CurrentSecond >= 0
                    && CurrentSecond <= 59)
                {
                    SecondEnd = CurrentSecond;
                    CurrentSecondEndStr = SecondEnd.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnMillisecondEndChanged(string newValue)
        {
            int CurrentMillisecond = -1;

            if (!string.IsNullOrWhiteSpace(newValue)
                && int.TryParse(newValue, out CurrentMillisecond))
            {
                if (CurrentMillisecond >= 0
                    && CurrentMillisecond <= 100)
                {
                    MillisecondEnd = CurrentMillisecond;
                    CurrentMillisecondEndStr = MillisecondEnd.ToString();
                    await UpdateDateTimeRange();
                }
            }
        }

        protected async Task OnClearHourEnd()
        {
            HourEnd = null;
            CurrentHourEndStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnClearMinuteEnd()
        {
            MinuteEnd = null;
            CurrentMinuteEndStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnClearSecondEnd()
        {
            SecondEnd = null;
            CurrentSecondEndStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task OnClearMillisecondEnd()
        {
            MillisecondEnd = null;
            CurrentMillisecondEndStr = null;
            await UpdateDateTimeRange();
        }

        protected async Task UpdateDateTimeRange()
        {
            if (DateTimeStart != null)
            {
                int tempStartHour = HourStart ?? 0;
                int tempStartMinute = MinuteStart ?? 0;
                int tempStartSecond = SecondStart ?? 0; 
                int tempStartMillisecond = MillisecondStart ?? 0;

                DateTimeStart = new System.DateTime(DateTimeStart.Value.Year, DateTimeStart.Value.Month, DateTimeStart.Value.Day, tempStartHour, tempStartMinute, tempStartSecond, tempStartMillisecond);               
            }

            if (DateTimeEnd != null)
            {
                int tempEndHour = HourEnd ?? 0;
                int tempEndMinute = MinuteEnd ?? 0;
                int tempEndSecond = SecondEnd ?? 0;
                int tempEndMillisecond = MillisecondEnd ?? 0;

                DateTimeEnd = new System.DateTime(DateTimeEnd.Value.Year, DateTimeEnd.Value.Month, DateTimeEnd.Value.Day, tempEndHour, tempEndMinute, tempEndSecond, tempEndMillisecond);
            }

            DateTimeRange = new DateRange(DateTimeStart, DateTimeEnd);

            await DateTimeStartChanged.InvokeAsync(DateTimeStart);
            await DateTimeEndChanged.InvokeAsync(DateTimeEnd);
        }        
    }
}