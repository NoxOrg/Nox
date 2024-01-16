using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewCountry : ComponentBase
{
    #region Declarations

    [Parameter]
    public CountryModel? Country { get; set; }

    public string DisplayCountryName
    {
        get
        {
            if (Country != null
                && !String.IsNullOrWhiteSpace(Country.Name))
            {
                return Country.Name;
            }

            return String.Empty;
        }
    }

    #endregion
}