using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDate : ComponentBase
{

    #region Declarations

    [Parameter]
    public System.DateTime? Date { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy";

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    #endregion
}