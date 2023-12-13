using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashCommissionDataSeeder : DataSeederBase<CommissionDto, Commission>
{
    public CryptocashCommissionDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCommission.json";

    protected override Commission TransformToEntity(CommissionDto model)
    {
        return new() {
        };
    }
}