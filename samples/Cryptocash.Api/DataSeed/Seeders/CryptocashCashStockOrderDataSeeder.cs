using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashCashStockOrderDataSeeder : DataSeederBase<CashStockOrderDto, CashStockOrder>
{
    public CryptocashCashStockOrderDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCashStockOrder.json";

    protected override CashStockOrder TransformToEntity(CashStockOrderDto model)
    {
        return new() {
        };
    }
}