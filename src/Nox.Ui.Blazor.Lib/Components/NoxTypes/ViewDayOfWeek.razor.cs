using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDayOfWeek : ComponentBase
{

    #region Declarations

    [Parameter]
    public byte? DayOfWeek { get; set; }

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    public static Dictionary<byte, string> DayOfWeekSelectionList { get; set; } = new Dictionary<byte, string>();

    public string DisplayDayOfWeek
    {
        get
        {
            if (DayOfWeekSelectionList.Count == 0)
            {
                var days = Enumerable.Range(0, 6).Select(i => new { I = i, M = CultureInfo.GetCultureInfo(CultureInfo.LCID).DateTimeFormat.GetDayName((System.DayOfWeek)i) });

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
                return DayOfWeekSelectionList[(byte)DayOfWeek];                
            }

            return String.Empty;
        }
    }

    #endregion
}