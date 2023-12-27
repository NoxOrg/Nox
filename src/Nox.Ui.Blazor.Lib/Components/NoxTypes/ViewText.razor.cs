using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public class UiViewText : ComponentBase
{
    #region Declarations

    [Parameter]
    public string? Text { get; set; }

    #endregion
}