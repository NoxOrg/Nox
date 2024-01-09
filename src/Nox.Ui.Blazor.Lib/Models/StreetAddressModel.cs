using Nox.Types;
namespace Nox.Ui.Blazor.Lib.Models;

public class StreetAddressModel
{
    public string? StreetNumber { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? Route { get; set; }

    public string? Locality { get; set; }

    public string? Neighborhood { get; set; }

    public string? AdministrativeArea1 { get; set; }

    public string? AdministrativeArea2 { get; set; }

    public string? PostalCode { get; set; }

    public string? CountryIdStr { get; set; }

    public Nox.Types.CountryCode? CountryId { get; set; }
}
