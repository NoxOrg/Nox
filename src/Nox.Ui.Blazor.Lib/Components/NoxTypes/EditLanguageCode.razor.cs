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