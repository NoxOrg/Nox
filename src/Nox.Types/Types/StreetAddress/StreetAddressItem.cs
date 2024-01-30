namespace Nox.Types;

/// <summary>
/// Introduces POCO object to hold address data.
/// </summary>
public class StreetAddressItem 
{
    public string? StreetNumber { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; } = string.Empty;
    public string? AddressLine3 { get; set; } = string.Empty;
    public string? Route { get; set; } = string.Empty;
    public string? Locality { get; set; } = string.Empty;
    public string? Neighborhood { get; set; } = string.Empty;
    public string? AdministrativeArea1 { get; set; } = string.Empty;
    public string? AdministrativeArea2 { get; set; } = string.Empty;
    public string? PostalCode { get; set; } = string.Empty;
    public CountryCode CountryId { get; set; }
}