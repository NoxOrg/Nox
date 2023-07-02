// Generated

#nullable enable

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types;
using Nox.Abstractions.Infrastructure.Persistence;

namespace SampleWebApp.Domain;

public partial class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    INoxDatabaseProvider _dbProvider { get; set; }
    
    public StoreConfiguration(INoxDatabaseProvider dbProvider)
    {
        _dbProvider = dbProvider;
    }
    
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value, v => StoreId.From(v));
        
        builder.Property(e => e.Name).IsRequired(true).IsUnicode(true).HasMaxLength(63).HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() { MinLength = 4, MaxLength = 63, IsUnicode = true, Casing = TextTypeCasing.Normal }));        
    }
}
