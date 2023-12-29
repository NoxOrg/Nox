using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewNumber : ComponentBase
{

    #region Declarations

    [Parameter]
    public decimal? Number { get; set; }

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayNumber
    {
        get
        {
            if (Number.HasValue)
            {
                return Number.Value.ToString(Format);
            }

            return String.Empty;
        }
    }

    #endregion
}