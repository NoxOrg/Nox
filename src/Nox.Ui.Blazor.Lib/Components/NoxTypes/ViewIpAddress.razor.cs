using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewIpAddress : ComponentBase
{

    #region Declarations

    [Parameter]
    public string? IpAddress { get; set; }

    #endregion
}