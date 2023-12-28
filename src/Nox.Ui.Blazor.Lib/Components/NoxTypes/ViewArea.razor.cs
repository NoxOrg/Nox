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
            if (Area != null)
            {
                switch (Area)
                {
                    case < 0:
                        float rtnMinusArea = 0;
                        return rtnMinusArea.ToString(Format) + DisplayAreaUnit();
                    default:
                        return Area?.ToString(Format) + DisplayAreaUnit();
                }
            }

            return String.Empty;
        }
    }

    private string DisplayAreaUnit()
    {
        switch(AreaUnit)
        ...
        {
            return " " + AreaUnit.SquareFoot.Symbol;
        }

        if (AreaUnit == AreaUnit.SquareMeter)
        {
            return " " + AreaUnit.SquareMeter.Symbol;
        }

        return String.Empty;
    }

    #endregion
}