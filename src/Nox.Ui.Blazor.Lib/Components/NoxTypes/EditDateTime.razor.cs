using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDateTime : ComponentBase
{

    #region Declarations

    [Parameter]
    public System.DateTime? DateTime { get; set; }

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

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

    public static Dictionary<int, string> HourSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> MinuteSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> SecondSelectionList { get; set; } = new Dictionary<int, string>();

    public static Dictionary<int, string> MillisecondSelectionList { get; set; } = new Dictionary<int, string>();

    #endregion

    static EditDateTime()
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

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (DateTime.HasValue)
        {
            SetDateTime(DateTime);
        }
    }

    protected async Task OnDateTimeChanged(string newValue)
    {
        if (System.DateTime.TryParse(newValue, CultureInfo, out System.DateTime currentDate))
        {
            DateTime = currentDate;
            SetDateTime(DateTime);
        }
        else
        {
            DateTime = null;
        }

        await UpdateDateTime();
    }

    protected static string ErrorRequiredMessage(string? currentTitle)
    {
        return currentTitle + " is required";
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
            int totaltems = 1 + (DisplayMinute ? 1 : 0) + (DisplaySecond ? 1 : 0) + (DisplayMillisecond ? 1 : 0);
            return 12 / totaltems;
        }
    }

    private void SetDateTime(System.DateTime? currentDate)
    {
        if (currentDate.HasValue)
        {
            Hour = currentDate.Value.Hour;
            Minute = currentDate.Value.Minute;
            Second = currentDate.Value.Second;
            Millisecond = currentDate.Value.Millisecond;

            CurrentHourStr = Hour.ToString();
            CurrentMinuteStr = Minute.ToString();
            CurrentSecondStr = Second.ToString();
            CurrentMillisecondStr = Millisecond.ToString();
        }
    }

    protected async Task OnHourChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int currentHour) 
            && currentHour >= 0
            && currentHour <= 23)
        {
            Hour = currentHour;
            CurrentHourStr = Hour.ToString();
            await UpdateDateTime();
        }
    }

    protected async Task OnMinuteChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int currentMinute) 
            && currentMinute >= 0
            && currentMinute <= 59)
        {
            Minute = currentMinute;
            CurrentMinuteStr = Minute.ToString();
            await UpdateDateTime();
        }
    }

    protected async Task OnSecondChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int currentSecond) 
            && currentSecond >= 0
            && currentSecond <= 59)
        {
            Second = currentSecond;
            CurrentSecondStr = Second.ToString();
            await UpdateDateTime();
        }
    }

    protected async Task OnMillisecondChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && int.TryParse(newValue, out int currentMillisecond) 
            && currentMillisecond >= 0
            && currentMillisecond <= 100)
        {
            Millisecond = currentMillisecond;
            CurrentMillisecondStr = Millisecond.ToString();
            await UpdateDateTime();
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
            DateTime = new(DateTime.Value.Year, 
                DateTime.Value.Month, 
                DateTime.Value.Day, 
                (Hour ?? 0), 
                (Minute ?? 0), 
                (Second ?? 0), 
                (Millisecond ?? 0), 
                DateTimeKind.Unspecified);
        }

        await DateTimeChanged.InvokeAsync(DateTime);
    }
}