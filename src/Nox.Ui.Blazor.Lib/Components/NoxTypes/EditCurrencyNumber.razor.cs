using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCurrencyNumber : ComponentBase
{
    [Parameter]
    public short? CurrencyNumber { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public EventCallback<short?> CurrencyNumberChanged { get; set; }

    private List<short> CurrencyNumbers { get; set; } = [.. Types.CurrencyNumber.Values];

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    protected async Task OnCurrencyNumberChanged(string newValue)
    {
        if (short.TryParse(newValue, out short parsedShort))
        {
            CurrencyNumber = parsedShort;
        }
        else
        {
            CurrencyNumber = null;
        }
        await CurrencyNumberChanged.InvokeAsync(CurrencyNumber);
    }
}