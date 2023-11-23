using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewDateTimeRangeBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public DateTime? DateTimeStart { get; set; }

        [Parameter]
        public DateTime? DateTimeEnd { get; set; }

        [Parameter]
        public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        #endregion

        public string DisplayDateTimeRange
        {
            get
            {
                string ReturnDateTimeRange = String.Empty;

                if (DateTimeStart != null
                    && DateTimeEnd != null)
                {
                    ReturnDateTimeRange = $"Start: {DateTimeStart?.ToString(Format, CultureInfo)} End: {DateTimeEnd?.ToString(Format, CultureInfo)}";
                }

                return ReturnDateTimeRange;
            }
        }
    }
}