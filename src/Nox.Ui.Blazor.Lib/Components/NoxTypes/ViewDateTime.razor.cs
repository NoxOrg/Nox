using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewDateTime : ComponentBase
{

    #region Declarations

    [Parameter]
    public System.DateTime? DateTime { get; set; }

    [Parameter]
    public string Format { get; set; } = "dd/MM/yyyy HH:mm:ss";

    [Parameter]
    public CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;

    #endregion
}