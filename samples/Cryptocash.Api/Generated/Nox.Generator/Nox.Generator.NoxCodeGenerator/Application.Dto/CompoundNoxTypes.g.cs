// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace Cryptocash.Application.Dto;

[Owned]
public class StreetAddressDto: IStreetAddress, IWritableStreetAddress
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public StreetAddressDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public StreetAddressDto(System.String streetNumber,System.String addressLine1,System.String addressLine2,System.String route,System.String locality,System.String neighborhood,System.String administrativeArea1,System.String administrativeArea2,System.String postalCode,Nox.Types.CountryCode countryId)
    {
            StreetNumber = streetNumber;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Route = route;
            Locality = locality;
            Neighborhood = neighborhood;
            AdministrativeArea1 = administrativeArea1;
            AdministrativeArea2 = administrativeArea2;
            PostalCode = postalCode;
            CountryId = countryId;
    }
    public System.String? StreetNumber { get;set;}
    public System.String AddressLine1 { get;set;}
    public System.String? AddressLine2 { get;set;}
    public System.String? Route { get;set;}
    public System.String? Locality { get;set;}
    public System.String? Neighborhood { get;set;}
    public System.String? AdministrativeArea1 { get;set;}
    public System.String? AdministrativeArea2 { get;set;}
    public System.String PostalCode { get;set;}
    public Nox.Types.CountryCode CountryId { get;set;}
}
[Owned]
public class FileDto: IFile, IWritableFile
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FileDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public FileDto(System.String url,System.String prettyName,System.UInt64 sizeInBytes)
    {
            Url = url;
            PrettyName = prettyName;
            SizeInBytes = sizeInBytes;
    }
    public System.String Url { get;set;}
    public System.String PrettyName { get;set;}
    public System.UInt64 SizeInBytes { get;set;}
}
[Owned]
public class TranslatedTextDto: ITranslatedText, IWritableTranslatedText
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public TranslatedTextDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public TranslatedTextDto(System.String cultureCode,System.String phrase)
    {
            CultureCode = cultureCode;
            Phrase = phrase;
    }
    public System.String CultureCode { get;set;}
    public System.String Phrase { get;set;}
}
[Owned]
public class VatNumberDto: IVatNumber, IWritableVatNumber
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public VatNumberDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public VatNumberDto(System.String number,Nox.Types.CountryCode countryCode)
    {
            Number = number;
            CountryCode = countryCode;
    }
    public System.String Number { get;set;}
    public Nox.Types.CountryCode CountryCode { get;set;}
}
[Owned]
public class PasswordDto: IPassword, IWritablePassword
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public PasswordDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public PasswordDto(System.String hashedPassword,System.String salt)
    {
            HashedPassword = hashedPassword;
            Salt = salt;
    }
    public System.String HashedPassword { get;set;}
    public System.String Salt { get;set;}
}
[Owned]
public class EntityIdDto: IEntityId, IWritableEntityId
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public EntityIdDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public EntityIdDto(System.String type,System.UInt32 id)
    {
            Type = type;
            Id = id;
    }
    public System.String Type { get;set;}
    public System.UInt32 Id { get;set;}
}
[Owned]
public class MoneyDto: IMoney, IWritableMoney
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public MoneyDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public MoneyDto(System.Decimal amount,Nox.Types.CurrencyCode currencyCode)
    {
            Amount = amount;
            CurrencyCode = currencyCode;
    }
    public System.Decimal Amount { get;set;}
    public Nox.Types.CurrencyCode CurrencyCode { get;set;}
}
[Owned]
public class ImageDto: IImage, IWritableImage
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ImageDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public ImageDto(System.String url,System.String prettyName,System.Int32 sizeInBytes)
    {
            Url = url;
            PrettyName = prettyName;
            SizeInBytes = sizeInBytes;
    }
    public System.String Url { get;set;}
    public System.String PrettyName { get;set;}
    public System.Int32 SizeInBytes { get;set;}
}
[Owned]
public class HashedTextDto: IHashedText, IWritableHashedText
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public HashedTextDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public HashedTextDto(System.String hashText,System.String salt)
    {
            HashText = hashText;
            Salt = salt;
    }
    public System.String HashText { get;set;}
    public System.String Salt { get;set;}
}
[Owned]
public class DateTimeRangeDto: IDateTimeRange, IWritableDateTimeRange
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DateTimeRangeDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public DateTimeRangeDto(System.DateTimeOffset start,System.DateTimeOffset end)
    {
            Start = start;
            End = end;
    }
    public System.DateTimeOffset Start { get;set;}
    public System.DateTimeOffset End { get;set;}
}
[Owned]
public class LatLongDto: ILatLong, IWritableLatLong
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LatLongDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public LatLongDto(System.Double latitude,System.Double longitude)
    {
            Latitude = latitude;
            Longitude = longitude;
    }
    public System.Double Latitude { get;set;}
    public System.Double Longitude { get;set;}
}
