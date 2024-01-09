using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDateTimeRange : ComponentBase
{

    #region Declarations

    [Parameter]
    public System.DateTime? DateTimeStart { get; set; }

    [Parameter]
    public System.DateTime? DateTimeEnd { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    #endregion

    public string DisplayDateTimeRange
    {
        get
        {
            if (DateTimeStart != null
                && DateTimeEnd != null)
            {
                return $"Start: {DateTimeStart?.ToString(Format, CultureInfo)} End: {DateTimeEnd?.ToString(Format, CultureInfo)}";
            }

            return String.Empty;
        }
    }
}