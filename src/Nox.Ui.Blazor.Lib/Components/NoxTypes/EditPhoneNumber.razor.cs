using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditPhoneNumber : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? PhoneNumber { get; set; }

    [Parameter]
    public EventCallback<string?> PhoneNumberChanged { get; set; }
}