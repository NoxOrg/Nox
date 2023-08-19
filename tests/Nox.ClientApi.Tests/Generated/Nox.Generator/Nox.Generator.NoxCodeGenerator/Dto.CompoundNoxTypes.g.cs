// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Application.Dto;

[Owned]
public record StreetAddressDto(System.Int32 StreetNumber,System.String AddressLine1,System.String AddressLine2,System.String Route,System.String Locality,System.String Neighborhood,System.String AdministrativeArea1,System.String AdministrativeArea2,System.String PostalCode,System.String CountryId);

[Owned]
public record FileDto(System.String Url,System.String PrettyName,System.UInt64 SizeInBytes);

[Owned]
public record TranslatedTextDto(System.String CultureCode,System.String Phrase);

[Owned]
public record VatNumberDto(System.String Number,System.String CountryCode2);

[Owned]
public record PasswordDto(System.String HashedPassword,System.String Salt);

[Owned]
public record EntityDto(System.String Type,System.UInt32 Id);

[Owned]
public record MoneyDto(System.Decimal Amount,Nox.Types.CurrencyCode CurrencyCode);

[Owned]
public record ImageDto(System.String Url,System.String PrettyName,System.Int32 SizeInBytes);

[Owned]
public record HashedTextDto(System.String HashText,System.String Salt);

[Owned]
public record DateTimeRangeDto(System.DateTimeOffset From,System.DateTimeOffset To);

[Owned]
public record LatLongDto(System.Double Latitude,System.Double Longitude);

