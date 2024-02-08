using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewLatLong : ComponentBase
{

    #region Declarations

    [Parameter]
    public LatLongModel? LatLong { get; set; }

    [Parameter]
    public string Format { get; set; } = "{0:#,##0.########}";

    public string DisplayLatitude
    {
        get
        {
            if (LatLong != null)
            {
                return String.Format(Format, LatLong.Latitude);
            }

            return String.Empty;
        }
    }

    public string DisplayLongitude
    {
        get
        {
            if (LatLong != null)
            {
                return String.Format(Format, LatLong.Longitude);
            }

            return String.Empty;
        }
    }

    public string DisplaySummary
    {
        get
        {
            if (LatLong != null)
            {
                return string.Format(Resources.Resources.LatLongSummary, DisplayLatitude, DisplayLongitude).Trim();
            }

            return string.Empty;
        }
    }

    #endregion
}