using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCurrencyCode3 : ComponentBase
{
    [Parameter]
    public string? CurrencyCode3 { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public EventCallback<string?> CurrencyCode3Changed { get; set; }

    private List<string> CurrencyCodes { get; set; } = [.. Types.CurrencyCode3.Values.OrderBy(code => code)];

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    protected async Task OnCurrencyCode3Changed(string newValue)
    {
        CurrencyCode3 = newValue;
        await CurrencyCode3Changed.InvokeAsync(CurrencyCode3);
    }
}