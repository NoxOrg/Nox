using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditTimeZoneCode : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }
}