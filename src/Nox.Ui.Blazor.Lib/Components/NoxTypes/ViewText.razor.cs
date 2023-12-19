using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewText : ComponentBase
{
    #region Declarations

    [Parameter]
    public string? Text { get; set; }

    #endregion
}