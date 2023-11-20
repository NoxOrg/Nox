using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiViewDayOfWeekBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public byte? DayOfWeek { get; set; }

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        public Dictionary<byte, string?>? DayOfWeekSelectionList { get; set; } = new Dictionary<byte, string?>();

        public string DisplayDayOfWeek { 
            
            get
            {
                if (DayOfWeekSelectionList == null
                    || DayOfWeekSelectionList.Count <1)
                {
                    var days = Enumerable.Range(0, 6).Select(i => new { I = i, M = CultureInfo.GetCultureInfo(CultureInfo.LCID).DateTimeFormat?.GetDayName((System.DayOfWeek)i) });

                    if (days != null)
                    {
                        foreach (var CurrentDay in days)
                        {
                            DayOfWeekSelectionList?.Add((byte)CurrentDay.I, CurrentDay.M);
                        }
                    }
                }

                if (DayOfWeek != null
                    && DayOfWeek >= 1
                    && DayOfWeek <= 12
                    && DayOfWeekSelectionList != null
                    && DayOfWeekSelectionList.Count > 0)
                {
                    var SelectedDay = DayOfWeekSelectionList[(byte)DayOfWeek];
                    if (!String.IsNullOrWhiteSpace(SelectedDay))
                    {
                        return SelectedDay;
                    }
                }

                return String.Empty;
            }
        }

        #endregion
    }
}