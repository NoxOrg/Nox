// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace Cryptocash.Application.Dto;

[Owned]
public record StreetAddressDto(System.String StreetNumber,System.String AddressLine1,System.String AddressLine2,System.String Route,System.String Locality,System.String Neighborhood,System.String AdministrativeArea1,System.String AdministrativeArea2,System.String PostalCode,Nox.Types.CountryCode CountryId) : IStreetAddress;

[Owned]
public record FileDto(System.String Url,System.String PrettyName,System.UInt64 SizeInBytes) : IFile;

[Owned]
public record TranslatedTextDto(System.String CultureCode,System.String Phrase) : ITranslatedText;

[Owned]
public record VatNumberDto(System.String Number,Nox.Types.CountryCode CountryCode) : IVatNumber;

[Owned]
public record PasswordDto(System.String HashedPassword,System.String Salt) : IPassword;

[Owned]
public record EntityIdDto(System.String Type,System.UInt32 Id) : IEntityId;

[Owned]
public record MoneyDto(System.Decimal Amount,Nox.Types.CurrencyCode CurrencyCode) : IMoney;

[Owned]
public record ImageDto(System.String Url,System.String PrettyName,System.Int32 SizeInBytes) : IImage;

[Owned]
public record HashedTextDto(System.String HashText,System.String Salt) : IHashedText;

[Owned]
public record DateTimeRangeDto(System.DateTimeOffset Start,System.DateTimeOffset End) : IDateTimeRange;

[Owned]
public record LatLongDto(System.Double Latitude,System.Double Longitude) : ILatLong;

