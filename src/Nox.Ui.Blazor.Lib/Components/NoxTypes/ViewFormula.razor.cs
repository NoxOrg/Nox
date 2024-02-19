using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewFormula : ComponentBase
{
    [Parameter]
    public string? Formula { get; set; }
}