// generated

#nullable enable

using Nox.Types.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SampleService.Domain;

public partial class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CurrencyId.From(v));
        
        builder.Property(e => e.Name).IsRequired().IsUnicode(true).HasMaxLength(63).HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() { MinLength: 4, MaxLength: 63, IsUniCode: True, Casing: Normal });        
    }
}
