using Microsoft.AspNetCore.Components;
using Nox.Ui.Blazor.Lib.Models;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDateTimeRange : ComponentBase
{

    #region Declarations

    [Parameter]
    public DateTimeRangeModel? DateTimeRangeModel { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    #endregion

    public string DisplayDateTimeRange
    {
        get
        {
            if (DateTimeRangeModel is not null)
            {
                return $"Start: {DateTimeRangeModel.Start.ToString(Format, CultureInfo)} End: {DateTimeRangeModel.End.ToString(Format, CultureInfo)}";
            }

            return String.Empty;
        }
    }
}