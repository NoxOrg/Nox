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