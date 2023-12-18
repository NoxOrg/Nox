using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using Nox.Types;

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
        Commission entity = new() {
            Rate = Percentage.From(model.Rate),
            EffectiveAt = Nox.Types.DateTime.From(model.EffectiveAt),
            CountryId = CountryCode2.From(model.CountryId!)
        };

        entity.EnsureId(model.Id);

        return entity;
    }
}