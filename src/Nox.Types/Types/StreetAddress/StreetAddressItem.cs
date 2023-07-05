namespace Nox.Types;

/// <summary>
/// Introduces POCO object to hold address data.
/// </summary>
public class StreetAddressItem
{
    public int StreetNumber { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string AddressLine2 { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public string Locality { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string AdministrativeArea1 { get; set; } = string.Empty;
    public string AdministrativeArea2 { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public CountryCode2 CountryId { get; set; } = null!;
}