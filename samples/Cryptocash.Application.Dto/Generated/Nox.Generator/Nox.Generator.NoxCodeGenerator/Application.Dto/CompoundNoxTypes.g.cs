// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Dto;

namespace Cryptocash.Application.Dto;

[Owned]
public class StreetAddressDto: IStreetAddress, IWritableStreetAddress, INoxCompoundTypeDto
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public StreetAddressDto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public StreetAddressDto(System.String streetNumber,System.String addressLine1,System.String addressLine2,System.String addressLine3,System.String route,System.String locality,System.String neighborhood,System.String administrativeArea1,System.String administrativeArea2,System.String postalCode,Nox.Types.CountryCode countryId)
    {
            StreetNumber = streetNumber;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
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
    public System.String? AddressLine3 { get;set;}
    public System.String? Route { get;set;}
    public System.String? Locality { get;set;}
    public System.String? Neighborhood { get;set;}
    public System.String? AdministrativeArea1 { get;set;}
    public System.String? AdministrativeArea2 { get;set;}
    public System.String PostalCode { get;set;}
    public Nox.Types.CountryCode CountryId { get;set;}

#region UpdateFromDictionary
    public static void UpdateFromDictionary(StreetAddressDto streetAddress, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("StreetNumber", out var updatedStreetNumber))
        {
            streetAddress.StreetNumber = updatedStreetNumber;
        }
        if (updatedProperties.TryGetValue("AddressLine1", out var updatedAddressLine1))
        {
            ArgumentNullException.ThrowIfNull(updatedAddressLine1, "Property 'AddressLine1' can't be null.");
            streetAddress.AddressLine1 = updatedAddressLine1;
        }
        if (updatedProperties.TryGetValue("AddressLine2", out var updatedAddressLine2))
        {
            streetAddress.AddressLine2 = updatedAddressLine2;
        }
        if (updatedProperties.TryGetValue("AddressLine3", out var updatedAddressLine3))
        {
            streetAddress.AddressLine3 = updatedAddressLine3;
        }
        if (updatedProperties.TryGetValue("Route", out var updatedRoute))
        {
            streetAddress.Route = updatedRoute;
        }
        if (updatedProperties.TryGetValue("Locality", out var updatedLocality))
        {
            streetAddress.Locality = updatedLocality;
        }
        if (updatedProperties.TryGetValue("Neighborhood", out var updatedNeighborhood))
        {
            streetAddress.Neighborhood = updatedNeighborhood;
        }
        if (updatedProperties.TryGetValue("AdministrativeArea1", out var updatedAdministrativeArea1))
        {
            streetAddress.AdministrativeArea1 = updatedAdministrativeArea1;
        }
        if (updatedProperties.TryGetValue("AdministrativeArea2", out var updatedAdministrativeArea2))
        {
            streetAddress.AdministrativeArea2 = updatedAdministrativeArea2;
        }
        if (updatedProperties.TryGetValue("PostalCode", out var updatedPostalCode))
        {
            ArgumentNullException.ThrowIfNull(updatedPostalCode, "Property 'PostalCode' can't be null.");
            streetAddress.PostalCode = updatedPostalCode;
        }
        if (updatedProperties.TryGetValue("CountryId", out var updatedCountryId))
        {
            ArgumentNullException.ThrowIfNull(updatedCountryId, "Property 'CountryId' can't be null.");
            streetAddress.CountryId = updatedCountryId;
        }
    }
#endregion

}
[Owned]
public class FileDto: IFile, IWritableFile, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(FileDto file, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Url", out var updatedUrl))
        {
            ArgumentNullException.ThrowIfNull(updatedUrl, "Property 'Url' can't be null.");
            file.Url = updatedUrl;
        }
        if (updatedProperties.TryGetValue("PrettyName", out var updatedPrettyName))
        {
            ArgumentNullException.ThrowIfNull(updatedPrettyName, "Property 'PrettyName' can't be null.");
            file.PrettyName = updatedPrettyName;
        }
        if (updatedProperties.TryGetValue("SizeInBytes", out var updatedSizeInBytes))
        {
            ArgumentNullException.ThrowIfNull(updatedSizeInBytes, "Property 'SizeInBytes' can't be null.");
            file.SizeInBytes = updatedSizeInBytes;
        }
    }
#endregion

}
[Owned]
public class TranslatedTextDto: ITranslatedText, IWritableTranslatedText, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(TranslatedTextDto translatedText, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("CultureCode", out var updatedCultureCode))
        {
            ArgumentNullException.ThrowIfNull(updatedCultureCode, "Property 'CultureCode' can't be null.");
            translatedText.CultureCode = updatedCultureCode;
        }
        if (updatedProperties.TryGetValue("Phrase", out var updatedPhrase))
        {
            ArgumentNullException.ThrowIfNull(updatedPhrase, "Property 'Phrase' can't be null.");
            translatedText.Phrase = updatedPhrase;
        }
    }
#endregion

}
[Owned]
public class VatNumberDto: IVatNumber, IWritableVatNumber, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(VatNumberDto vatNumber, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Number", out var updatedNumber))
        {
            ArgumentNullException.ThrowIfNull(updatedNumber, "Property 'Number' can't be null.");
            vatNumber.Number = updatedNumber;
        }
        if (updatedProperties.TryGetValue("CountryCode", out var updatedCountryCode))
        {
            ArgumentNullException.ThrowIfNull(updatedCountryCode, "Property 'CountryCode' can't be null.");
            vatNumber.CountryCode = updatedCountryCode;
        }
    }
#endregion

}
[Owned]
public class PasswordDto: IPassword, IWritablePassword, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(PasswordDto password, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("HashedPassword", out var updatedHashedPassword))
        {
            ArgumentNullException.ThrowIfNull(updatedHashedPassword, "Property 'HashedPassword' can't be null.");
            password.HashedPassword = updatedHashedPassword;
        }
        if (updatedProperties.TryGetValue("Salt", out var updatedSalt))
        {
            ArgumentNullException.ThrowIfNull(updatedSalt, "Property 'Salt' can't be null.");
            password.Salt = updatedSalt;
        }
    }
#endregion

}
[Owned]
public class EntityIdDto: IEntityId, IWritableEntityId, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(EntityIdDto entityId, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Type", out var updatedType))
        {
            ArgumentNullException.ThrowIfNull(updatedType, "Property 'Type' can't be null.");
            entityId.Type = updatedType;
        }
        if (updatedProperties.TryGetValue("Id", out var updatedId))
        {
            ArgumentNullException.ThrowIfNull(updatedId, "Property 'Id' can't be null.");
            entityId.Id = updatedId;
        }
    }
#endregion

}
[Owned]
public class MoneyDto: IMoney, IWritableMoney, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(MoneyDto money, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Amount", out var updatedAmount))
        {
            ArgumentNullException.ThrowIfNull(updatedAmount, "Property 'Amount' can't be null.");
            money.Amount = updatedAmount;
        }
        if (updatedProperties.TryGetValue("CurrencyCode", out var updatedCurrencyCode))
        {
            ArgumentNullException.ThrowIfNull(updatedCurrencyCode, "Property 'CurrencyCode' can't be null.");
            money.CurrencyCode = updatedCurrencyCode;
        }
    }
#endregion

}
[Owned]
public class ImageDto: IImage, IWritableImage, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(ImageDto image, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Url", out var updatedUrl))
        {
            ArgumentNullException.ThrowIfNull(updatedUrl, "Property 'Url' can't be null.");
            image.Url = updatedUrl;
        }
        if (updatedProperties.TryGetValue("PrettyName", out var updatedPrettyName))
        {
            ArgumentNullException.ThrowIfNull(updatedPrettyName, "Property 'PrettyName' can't be null.");
            image.PrettyName = updatedPrettyName;
        }
        if (updatedProperties.TryGetValue("SizeInBytes", out var updatedSizeInBytes))
        {
            ArgumentNullException.ThrowIfNull(updatedSizeInBytes, "Property 'SizeInBytes' can't be null.");
            image.SizeInBytes = updatedSizeInBytes;
        }
    }
#endregion

}
[Owned]
public class HashedTextDto: IHashedText, IWritableHashedText, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(HashedTextDto hashedText, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("HashText", out var updatedHashText))
        {
            ArgumentNullException.ThrowIfNull(updatedHashText, "Property 'HashText' can't be null.");
            hashedText.HashText = updatedHashText;
        }
        if (updatedProperties.TryGetValue("Salt", out var updatedSalt))
        {
            ArgumentNullException.ThrowIfNull(updatedSalt, "Property 'Salt' can't be null.");
            hashedText.Salt = updatedSalt;
        }
    }
#endregion

}
[Owned]
public class DateTimeRangeDto: IDateTimeRange, IWritableDateTimeRange, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(DateTimeRangeDto dateTimeRange, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Start", out var updatedStart))
        {
            ArgumentNullException.ThrowIfNull(updatedStart, "Property 'Start' can't be null.");
            dateTimeRange.Start = updatedStart;
        }
        if (updatedProperties.TryGetValue("End", out var updatedEnd))
        {
            ArgumentNullException.ThrowIfNull(updatedEnd, "Property 'End' can't be null.");
            dateTimeRange.End = updatedEnd;
        }
    }
#endregion

}
[Owned]
public class LatLongDto: ILatLong, IWritableLatLong, INoxCompoundTypeDto
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

#region UpdateFromDictionary
    public static void UpdateFromDictionary(LatLongDto latLong, Dictionary<string, dynamic> updatedProperties)
    {
        if (updatedProperties.TryGetValue("Latitude", out var updatedLatitude))
        {
            ArgumentNullException.ThrowIfNull(updatedLatitude, "Property 'Latitude' can't be null.");
            latLong.Latitude = updatedLatitude;
        }
        if (updatedProperties.TryGetValue("Longitude", out var updatedLongitude))
        {
            ArgumentNullException.ThrowIfNull(updatedLongitude, "Property 'Longitude' can't be null.");
            latLong.Longitude = updatedLongitude;
        }
    }
#endregion

}
