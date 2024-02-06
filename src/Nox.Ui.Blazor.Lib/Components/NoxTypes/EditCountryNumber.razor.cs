using Microsoft.AspNetCore.Components;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCountryNumber : ComponentBase
{
    [Parameter]
    public ushort? CountryNumber { get; set; }

    [Parameter]
    public string? Title { get; set; }
    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public EventCallback<ushort?> CountryNumberChanged { get; set; }

    private List<ushort> CountryNumbers { get; set; } = Nox.Types.CountryNumber.Values.ToList();

    public string ErrorRequiredMessage
    {
        get
        {
            return string.Format(Resources.Resources.FieldIsRequired, Title).Trim();
        }
    }

    protected async Task OnCountryNumberChanged(string newValue)
    {
        if (ushort.TryParse(newValue, out ushort parsedShort))
        {
            CountryNumber = parsedShort;
        }
        else
        {
            CountryNumber = null;
        }
        await CountryNumberChanged.InvokeAsync(CountryNumber);
    }
}