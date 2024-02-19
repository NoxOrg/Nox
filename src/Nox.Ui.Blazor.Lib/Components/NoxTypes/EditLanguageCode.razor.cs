using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditLanguageCode : ComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public string? LanguageCode { get; set; }

    [Parameter]
    public EventCallback<string?> LanguageCodeChanged { get; set; }
}