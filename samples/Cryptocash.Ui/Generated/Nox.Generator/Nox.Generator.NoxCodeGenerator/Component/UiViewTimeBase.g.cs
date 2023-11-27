using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nox.Types;
using System.Globalization;

namespace Cryptocash.Ui.Generated.Component
{
    public class UiViewTimeBase : ComponentBase
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
        public string Format { get; set; } = "HH:mm:ss";

        [Parameter]
        public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

        public string DisplayTime { 
            
            get
            {
                string ReturnTime = String.Empty;

                if (Hour != null
                    && Hour >= 0
                    && Hour <= 23)
                {
                    int tempMinute = 0;
                    if (Minute != null
                        && Minute >= 0
                        && Minute <= 59)
                    {
                        tempMinute = (int)Minute;
                    }

                    int tempSecond = 0;
                    if (Second != null
                        && Second >= 0
                        && Second <= 59)
                    {
                        tempSecond = (int)Second;
                    }

                    int tempMillisecond = 0;
                    if (Millisecond != null
                        && Millisecond >= 0
                        && Millisecond <= 99)
                    {
                        tempMillisecond = (int)Millisecond;
                    }

                    System.DateTime dateTime = new System.DateTime(1, 1, 1, (int)Hour, tempMinute, tempSecond, tempMillisecond);
                    return dateTime.ToString(Format, CultureInfo);
                }

                return ReturnTime;
            }
        }

        #endregion
    }
}