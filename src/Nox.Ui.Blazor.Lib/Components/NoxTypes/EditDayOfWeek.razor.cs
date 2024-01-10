using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditDayOfWeek : ComponentBase
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

    public static Dictionary<byte, string> DayOfWeekSelectionList { get; set; } = new Dictionary<byte, string>();

    public string? CurrentDayOfWeekStr { get; set; }

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (DayOfWeekSelectionList.Count == 0)
        {
            var days = Enumerable.Range(0, 7).Select(i => new { I = i, M = CultureInfo.GetCultureInfo(CultureInfo.LCID).DateTimeFormat.GetDayName((System.DayOfWeek)i) });

            foreach (var CurrentDay in days)
            {
                DayOfWeekSelectionList?.Add((byte)CurrentDay.I, CurrentDay.M);
            }
        }

        if (DayOfWeek != null
                && DayOfWeek >= 1
                && DayOfWeek <= 12
                && DayOfWeekSelectionList?.Count > 0)
        {
            CurrentDayOfWeekStr = DayOfWeekSelectionList[(byte)DayOfWeek];
        }
    }

    protected async Task OnDayOfWeekChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && byte.TryParse(newValue, out byte currentDay) 
            && currentDay >= 0
            && currentDay <= 7)
        {
            DayOfWeek = currentDay;
            CurrentDayOfWeekStr = DayOfWeek.ToString();
            await DayOfWeekChanged.InvokeAsync(DayOfWeek);
        }
    }

    protected async Task OnClear()
    {
        DayOfWeek = null;
        CurrentDayOfWeekStr = null;
        await DayOfWeekChanged.InvokeAsync(DayOfWeek);
    }

    protected static string ErrorRequiredMessage(string? currentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, currentTitle).Trim();
    }
}