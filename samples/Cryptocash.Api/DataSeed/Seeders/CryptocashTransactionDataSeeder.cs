using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashTransactionDataSeeder : DataSeederBase<TransactionDto, Transaction>
{
    public CryptocashTransactionDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashTransaction.json";

    protected override Transaction TransformToEntity(TransactionDto model)
    {
        return new() {
        };
    }
}