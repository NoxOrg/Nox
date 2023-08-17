using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types.EntityFramework;
using Nox.Types.EntityFramework.Types;
using Nox.Types.EntityFramework.Types.DayOfWeek;

namespace Nox.Types.Tests.EntityFrameworkTests;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);

        // Configure Single-value ValueObjects
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CountryId.From(v));
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255).HasConversion<TextConverter>();
        builder.Property(e => e.Population).HasConversion<NumberToInt32Converter>();
        builder.Property(e => e.CountryCode2).HasConversion<CountryCode2Converter>();
        builder.Property(e => e.AreaInSqKm).HasConversion<AreaToSquareMeterConverter>();
        builder.Property(e => e.CultureCode).HasConversion<CultureCodeConverter>();
        builder.Property(e => e.CountryNumber).HasMaxLength(3).HasConversion<CountryNumberConverter>();
        builder.Property(e => e.MonthOfPeakTourism).HasConversion<MonthConverter>();
        builder.Property(e => e.DistanceInKm).HasConversion<DistanceToKilometerConverter>();
        builder.Property(e => e.InternetDomain).HasConversion<InternetDomainConverter>();
        builder.Property(e => e.CountryCode3).HasConversion<CountryCode3Converter>();
        builder.Property(e => e.IPAddress).HasConversion<IpAddressConverter>();
        builder.Property(e => e.LongestHikingTrailInMeters).HasConversion<LengthToMeterConverter>();
        builder.Property(e => e.MACAddress).HasConversion<MacAddressConverter>();
        builder.Property(e => e.StreetAddressJson).HasConversion<JsonConverter>();
        builder.Property(e => e.Date).HasConversion<DateConverter>();
        builder.Property(e => e.LocalTimeZone).HasConversion<TimeZoneCodeConverter>();
        builder.Property(e => e.Uri).HasConversion<UriConverter>();
        builder.Property(e => e.Url).HasConversion<UrlConverter>();
        builder.Property(e => e.IsLandLocked).HasConversion<BooleanConverter>();
        builder.Property(e => e.DateTimeDuration).HasConversion<DateTimeDurationConverter>();
        builder.Property(e => e.VolumeInCubicMeters).HasConversion<VolumeToCubicMetersConverter>();
        builder.Property(e => e.WeightInKilograms).HasConversion<WeightToKilogramsConverter>();
        builder.Property(e => e.Nuid).HasConversion<NuidConverter>();
        builder.Property(e => e.CurrentTime).HasConversion<TimeConverter>();
        builder.Property(e => e.AverageTemperatureInCelsius).HasConversion<TemperatureToCelsiusConverter>();
        builder.Property(e => e.Description).HasConversion<MarkdownConverter>();
        builder.Property(e => e.PageHtml).HasConversion<HtmlConverter>();
        builder.Property(e => e.CitiesCounties).HasConversion<YamlConverter>();
        builder.Property(e => e.PhoneNumber).HasConversion<PhoneNumberConverter>();
        builder.Property(e => e.GuidUser).HasConversion<UserConverter>();
        builder.Property(e => e.EmailUser).HasConversion<UserConverter>();
        builder.Property(e => e.StringUser).HasConversion<UserConverter>();
        builder.Property(e => e.InfoEmail).HasConversion<EmailConverter>();
        builder.Property(e => e.SecretPassword).HasConversion<EncryptedTextConverter>();
        builder.Property(e => e.DatabaseId).ValueGeneratedOnAdd().HasConversion<DatabaseNumberConverter>();
        builder.Property(e => e.CurrencyNumber).HasConversion<CurrencyNumberConverter>();
        builder.Property(e => e.Color).HasConversion<ColorConverter>();
        builder.Property(e => e.DayOfWeek).HasConversion<DayOfWeekConverter>();
        builder.Property(e => e.DateTimeSchedule).HasConversion<DateTimeScheduleConverter>();
        builder.Property(e => e.CreateDate).HasConversion<DateTimeConverter>();

        // Configure Multi-value ValueObjects
        builder.OwnsOne(e => e.LatLong).Ignore(p => p.Value);
        builder.OwnsOne(e => e.GrossDomesticProduct).Ignore(p => p.Value);
        builder.OwnsOne(e => e.DateTimeRange).Ignore(p => p.Value);
        builder.OwnsOne(e => e.File).Ignore(p => p.Value);
        builder.OwnsOne(e => e.StreetAddress)
            .Ignore(p => p.Value)
            .Property(x => x.CountryId)
            .HasConversion<CountryCode2Converter>();
        builder.OwnsOne(e => e.HashedText).Ignore(p => p.Value);
        builder.OwnsOne(e => e.ArabicName).Ignore(p => p.Value)
            .Property(x => x.CultureCode).HasConversion<CultureCodeConverter>();
        builder.OwnsOne(e=>e.Flag).Ignore(p=>p.Value);
        builder.OwnsOne(e => e.Password).Ignore(p => p.Value);
        
    }
}