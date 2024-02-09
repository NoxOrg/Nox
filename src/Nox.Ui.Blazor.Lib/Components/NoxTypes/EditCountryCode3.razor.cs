using Microsoft.AspNetCore.Components;

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

    private List<string> CountryCodes { get; set; } = Nox.Types.CountryCode3.Values.ToList();

    protected async Task OnCountryCode3Changed(string newValue)
    {
        CountryCode3 = newValue;
        await CountryCode3Changed.InvokeAsync(CountryCode3);
    }
}