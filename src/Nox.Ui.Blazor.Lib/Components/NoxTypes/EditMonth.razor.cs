using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditMonth : ComponentBase
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

    public static Dictionary<byte, string> MonthSelectionList { get; set; } = new Dictionary<byte, string>();

    public string? CurrentMonthStr { get; set; }

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        var months = Enumerable.Range(1, 12).Select(i => new { I = i, M = CultureInfo.GetCultureInfo(CultureInfo.LCID).DateTimeFormat.GetMonthName(i) });

        foreach (var CurrentMonth in months)
        {
            MonthSelectionList.Add((byte)CurrentMonth.I, CurrentMonth.M);
        }
    }

    protected async Task OnMonthChanged(string newValue)
    {
        if (!string.IsNullOrWhiteSpace(newValue)
            && byte.TryParse(newValue, out byte CurrentMonth)
            && CurrentMonth >= 1
            && CurrentMonth <= 12)
        {
            Month = CurrentMonth;
            CurrentMonthStr = Month.ToString();
            await MonthChanged.InvokeAsync(Month);
        }
    }

    protected async Task OnClear()
    {
        Month = null;
        CurrentMonthStr = null;
        await MonthChanged.InvokeAsync(Month);
    }

    protected static string ErrorRequiredMessage(string? CurrentTitle)
    {
        return CurrentTitle + " is required";
    }
}