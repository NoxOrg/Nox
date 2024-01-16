using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class EditCountry : ComponentBase
{

    #region Declarations

    [Parameter]
    public CountryModel? Country { get; set; }

    [Parameter]
    public string? CountryId { get; set; }

    public string? CurrentCountryIdStr { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public List<CountryModel> CountrySelectionList { get; set; } = new();

    [Parameter]
    public EventCallback<CountryModel> CountryChanged { get; set; }

    [Parameter]
    public EventCallback<string?> CountryIdChanged { get; set; }

    #endregion

    /// <summary>
    /// Handles initial loading
    /// </summary>
    protected override void OnInitialized()
    {
        if (!String.IsNullOrWhiteSpace(CountryId))
        {
            CurrentCountryIdStr = CountryId;
        }
    }

    protected async Task OnCountryIdChanged(string newValue)
    {
        CurrentCountryIdStr = newValue;

        Country = CountrySelectionList.Find(Country => string.Equals(Country.Id, CurrentCountryIdStr, StringComparison.OrdinalIgnoreCase));
        await CountryChanged.InvokeAsync(Country);

        if (Country != null
            && !String.IsNullOrWhiteSpace(Country.Id))
        {
            CountryId = Country.Id;
            await CountryIdChanged.InvokeAsync(CountryId);
        }
    }

    protected static string? ErrorRequiredMessage(string? currentTitle)
    {
        return string.Format(Resources.Resources.FieldIsRequired, currentTitle).Trim();
    }
}