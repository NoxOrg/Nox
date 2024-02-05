using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDateTimeRange : ComponentBase
{

    #region Declarations

    private DateRange? DateTimeRangeInternal { get; set; }

    [Parameter]
    public DateTimeRangeModel DateTimeRange { get; set; } = new();

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    [Parameter]
    public string? TitleDateTimeRange { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy";

    [Parameter]
    public EventCallback<DateTimeRangeModel?> DateTimeRangeChanged { get; set; }

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

    public static Dictionary<int, string> HourSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> MinuteSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> SecondSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> MillisecondSelectionList { get; set; } = new Dictionary<int, string>();

    #endregion

    static EditDateTimeRange()
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

        for (int i = 0; i < 100; i++)
        {
            MillisecondSelectionList?.Add(i, String.Format("{0:00}", i));
        }
    }

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (DateTimeRange is null)
            return;

        HourStart = DateTimeRange.Start.Hour;
        MinuteStart = DateTimeRange.Start.Minute;
        SecondStart = DateTimeRange.Start.Second;
        MillisecondStart = DateTimeRange.Start.Millisecond;

        CurrentHourStartStr = HourStart.ToString();
        CurrentMinuteStartStr = MinuteStart.ToString();
        CurrentSecondStartStr = SecondStart.ToString();
        CurrentMillisecondStartStr = MillisecondStart.ToString();

        HourEnd = DateTimeRange.End.Hour;
        MinuteEnd = DateTimeRange.End.Minute;
        SecondEnd = DateTimeRange.End.Second;
        MillisecondEnd = DateTimeRange.End.Millisecond;

        CurrentHourEndStr = HourEnd.ToString();
        CurrentMinuteEndStr = MinuteEnd.ToString();
        CurrentSecondEndStr = SecondEnd.ToString();
        CurrentMillisecondEndStr = MillisecondEnd.ToString();
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
                if (System.DateTime.TryParse(tempDateRangeList[0], CultureInfo, out System.DateTime currentDateTimeStart))
                {
                    DateTimeRange.Start = currentDateTimeStart;

                    HourStart = DateTimeRange.Start.Hour;
                    MinuteStart = DateTimeRange.Start.Minute;
                    SecondStart = DateTimeRange.Start.Second;
                    MillisecondStart = DateTimeRange.Start.Millisecond;

                    CurrentHourStartStr = HourStart.ToString();
                    CurrentMinuteStartStr = MinuteStart.ToString();
                    CurrentSecondStartStr = SecondStart.ToString();
                    CurrentMillisecondStartStr = MillisecondStart.ToString();
                }

                if (System.DateTime.TryParse(tempDateRangeList[1], CultureInfo, out System.DateTime currentDateTimeEnd))
                {
                    DateTimeRange.End = currentDateTimeEnd;

                    HourEnd = DateTimeRange.End.Hour;
                    MinuteEnd = DateTimeRange.End.Minute;
                    SecondEnd = DateTimeRange.End.Second;
                    MillisecondEnd = DateTimeRange.End.Millisecond;

                    CurrentHourEndStr = HourEnd.ToString();
                    CurrentMinuteEndStr = MinuteEnd.ToString();
                    CurrentSecondEndStr = SecondEnd.ToString();
                    CurrentMillisecondEndStr = MillisecondEnd.ToString();
                }

                await UpdateDateTimeRange();
            }
        }
    }

    protected static string ErrorRequiredMessage(string? currentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, currentTitle).Trim();
    }

    public int GetSpacingWidth
    {
        get
        {
            int totaltems = 1 + (DisplayMinute ? 1 : 0) + (DisplaySecond ? 1 : 0) + (DisplayMillisecond ? 1 : 0);
            return 12 / totaltems;
        }
    }

    protected async Task OnHourStartChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentHour) 
            && currentHour >= 0
            && currentHour <= 23)
        {
            HourStart = currentHour;
            CurrentHourStartStr = HourStart.ToString();
            await UpdateDateTimeRange();
        }
    }

    protected async Task OnMinuteStartChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentMinute) 
            && currentMinute >= 0
            && currentMinute <= 59)
        {
            MinuteStart = currentMinute;
            CurrentMinuteStartStr = MinuteStart.ToString();
            await UpdateDateTimeRange();
        }
    }

    protected async Task OnSecondStartChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentSecond) 
            && currentSecond >= 0
            && currentSecond <= 59)
        {
            SecondStart = currentSecond;
            CurrentSecondStartStr = SecondStart.ToString();
            await UpdateDateTimeRange();
        }
    }

    protected async Task OnMillisecondStartChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentMillisecond) 
            && currentMillisecond >= 0
            && currentMillisecond <= 100)
        {
            MillisecondStart = currentMillisecond;
            CurrentMillisecondStartStr = MillisecondStart.ToString();
            await UpdateDateTimeRange();
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
        if (int.TryParse(newValue, out int currentHour) 
            && currentHour >= 0
            && currentHour <= 23)
        {
            HourEnd = currentHour;
            CurrentHourEndStr = HourEnd.ToString();
            await UpdateDateTimeRange();
        }
    }

    protected async Task OnMinuteEndChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentMinute) 
            && currentMinute >= 0
            && currentMinute <= 59)
        {
            MinuteEnd = currentMinute;
            CurrentMinuteEndStr = MinuteEnd.ToString();
            await UpdateDateTimeRange();
        }
    }

    protected async Task OnSecondEndChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentSecond) 
            && currentSecond >= 0
            && currentSecond <= 59)
        {
            SecondEnd = currentSecond;
            CurrentSecondEndStr = SecondEnd.ToString();
            await UpdateDateTimeRange();
        }
    }

    protected async Task OnMillisecondEndChanged(string newValue)
    {
        if (int.TryParse(newValue, out int currentMillisecond) 
            && currentMillisecond >= 0
            && currentMillisecond <= 100)
        {
            MillisecondEnd = currentMillisecond;
            CurrentMillisecondEndStr = MillisecondEnd.ToString();
            await UpdateDateTimeRange();
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
        if (DateTimeRange is not null)
        {
            DateTimeRange.Start = new (DateTimeRange.Start.Year,
                DateTimeRange.Start.Month,
                DateTimeRange.Start.Day, 
                (HourStart ?? 0), 
                (MinuteStart ?? 0), 
                (SecondStart ?? 0), 
                (MillisecondStart ?? 0), 
                TimeSpan.Zero);

            DateTimeRange.End = new (DateTimeRange.End.Year,
                DateTimeRange.End.Month,
                DateTimeRange.End.Day, 
                (HourEnd ?? 0), 
                (MinuteEnd ?? 0), 
                (SecondEnd ?? 0), 
                (MillisecondEnd ?? 0),
                TimeSpan.Zero);

            DateTimeRangeInternal = new DateRange(DateTimeRange.Start.DateTime, DateTimeRange.End.DateTime);
        }

        await DateTimeRangeChanged.InvokeAsync(DateTimeRange);
    }
}