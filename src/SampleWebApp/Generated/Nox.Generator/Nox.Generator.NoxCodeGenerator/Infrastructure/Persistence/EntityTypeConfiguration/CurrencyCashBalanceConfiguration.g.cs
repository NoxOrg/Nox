// Generated

#nullable enable

using Nox.Types.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApp.Domain;

public partial class CurrencyCashBalanceConfiguration : IEntityTypeConfiguration<CurrencyCashBalance>
{
    public void Configure(EntityTypeBuilder<CurrencyCashBalance> builder)
    {
        builder.HasKey(e => e.Store);
        
        builder.Property(e => e.Store).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => CurrencyCashBalanceStore.From(v));
        
        builder.Property(e => e.Amount).IsRequired().HasColumnType(_dbDriver.GetDbType<Number>(new NumberTypeOptions() { MinValue: 0, MaxValue: 999999999, DecimalDigits: 4 });        
        
        builder.Property(e => e.OperationLimit).HasColumnType(_dbDriver.GetDbType<Number>(new NumberTypeOptions() { MinValue: 0, MaxValue: 999999999, DecimalDigits: 4 });        
    }
}
