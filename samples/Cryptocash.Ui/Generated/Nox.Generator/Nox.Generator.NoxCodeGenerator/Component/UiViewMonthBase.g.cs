using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiViewMonthBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public byte? Month { get; set; }

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        public Dictionary<byte, string?>? MonthSelectionList { get; set; } = new Dictionary<byte, string?>();

        public string DisplayMonth { 
            
            get
            {
                if (MonthSelectionList == null
                    || MonthSelectionList.Count <1)
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

                if (Month != null
                    && Month >= 1
                    && Month <= 12
                    && MonthSelectionList != null
                    && MonthSelectionList.Count > 0)
                {
                    var SelectedMonth = MonthSelectionList[(byte)Month];
                    if (!String.IsNullOrWhiteSpace(SelectedMonth))
                    {
                        return SelectedMonth;
                    }
                }

                return String.Empty;
            }
        }

        #endregion
    }
}