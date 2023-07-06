using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types.EntityFramework.Types;

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
        builder.Property(e => e.MonthOfPeakTourism).HasConversion<MonthToByteConverter>();
        builder.Property(e => e.DistanceInKm).HasConversion<DistanceToKilometerConverter>();
        builder.Property(e => e.InternetDomain).HasConversion<InternetDomainConverter>();
        builder.Property(e => e.CountryCode3).HasConversion<CountryCode3Converter>();
        builder.Property(e => e.IPAddress).HasConversion<IpAddressConverter>();
        builder.Property(e => e.LongestHikingTrailInMeters).HasConversion<LengthToMeterConverter>();

        // Configure Multi-value ValueObjects
        builder.OwnsOne(e => e.LatLong).Ignore(p => p.Value);
        builder.OwnsOne(e => e.GrossDomesticProduct).Ignore(p => p.Value);
        builder.OwnsOne(e => e.DateTimeRange).Ignore(p => p.Value);
        builder.OwnsOne(e => e.StreetAddress)
            .Ignore(p => p.Value)
            .Property(x => x.CountryId)
            .HasConversion<CountryCode2Converter>();
        builder.OwnsOne(e => e.HashedText).Ignore(p => p.Value);
    }
}