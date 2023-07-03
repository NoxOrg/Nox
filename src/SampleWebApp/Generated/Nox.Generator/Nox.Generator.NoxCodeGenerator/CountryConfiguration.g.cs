// Generated

#nullable enable

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Abstractions.Infrastructure.Persistence;

namespace SampleWebApp.Domain;

public partial class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    INoxDatabaseProvider _dbProvider { get; set; }
    
    public CountryConfiguration(INoxDatabaseProvider dbProvider)
    {
        _dbProvider = dbProvider;
    }
    
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CountryId.From(v));
        
        builder.Property(e => e.Name).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 4, MaxLength = 63, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.FormalName).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 4, MaxLength = 63, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.AlphaCode3).IsRequired(true).IsUnicode(false).HasMaxLength(3).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 3, MaxLength = 3, IsUnicode = false, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.AlphaCode2).IsRequired(true).IsUnicode(false).HasMaxLength(2).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 2, MaxLength = 2, IsUnicode = false, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.NumericCode).IsRequired(true).HasColumnType(_dbProvider.ToDatabaseColumnType<Number,NumberTypeOptions>(new NumberTypeOptions() { MinValue = 4, MaxValue = 894, DecimalDigits = 0 }));        
        
        builder.Property(e => e.DialingCodes).IsRequired(false).IsUnicode(false).HasMaxLength(31).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 31, IsUnicode = false, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.Capital).IsRequired(false).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 63, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.Demonym).IsRequired(false).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 63, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.AreaInSquareKilometres).IsRequired(true).HasColumnType(_dbProvider.ToDatabaseColumnType<Number,NumberTypeOptions>(new NumberTypeOptions() { MinValue = 0, MaxValue = 20000000, DecimalDigits = 0 }));        
        
        builder.OwnsOne(e => e.GeoCoord).Ignore(p => p.Value);;        
        
        builder.Property(e => e.GeoRegion).IsRequired(true).IsUnicode(false).HasMaxLength(8).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 8, IsUnicode = false, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.GeoSubRegion).IsRequired(true).IsUnicode(false).HasMaxLength(32).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 32, IsUnicode = false, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.GeoWorldRegion).IsRequired(true).IsUnicode(false).HasMaxLength(4).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 4, IsUnicode = false, Casing = TextTypeCasing.Normal }));        
        
        builder.Property(e => e.Population).IsRequired(false).HasColumnType(_dbProvider.ToDatabaseColumnType<Number,NumberTypeOptions>(new NumberTypeOptions() { MinValue = 0, MaxValue = 999999999, DecimalDigits = 0 }));        
        
        builder.Property(e => e.TopLevelDomains).IsRequired(false).IsUnicode(true).HasMaxLength(31).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 0, MaxLength = 31, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
        
        builder.HasMany(x => x.Currencies).WithMany();        
    }
}
