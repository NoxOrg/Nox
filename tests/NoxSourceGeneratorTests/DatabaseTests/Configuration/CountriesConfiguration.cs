// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Types;

namespace SampleWebApp.Domain;

public partial class CountriesConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value.Value, v => CountryId.From(Text.From(v)));

        builder.Property(e => e.Name).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.FormalName).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.AlphaCode3).IsRequired(true).IsUnicode(false).HasMaxLength(3).HasConversion<TextConverter>();

        builder.Property(e => e.NumericCode).IsRequired(true).HasConversion<NumberToInt32Converter>();

        builder.Property(e => e.DialingCodes).IsRequired(false).IsUnicode(false).HasMaxLength(31).HasConversion<TextConverter>();

        builder.Property(e => e.Capital).IsRequired(false).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.Demonym).IsRequired(false).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.OwnsOne(e => e.GeoCoord).Ignore(p => p.Value);

        builder.Property(e => e.GeoRegion).IsRequired(true).IsUnicode(false).HasMaxLength(8).HasConversion<TextConverter>();

        builder.Property(e => e.GeoSubRegion).IsRequired(true).IsUnicode(false).HasMaxLength(32).HasConversion<TextConverter>();

        builder.Property(e => e.GeoWorldRegion).IsRequired(true).IsUnicode(false).HasMaxLength(4).HasConversion<TextConverter>();

        builder.Property(e => e.Population).IsRequired(false).HasConversion<NumberToInt32Converter>();

        builder.Property(e => e.TopLevelDomains).IsRequired(false).IsUnicode(true).HasMaxLength(31).HasConversion<TextConverter>();

        builder.Property(e => e.AlphaCode2).IsRequired(true).HasConversion<CountryCode2Converter>();

        builder.Property(e => e.AreaTestField).IsRequired(true).HasConversion<AreaToSquareMeterConverter>();

        builder.Property(e => e.BooleanTestField).IsRequired(true);

        builder.Property(e => e.CountryCode3TestField).IsRequired(true).HasConversion<CountryCode3Converter>();

        builder.Property(e => e.CountryNumberTestField).IsRequired(true).HasConversion<CountryNumberConverter>();
    }
}

public class TextConverter : ValueConverter<Text, string>
{
    public TextConverter() : base(text => text.Value, textValue => Text.From(textValue)) { }
}

public class NumberToInt32Converter : ValueConverter<Number, int>
{
    public NumberToInt32Converter() : base(number => (int)number.Value, numberValue => Number.From(numberValue)) { }
}

public class CountryCode2Converter : ValueConverter<CountryCode2, string>
{
    public CountryCode2Converter() : base(countryCode2 => countryCode2.Value, countryCode2Value => CountryCode2.From(countryCode2Value)) { }
}

public class AreaToSquareMeterConverter : ValueConverter<Area, double>
{
    public AreaToSquareMeterConverter() : base(area => (double)area.ToSquareMeters(), areaValue => Area.FromSquareMeters(areaValue)) { }
}
public class AreaToSquareFeetConverter : ValueConverter<Area, double>
{
    public AreaToSquareFeetConverter() : base(area => (double)area.ToSquareFeet(), areaValue => Area.FromSquareFeet(areaValue)) { }
}

public class CountryCode3Converter : ValueConverter<CountryCode3, string>
{
    public CountryCode3Converter() : base(countryCode3 => countryCode3.Value, countryCode3Value => CountryCode3.From(countryCode3Value)) { }
}
public class CountryNumberConverter : ValueConverter<CountryNumber, short>
{
    public CountryNumberConverter() : base(countryNumber => countryNumber.Value, countryNumberValue => CountryNumber.From(countryNumberValue)) { }
}