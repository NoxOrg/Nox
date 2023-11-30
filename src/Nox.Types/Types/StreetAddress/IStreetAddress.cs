namespace Nox.Types;

public interface IStreetAddress
{
    string AddressLine1 { get; }
    string? AddressLine2 { get; }
    string? AdministrativeArea1 { get; }
    string? AdministrativeArea2 { get; }
    CountryCode CountryId { get; }
    string? Locality { get; }
    string? Neighborhood { get; }
    string PostalCode { get; }
    string? Route { get; }
    string? StreetNumber { get; }
}
public interface IWritableStreetAddress
{
    string AddressLine1 { set; }
    string? AddressLine2 { set; }
    string? AdministrativeArea1 { set; }
    string? AdministrativeArea2 { set; }
    CountryCode CountryId { set; }
    string? Locality { set; }
    string? Neighborhood { set; }
    string PostalCode { set; }
    string? Route { set; }
    string? StreetNumber { set; }
}