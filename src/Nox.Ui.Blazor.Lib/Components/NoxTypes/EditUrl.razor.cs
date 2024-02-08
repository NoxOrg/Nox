using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditUrl : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? Url { get; set; }

    [Parameter]
    public EventCallback<string?> UrlChanged { get; set; }
}