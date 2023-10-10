// Generated

#nullable enable
using Nox.Types;

namespace ClientApi.Application.Dto;

internal static class CompoundNoxTypesExtensions
{
    public static StreetAddressDto ToDto(this Nox.Types.StreetAddress StreetAddress)
        => new(StreetAddress.StreetNumber, StreetAddress.AddressLine1, StreetAddress.AddressLine2, StreetAddress.Route, StreetAddress.Locality, StreetAddress.Neighborhood, StreetAddress.AdministrativeArea1, StreetAddress.AdministrativeArea2, StreetAddress.PostalCode, StreetAddress.CountryId);

    public static FileDto ToDto(this Nox.Types.File File)
        => new(File.Url, File.PrettyName, File.SizeInBytes);

    public static TranslatedTextDto ToDto(this Nox.Types.TranslatedText TranslatedText)
        => new(TranslatedText.CultureCode, TranslatedText.Phrase);

    public static VatNumberDto ToDto(this Nox.Types.VatNumber VatNumber)
        => new(VatNumber.Number, VatNumber.CountryCode);

    public static PasswordDto ToDto(this Nox.Types.Password Password)
        => new(Password.HashedPassword, Password.Salt);

    public static MoneyDto ToDto(this Nox.Types.Money Money)
        => new(Money.Amount, Money.CurrencyCode);

    public static ImageDto ToDto(this Nox.Types.Image Image)
        => new(Image.Url, Image.PrettyName, Image.SizeInBytes);

    public static HashedTextDto ToDto(this Nox.Types.HashedText HashedText)
        => new(HashedText.HashText, HashedText.Salt);

    public static DateTimeRangeDto ToDto(this Nox.Types.DateTimeRange DateTimeRange)
        => new(DateTimeRange.Start, DateTimeRange.End);

    public static LatLongDto ToDto(this Nox.Types.LatLong LatLong)
        => new(LatLong.Latitude, LatLong.Longitude);

}