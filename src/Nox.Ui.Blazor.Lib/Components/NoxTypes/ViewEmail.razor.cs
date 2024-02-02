using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewEmail : ComponentBase
{
    #region Declarations

    [Parameter]
    public string? Email { get; set; }

    #endregion
}