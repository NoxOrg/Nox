using Microsoft.AspNetCore.Components;
using Nox.Types;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCountryCode3 : ComponentBase
{
    [Parameter]
    public string? CountryCode3 { get; set; }

    [Parameter]
    public string? Title { get; set; }
    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public EventCallback<string?> CountryCode3Changed { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    protected async Task OnCountryCode3Changed(string newValue)
    {
        CountryCode3 = newValue;
        await CountryCode3Changed.InvokeAsync(CountryCode3);
    }
}