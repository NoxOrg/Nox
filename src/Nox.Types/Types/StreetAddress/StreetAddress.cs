using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="StreetAddress"/> type and value object.
/// </summary>
/// <remarks>Compound type that represents street address.</remarks>
public sealed class StreetAddress : ValueObject<StreetAddressItem, StreetAddress>
{
    public override StreetAddressItem Value { get; protected set; } = new StreetAddressItem();

    public int StreetNumber
    {
        get => Value.StreetNumber;
        private set => Value.StreetNumber = value;
    }

    public string AddressLine1
    {
        get => Value.AddressLine1;
        private set => Value.AddressLine1 = value;
    }

    public string AddressLine2
    {
        get => Value.AddressLine2;
        private set => Value.AddressLine2 = value;
    }

    public string Route
    {
        get => Value.Route;
        private set => Value.Route = value;
    }

    public string Locality
    {
        get => Value.Locality;
        private set => Value.Locality = value;
    }

    public string Neighborhood
    {
        get => Value.Neighborhood;
        private set => Value.Neighborhood = value;
    }

    public string AdministrativeArea1
    {
        get => Value.AdministrativeArea1;
        private set => Value.AdministrativeArea1 = value;
    }

    public string AdministrativeArea2
    {
        get => Value.AdministrativeArea2;
        private set => Value.AdministrativeArea2 = value;
    }

    public string PostalCode
    {
        get => Value.PostalCode;
        private set => Value.PostalCode = value;
    }

    public CountryCode2 CountryId
    {
        get => Value.CountryId;
        private set => Value.CountryId = value;
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        var isPostalCodeMatch = CountryPostalCodeValidator.IsValid(Value.CountryId.Value, Value.PostalCode);
        if (!isPostalCodeMatch)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PostalCode), "PostalCode value doesn't match valid postal code pattern."));
        }

        var countryValidation = Value.CountryId.Validate();
        result.Errors.AddRange(countryValidation.Errors);

        return result;
    }

    public override string ToString()
    {
        var addressLine = JoinStringParts(" ", Value.AddressLine1, Value.AddressLine2);
        var areaLine = JoinStringParts(" ", Value.AdministrativeArea1, Value.AdministrativeArea2, Value.PostalCode);

        return JoinStringParts(", ",
            addressLine,
            Value.Locality,
            areaLine,
            Value.CountryId.Value ?? string.Empty);
    }

    private string JoinStringParts(string separator, params string[] parts)
    {
        return string.Join(separator, parts
            .Where(x => !string.IsNullOrWhiteSpace(x)));
    }
}