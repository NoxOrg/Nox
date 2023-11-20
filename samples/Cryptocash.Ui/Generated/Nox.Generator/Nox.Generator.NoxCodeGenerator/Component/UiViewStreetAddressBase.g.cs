using Microsoft.AspNetCore.Components;
using Cryptocash.Application.Dto;
using Microsoft.SqlServer.Server;
using Nox.Types;

namespace Cryptocash.Ui.Generated.Component
{
#nullable enable

    public class UiViewStreetAddressBase : ComponentBase
    {
        #region Declarations

        [Parameter]
        public StreetAddressDto? StreetAddress { get; set; }

        [Parameter]
        public List<CountryDto>? CountrySelectionList { get; set; }

        #endregion

         public string DisplayStreetAddress
        {
            get
            {
                string RtnStreetAddress = String.Empty;

                if (StreetAddress == null)
                    return RtnStreetAddress;

                var StreetAddressParts = new List<string>();

                AddNonEmpty(StreetAddress.StreetNumber, StreetAddressParts);
                AddNonEmpty(StreetAddress.AddressLine1, StreetAddressParts);
                AddNonEmpty(StreetAddress.AddressLine2, StreetAddressParts);
                AddNonEmpty(StreetAddress.Route, StreetAddressParts);
                AddNonEmpty(StreetAddress.Locality, StreetAddressParts);
                AddNonEmpty(StreetAddress.Neighborhood, StreetAddressParts);
                AddNonEmpty(StreetAddress.AdministrativeArea1, StreetAddressParts);
                AddNonEmpty(StreetAddress.AdministrativeArea2, StreetAddressParts);
                AddNonEmpty(StreetAddress.PostalCode, StreetAddressParts);

                if (!String.IsNullOrWhiteSpace(StreetAddress.CountryId.ToString()))
                {
                    if (CountrySelectionList != null
                        && CountrySelectionList.Count > 0)
                    {
                        CountryDto? FoundCountry = CountrySelectionList.FirstOrDefault(Country => Country.Id.Equals(StreetAddress!.CountryId.ToString()));

                        if (FoundCountry != null)
                        {
                            AddNonEmpty(FoundCountry.Name.Trim(), StreetAddressParts);
                        }
                    }
                }

                RtnStreetAddress = string.Join(", ", StreetAddressParts).Trim();

                return RtnStreetAddress;
            }


        }

        private void AddNonEmpty(string? value, List<string> parts)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                parts.Add(value.Trim());
            }
        }
    }
}