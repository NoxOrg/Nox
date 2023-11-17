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

                if (StreetAddress != null)
                {
                    if (!String.IsNullOrWhiteSpace(StreetAddress.StreetNumber))
                    {
                        RtnStreetAddress = StreetAddress.StreetNumber.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.AddressLine1))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.AddressLine1.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.AddressLine2))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.AddressLine2.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.Route))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.Route.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.Locality))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.Locality.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.Neighborhood))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.Neighborhood.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.AdministrativeArea1))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.AdministrativeArea1.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.AdministrativeArea2))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.AdministrativeArea2.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.PostalCode))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }
                        RtnStreetAddress += StreetAddress.PostalCode.Trim();
                    }

                    if (!String.IsNullOrWhiteSpace(StreetAddress.CountryId.ToString()))
                    {
                        if (!String.IsNullOrWhiteSpace(RtnStreetAddress))
                        {
                            RtnStreetAddress += ", ";
                        }

                        if (CountrySelectionList != null 
                            && CountrySelectionList.Count > 0)
                        {
                            CountryDto? FoundCountry = CountrySelectionList.FirstOrDefault(Country => Country.Id.Equals(StreetAddress!.CountryId.ToString()));

                            if (FoundCountry != null
                                && !String.IsNullOrWhiteSpace(FoundCountry.Name))
                            {
                                RtnStreetAddress += FoundCountry.Name.Trim();
                            }
                        }                        
                    }
                }

                return RtnStreetAddress;
            }
        }
    }
}