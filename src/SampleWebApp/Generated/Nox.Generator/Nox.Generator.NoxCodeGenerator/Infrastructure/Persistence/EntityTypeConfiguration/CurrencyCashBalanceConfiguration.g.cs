// Generated

#nullable enable

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nox.Types;

namespace SampleWebApp.Domain;

public partial class CurrencyCashBalanceConfiguration : IEntityTypeConfiguration<CurrencyCashBalance>
{
    IDatabaseProvider _dbProvider { get; set; }
    
    public CurrencyCashBalanceConfiguration(IDatabaseProvider dbProvider)
    {
        _dbProvider = dbProvider;
    }
    
    public void Configure(EntityTypeBuilder<CurrencyCashBalance> builder)
    {
        builder.HasKey(e => e.StoreId);
        
        builder.Property(e => e.StoreId).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CurrencyCashBalanceStoreId.From(v));
        
        builder.Property(e => e.Amount).IsRequired(true).HasColumnType(_dbProvider.ToDatabaseColumnType<Number>(new NumberTypeOptions() { MinValue = 0, MaxValue = 999999999, DecimalDigits = 4 }));        
        
        builder.Property(e => e.OperationLimit).IsRequired(false).HasColumnType(_dbProvider.ToDatabaseColumnType<Number>(new NumberTypeOptions() { MinValue = 0, MaxValue = 999999999, DecimalDigits = 4 }));        
    }
}
