// generated

#nullable enable

using Nox.Types.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApp.Domain;

public partial class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CountryId.From(v));
        
        builder.Property(e => e.Name).IsRequired().IsUnicode(true).HasMaxLength(63).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 4, MaxLength: 63, IsUniCode: True, Casing: Normal });        
        
        builder.Property(e => e.FormalName).IsRequired().IsUnicode(true).HasMaxLength(63).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 4, MaxLength: 63, IsUniCode: True, Casing: Normal });        
        
        builder.Property(e => e.AlphaCode3).IsRequired().IsUnicode(false).HasMaxLength(3).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 3, MaxLength: 3, IsUniCode: False, Casing: Normal });        
        
        builder.Property(e => e.AlphaCode2).IsRequired().IsUnicode(false).HasMaxLength(2).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 2, MaxLength: 2, IsUniCode: False, Casing: Normal });        
        
        builder.Property(e => e.NumericCode).IsRequired().HasColumnType(_dbDriver.GetDbType<Number>(new NumberTypeOptions() { MinValue: 4, MaxValue: 894, DecimalDigits: 0 });        
        
        builder.Property(e => e.DialingCodes).IsUnicode(false).HasMaxLength(31).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 31, IsUniCode: False, Casing: Normal });        
        
        builder.Property(e => e.Capital).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 63, IsUniCode: True, Casing: Normal });        
        
        builder.Property(e => e.Demonym).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 63, IsUniCode: True, Casing: Normal });        
        
        builder.Property(e => e.AreaInSquareKilometres).IsRequired().HasColumnType(_dbDriver.GetDbType<Number>(new NumberTypeOptions() { MinValue: 0, MaxValue: 20000000, DecimalDigits: 0 });        
        
        builder.Property(e => e.GeoCoord);        
        
        builder.Property(e => e.GeoRegion).IsRequired().IsUnicode(false).HasMaxLength(8).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 8, IsUniCode: False, Casing: Normal });        
        
        builder.Property(e => e.GeoSubRegion).IsRequired().IsUnicode(false).HasMaxLength(32).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 32, IsUniCode: False, Casing: Normal });        
        
        builder.Property(e => e.GeoWorldRegion).IsRequired().IsUnicode(false).HasMaxLength(4).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 4, IsUniCode: False, Casing: Normal });        
        
        builder.Property(e => e.Population).HasColumnType(_dbDriver.GetDbType<Number>(new NumberTypeOptions() { MinValue: 0, MaxValue: 999999999, DecimalDigits: 0 });        
        
        builder.Property(e => e.TopLevelDomains).IsUnicode(true).HasMaxLength(31).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 0, MaxLength: 31, IsUniCode: True, Casing: Normal });        
    }
}
