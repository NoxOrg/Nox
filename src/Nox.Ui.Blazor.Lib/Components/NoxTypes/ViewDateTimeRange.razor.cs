using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDateTimeRange : ComponentBase
{

    #region Declarations

    [Parameter]
    public DateTimeRangeModel? DateTimeRange { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    #endregion

    public string DisplayDateTimeRange
    {
        get
        {
            if (DateTimeRange is not null)
            {
                return $"Start: {DateTimeRange.Start.ToString(Format, CultureInfo)} End: {DateTimeRange.End.ToString(Format, CultureInfo)}";
            }

            return String.Empty;
        }
    }
}