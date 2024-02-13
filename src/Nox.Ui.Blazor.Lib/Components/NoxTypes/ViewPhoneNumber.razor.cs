using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewPhoneNumber : ComponentBase
{
    [Parameter]
    public string? PhoneNumber { get; set; }
}