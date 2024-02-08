using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditColor : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }
}