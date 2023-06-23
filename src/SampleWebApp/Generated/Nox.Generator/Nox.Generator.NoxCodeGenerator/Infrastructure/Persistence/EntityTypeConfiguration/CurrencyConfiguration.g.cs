// Generated

#nullable enable

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types;

namespace SampleWebApp.Domain;

public partial class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    IDatabaseProvider _dbProvider { get; set; }
    
    public CurrencyConfiguration(IDatabaseProvider dbProvider)
    {
        _dbProvider = dbProvider;
    }
    
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CurrencyId.From(v));
        
        builder.Property(e => e.Name).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbProvider.ToDatabaseColumnType<Text>(new TextTypeOptions() { MinLength = 4, MaxLength = 63, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
    }
}
