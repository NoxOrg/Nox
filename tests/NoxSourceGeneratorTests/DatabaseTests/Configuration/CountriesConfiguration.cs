// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Generator.Test.DatabaseTests.Model;
using Nox.Types;

namespace Nox.Generator.Test.DatabaseTests.Configuration;

public partial class CountriesConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value.Value, v => CountryId.From(Text.From(v)));

        builder.Property(e => e.Name).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.FormalName).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.AlphaCode3).IsRequired(true).IsUnicode(false).HasMaxLength(3).HasConversion<TextConverter>();

        builder.Property(e => e.AlphaCode2).IsRequired(true).HasConversion<CountryCode2Converter>();

        builder.Property(e => e.NumericCode).IsRequired(true).HasConversion<NumberToInt32Converter>();

        builder.Property(e => e.DialingCodes).IsRequired(false).IsUnicode(false).HasMaxLength(31).HasConversion<TextConverter>();

        builder.Property(e => e.Capital).IsRequired(false).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.Demonym).IsRequired(false).IsUnicode(true).HasMaxLength(63).HasConversion<TextConverter>();

        builder.Property(e => e.AreaInSquareKilometres).IsRequired(true).HasConversion<NumberToInt32Converter>();

        builder.OwnsOne(e => e.GeoCoord).Ignore(p => p.Value);

        builder.Property(e => e.GeoRegion).IsRequired(true).IsUnicode(false).HasMaxLength(8).HasConversion<TextConverter>();

        builder.Property(e => e.GeoSubRegion).IsRequired(true).IsUnicode(false).HasMaxLength(32).HasConversion<TextConverter>();

        builder.Property(e => e.GeoWorldRegion).IsRequired(true).IsUnicode(false).HasMaxLength(4).HasConversion<TextConverter>();

        builder.Property(e => e.Population).IsRequired(false).HasConversion<NumberToInt32Converter>();

        builder.Property(e => e.TopLevelDomains).IsRequired(false).IsUnicode(true).HasMaxLength(31).HasConversion<TextConverter>();
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
    /// <summary>
    /// Initializes a new instance of the <see cref="CountryCode2Converter" /> class.
    /// </summary>
    public CountryCode2Converter() : base(countryCode2 => countryCode2.Value, countryCode2Value => CountryCode2.From(countryCode2Value)) { }
}
