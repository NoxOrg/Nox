using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditTime : ComponentBase
{

    #region Declarations

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
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    [Parameter]
    public string? TitleHour { get; set; }

    [Parameter]
    public string? TitleMinute { get; set; }

    [Parameter]
    public string? TitleSecond { get; set; }

    [Parameter]
    public string? TitleMillisecond { get; set; }

    [Parameter]
    public EventCallback<int?> HourChanged { get; set; }

    public string? CurrentHourStr { get; set; }

    [Parameter]
    public EventCallback<int?> MinuteChanged { get; set; }

    public string? CurrentMinuteStr { get; set; }

    [Parameter]
    public EventCallback<int?> SecondChanged { get; set; }

    public string? CurrentSecondStr { get; set; }

    [Parameter]
    public EventCallback<int?> MillisecondChanged { get; set; }

    public string? CurrentMillisecondStr { get; set; }

    public static Dictionary<int, string> HourSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> MinuteSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> SecondSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> MillisecondSelectionList { get; set; } = new Dictionary<int, string>();

    #endregion

    static EditTime()
    {
        for (int i = 0; i < 24; i++)
        {
            HourSelectionList.Add(i, String.Format("{0:00}", i));
        }

        for (int i = 0; i < 60; i++)
        {
            MinuteSelectionList.Add(i, String.Format("{0:00}", i));
            SecondSelectionList.Add(i, String.Format("{0:00}", i));
        }

        for (int i = 0; i < 100; i++)
        {
            MillisecondSelectionList.Add(i, String.Format("{0:00}", i));
        }
    }

    protected async Task OnHourChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int CurrentHour)
            && CurrentHour >= 0
            && CurrentHour <= 23)
        {
            Hour = CurrentHour;
            CurrentHourStr = Hour.ToString();
            await UpdateTime();
        }
    }

    protected async Task OnMinuteChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int CurrentMinute)
            && CurrentMinute >= 0
            && CurrentMinute <= 59)
        {
            Minute = CurrentMinute;
            CurrentMinuteStr = Minute.ToString();
            await UpdateTime();
        }
    }

    protected async Task OnSecondChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int CurrentSecond)
            && CurrentSecond >= 0
            && CurrentSecond <= 59)
        {
            Second = CurrentSecond;
            CurrentSecondStr = Second.ToString();
            await UpdateTime();
        }
    }

    protected async Task OnMillisecondChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int CurrentMillisecond)
            && CurrentMillisecond >= 0
            && CurrentMillisecond <= 100)
        {
            Millisecond = CurrentMillisecond;
            CurrentMillisecondStr = Millisecond.ToString();
            await UpdateTime();
        }
    }

    protected async Task OnClearHour()
    {
        Hour = null;
        CurrentHourStr = null;
        await UpdateTime();
    }

    protected async Task OnClearMinute()
    {
        Minute = null;
        CurrentMinuteStr = null;
        await UpdateTime();
    }

    protected async Task OnClearSecond()
    {
        Second = null;
        CurrentSecondStr = null;
        await UpdateTime();
    }

    protected async Task OnClearMillisecond()
    {
        Millisecond = null;
        CurrentMillisecondStr = null;
        await UpdateTime();
    }

    protected static string ErrorRequiredMessage(string? currentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, currentTitle).Trim();
    }

    protected async Task UpdateTime()
    {
        await HourChanged.InvokeAsync(Hour);
        await MinuteChanged.InvokeAsync(Minute);
        await SecondChanged.InvokeAsync(Second);
        await MillisecondChanged.InvokeAsync(Millisecond);
    }

    public int GetSpacingWidth
    {
        get
        {
            int totaltems = 1 + (DisplayMinute ? 1 : 0) + (DisplaySecond ? 1 : 0) + (DisplayMillisecond ? 1 : 0);
            return 12 / totaltems;
        }
    }
}