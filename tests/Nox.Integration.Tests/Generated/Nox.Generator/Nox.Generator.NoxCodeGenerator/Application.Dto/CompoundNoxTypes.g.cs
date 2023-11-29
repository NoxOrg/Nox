// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Application.Dto;

[Owned]
public record StreetAddressDto: IStreetAddress
{    
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
public record FileDto: IFile
{    
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
public record TranslatedTextDto: ITranslatedText
{    
    public TranslatedTextDto(System.String cultureCode,System.String phrase)
    {
            CultureCode = cultureCode;
            Phrase = phrase;
    }
    public System.String CultureCode { get;set;}
    public System.String Phrase { get;set;}
}
[Owned]
public record VatNumberDto: IVatNumber
{    
    public VatNumberDto(System.String number,Nox.Types.CountryCode countryCode)
    {
            Number = number;
            CountryCode = countryCode;
    }
    public System.String Number { get;set;}
    public Nox.Types.CountryCode CountryCode { get;set;}
}
[Owned]
public record PasswordDto: IPassword
{    
    public PasswordDto(System.String hashedPassword,System.String salt)
    {
            HashedPassword = hashedPassword;
            Salt = salt;
    }
    public System.String HashedPassword { get;set;}
    public System.String Salt { get;set;}
}
[Owned]
public record EntityIdDto: IEntityId
{    
    public EntityIdDto(System.String type,System.UInt32 id)
    {
            Type = type;
            Id = id;
    }
    public System.String Type { get;set;}
    public System.UInt32 Id { get;set;}
}
[Owned]
public record MoneyDto: IMoney
{    
    public MoneyDto(System.Decimal amount,Nox.Types.CurrencyCode currencyCode)
    {
            Amount = amount;
            CurrencyCode = currencyCode;
    }
    public System.Decimal Amount { get;set;}
    public Nox.Types.CurrencyCode CurrencyCode { get;set;}
}
[Owned]
public record ImageDto: IImage
{    
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
public record HashedTextDto: IHashedText
{    
    public HashedTextDto(System.String hashText,System.String salt)
    {
            HashText = hashText;
            Salt = salt;
    }
    public System.String HashText { get;set;}
    public System.String Salt { get;set;}
}
[Owned]
public record DateTimeRangeDto: IDateTimeRange
{    
    public DateTimeRangeDto(System.DateTimeOffset start,System.DateTimeOffset end)
    {
            Start = start;
            End = end;
    }
    public System.DateTimeOffset Start { get;set;}
    public System.DateTimeOffset End { get;set;}
}
[Owned]
public record LatLongDto: ILatLong
{    
    public LatLongDto(System.Double latitude,System.Double longitude)
    {
            Latitude = latitude;
            Longitude = longitude;
    }
    public System.Double Latitude { get;set;}
    public System.Double Longitude { get;set;}
}
