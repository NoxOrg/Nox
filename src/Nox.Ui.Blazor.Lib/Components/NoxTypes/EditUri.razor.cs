using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditUri : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }
}