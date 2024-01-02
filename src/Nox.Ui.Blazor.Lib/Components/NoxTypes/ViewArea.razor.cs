using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewArea : ComponentBase
{

    #region Declarations

    [Parameter]
    public Decimal? Area { get; set; }

    [Parameter]
    public AreaUnit AreaUnit { get; set; } = AreaUnit.SquareMeter;

    [Parameter]
    public string Format { get; set; } = "#,##0.##";

    public string DisplayArea
    {

        get
        {
            if (Area != null
                && Area > 0)
            {
                return Area?.ToString(Format) + " " + DisplayAreaUnit();
            }

            return string.Empty;
        }
    }

    private string DisplayAreaUnit()
    {
        if (AreaUnit == AreaUnit.SquareFoot)
        {
            return AreaUnit.SquareFoot.Symbol;
        }

        if (AreaUnit == AreaUnit.SquareMeter)
        {
            return AreaUnit.SquareMeter.Symbol;
        }

        return String.Empty;       
    }

    #endregion
}