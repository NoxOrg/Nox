using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewPercentage : ComponentBase
{
    #region Declarations

    [Parameter]
    public decimal? Percentage { get; set; }

    [Parameter]
    public string Format { get; set; } = "#.##";

    public string DisplayPercentage
    {
        get
        {
            if (Percentage != null
                && Percentage >= -100
                && Percentage <= 100)
            {
                return Percentage?.ToString(Format) + "%";
            }

            return String.Empty;
        }
    }

    #endregion
}