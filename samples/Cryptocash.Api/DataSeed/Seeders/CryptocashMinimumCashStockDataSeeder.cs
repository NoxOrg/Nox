using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashMinimumCashStockDataSeeder : DataSeederBase<MinimumCashStockDto, MinimumCashStock>
{
    public CryptocashMinimumCashStockDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashMinimumCashStock.json";

    protected override MinimumCashStock TransformToEntity(MinimumCashStockDto model)
    {
        return new() {
        };
    }
}