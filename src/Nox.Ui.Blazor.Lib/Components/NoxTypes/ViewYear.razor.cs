using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewYear : ComponentBase
{

    #region Declarations

    [Parameter]
    public int? Year { get; set; }

    const string Format = "####";

    const int Minimum = 0;

    const int Maximum = 9999;

    public string DisplayYear
    {
        get
        {
            if (Year != null
                && Year >= Minimum
                && Year <= Maximum)
            {
                return Year.Value.ToString(Format);
            }

            return String.Empty;
        }
    }

    #endregion
}