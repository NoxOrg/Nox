using Microsoft.AspNetCore.Components;
using System.Collections.Immutable;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCountryCode2 : ComponentBase
{
    [Parameter]
    public string? CountryCode2 { get; set; }

    [Parameter]
    public string? Title { get; set; }
    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public EventCallback<string?> CountryCode2Changed { get; set; }

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    private List<string> CountryCodes { get; set; } = [.. Types.CountryCode2.Values.OrderBy(code => code)];

    protected async Task OnCountryCode2Changed(string newValue)
    {
        CountryCode2 = newValue;
        await CountryCode2Changed.InvokeAsync(CountryCode2);
    }
}