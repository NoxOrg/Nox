using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

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