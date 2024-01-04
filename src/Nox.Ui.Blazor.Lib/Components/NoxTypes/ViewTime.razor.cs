using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewTime : ComponentBase
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

    public string DisplayTime
    {
        get
        {
            if (Hour.HasValue && Hour >= 0 && Hour <= 23)
            {
                int tempMinute = Minute.HasValue && Minute >= 0 && Minute <= 59 ? (int)Minute : 0;
                int tempSecond = Second.HasValue && Second >= 0 && Second <= 59 ? (int)Second : 0;
                int tempMillisecond = Millisecond.HasValue && Millisecond >= 0 && Millisecond <= 99 ? (int)Millisecond : 0;
                System.DateTime dateTime = new(1, 1, 1, (int)Hour, tempMinute, tempSecond, tempMillisecond, DateTimeKind.Unspecified);
                return dateTime.ToString(Format, CultureInfo);
            }
            return string.Empty;
        }
    }

    #endregion
}