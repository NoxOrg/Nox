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

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public bool Required { get; set; } = false;

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }
}