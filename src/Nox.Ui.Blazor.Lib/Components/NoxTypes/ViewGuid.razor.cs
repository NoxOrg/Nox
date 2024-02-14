using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewGuid : ComponentBase
{
    [Parameter]
    public Guid? Guid { get; set; }
}