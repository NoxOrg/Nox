using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using YamlDotNet.Core.Tokens;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="StreetAddress"/> type and value object.
/// </summary>
/// <remarks>Compound type that represents street address.</remarks>
public sealed class StreetAddress : ValueObject<StreetAddressItem, StreetAddress>, IStreetAddress
{
    public override StreetAddressItem Value { get; protected set; } = new();

    public static readonly ushort StreetNumberMaxLength = 32;
    public static readonly ushort AddressLine1MaxLength = 128;
    public static readonly ushort AddressLine2MaxLength = 128;
    public static readonly ushort RouteMaxLength = 64;
    public static readonly ushort LocalityMaxLength = 64;
    public static readonly ushort NeighborhoodMaxLength = 64;
    public static readonly ushort AdministrativeArea1MaxLength = 64;
    public static readonly ushort AdministrativeArea2MaxLength = 64;
    public static readonly ushort PostalCodeMaxLength = 32;

    public static StreetAddress From(IStreetAddress value)
    {
        if (value is StreetAddressItem concreteValue)
        {
            return From(concreteValue);
        }

        var mappedValue = new StreetAddressItem()
        {
            StreetNumber = value.StreetNumber,
            AddressLine1 = value.AddressLine1,
            AddressLine2 = value.AddressLine2,
            Route = value.Route,
            Locality = value.Locality,
            Neighborhood = value.Neighborhood,
            AdministrativeArea1 = value.AdministrativeArea1,
            AdministrativeArea2 = value.AdministrativeArea2,
            PostalCode = value.PostalCode,
            CountryId = value.CountryId,
        };

        return From(mappedValue);
    }

    public string StreetNumber
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

    public CountryCode CountryId
    {
        get => Value.CountryId;
        private set => Value.CountryId = value;
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        var isPostalCodeMatch = CountryPostalCodeValidator.IsValid(Value.CountryId.ToString(), Value.PostalCode);
        if (!isPostalCodeMatch)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PostalCode), $"PostalCode '{Value.PostalCode}' for country with ID '{Value.CountryId}' is invalid."));
        }

        if (string.IsNullOrEmpty(Value.CountryId.ToString()))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.CountryId), $"Could not create a Nox {nameof(StreetAddress)} type with an empty {nameof(Value.CountryId)}."));
        }
        else if (!Enum.IsDefined(Value.CountryId))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.CountryId), $"Country with ID '{Value.CountryId}' is invalid."));
        }

        if (string.IsNullOrEmpty(Value.AddressLine1))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.AddressLine1), $"Could not create a Nox {nameof(StreetAddress)} type with an empty {nameof(Value.AddressLine1)}."));
        }
        else if (Value.AddressLine1.Length > AddressLine1MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.AddressLine1), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.AddressLine1)} with length greater than max allowed length of {AddressLine1MaxLength}."));
        }

        if (string.IsNullOrEmpty(Value.PostalCode))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PostalCode), $"Could not create a Nox {nameof(StreetAddress)} type with an empty {nameof(Value.PostalCode)}."));
        }
        else if (Value.PostalCode.Length > PostalCodeMaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.PostalCode), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.PostalCode)} with length greater than max allowed length of {PostalCodeMaxLength}."));
        }

        if (Value.StreetNumber.Length > StreetNumberMaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.StreetNumber), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.StreetNumber)} with length greater than max allowed length of {StreetNumberMaxLength}."));
        }
        if (Value.AddressLine2.Length > AddressLine2MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.AddressLine2), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.AddressLine2)} with length greater than max allowed length of {AddressLine2MaxLength}."));
        }
        if (Value.Route.Length > RouteMaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Route), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.Route)} with length greater than max allowed length of {RouteMaxLength}."));
        }
        if (Value.Locality.Length > LocalityMaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Locality), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.Locality)} with length greater than max allowed length of {LocalityMaxLength}."));
        }
        if (Value.Neighborhood.Length > NeighborhoodMaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Neighborhood), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.Neighborhood)} with length greater than max allowed length of {NeighborhoodMaxLength}."));
        }
        if (Value.AdministrativeArea1.Length > AdministrativeArea1MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.AdministrativeArea1), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.AdministrativeArea1)} with length greater than max allowed length of {AdministrativeArea1MaxLength}."));
        }
        if (Value.AdministrativeArea2.Length > AdministrativeArea2MaxLength)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.AdministrativeArea2), $"Could not create a Nox {nameof(StreetAddress)} type with a {nameof(Value.AdministrativeArea2)} with length greater than max allowed length of {AdministrativeArea2MaxLength}."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(StreetNumber), StreetNumber);
        yield return new KeyValuePair<string,object>(nameof(AddressLine1), AddressLine1);
        yield return new KeyValuePair<string,object>(nameof(AddressLine2), AddressLine2);
        yield return new KeyValuePair<string,object>(nameof(Route), Route);
        yield return new KeyValuePair<string,object>(nameof(Locality), Locality);
        yield return new KeyValuePair<string,object>(nameof(Neighborhood), Neighborhood);
        yield return new KeyValuePair<string,object>(nameof(AdministrativeArea1), AdministrativeArea1 );
        yield return new KeyValuePair<string,object>(nameof(AdministrativeArea2), AdministrativeArea2 );
        yield return new KeyValuePair<string,object>(nameof(PostalCode), PostalCode);
        yield return new KeyValuePair<string,object>(nameof(CountryId), CountryId);
    }

    public override string ToString()
    {
        var addressLine = JoinStringParts(" ", Value.AddressLine1, Value.AddressLine2);
        var areaLine = JoinStringParts(" ", Value.AdministrativeArea1, Value.AdministrativeArea2, Value.PostalCode);

        return JoinStringParts(", ",
            addressLine,
            Value.Locality,
            areaLine,
            Value.CountryId.ToString());
    }

    private string JoinStringParts(string separator, params string[] parts)
    {
        return string.Join(separator, parts
            .Where(x => !string.IsNullOrWhiteSpace(x)));
    }
}