using Microsoft.AspNetCore.Components;
using Nox.Types;
using Nox.Ui.Blazor.Lib.Models;
using Nox.Ui.Blazor.Lib.Models.NoxTypes;

namespace Nox.Ui.Blazor.Lib.Components.NoxTypes;

public partial class ViewStreetAddress : ComponentBase
{

    #region Declarations

    [Parameter]
    public StreetAddressModel? StreetAddress { get; set; }

    [Parameter]
    public List<CountryModel> CountrySelectionList { get; set; } = new();

    #endregion

    public string DisplayStreetAddress
    {
        get
        {
            string rtnStreetAddress = String.Empty;

            if (StreetAddress == null)
                return rtnStreetAddress;

            var streetAddressParts = new List<string>();

            AddNonEmpty(StreetAddress.StreetNumber, streetAddressParts);
            AddNonEmpty(StreetAddress.AddressLine1, streetAddressParts);
            AddNonEmpty(StreetAddress.AddressLine2, streetAddressParts);
            AddNonEmpty(StreetAddress.Route, streetAddressParts);
            AddNonEmpty(StreetAddress.Locality, streetAddressParts);
            AddNonEmpty(StreetAddress.Neighborhood, streetAddressParts);
            AddNonEmpty(StreetAddress.AdministrativeArea1, streetAddressParts);
            AddNonEmpty(StreetAddress.AdministrativeArea2, streetAddressParts);
            AddNonEmpty(StreetAddress.PostalCode, streetAddressParts);

            if (!String.IsNullOrWhiteSpace(StreetAddress.CountryId.ToString()) 
                && CountrySelectionList.Any())
            {
                CountryModel? foundCountry = CountrySelectionList.Find(Country => !string.IsNullOrEmpty(Country.Id) 
                && Country.Id.Equals(StreetAddress!.CountryId.ToString()));

                if (foundCountry != null)
                {
                    AddNonEmpty(foundCountry.Name, streetAddressParts);
                }
            }

            rtnStreetAddress = string.Join(", ", streetAddressParts).Trim();

            return rtnStreetAddress;
        }


    }

    private static void AddNonEmpty(string? value, List<string> parts)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            parts.Add(value.Trim());
        }
    }
}