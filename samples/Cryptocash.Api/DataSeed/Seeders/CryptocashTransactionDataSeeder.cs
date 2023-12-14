using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

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
        Transaction entity = new() {
            TransactionType = Text.From(model.TransactionType),
            ProcessedOnDateTime = Nox.Types.DateTime.From(model.ProcessedOnDateTime),
            Amount = Money.From(model.Amount!.Amount, model.Amount!.CurrencyCode),
            Reference = Text.From(model.Reference),
            CustomerId = Nox.Types.Guid.From(model.CustomerId!.Value.ToString()),
            BookingId = Nox.Types.Guid.From(model.BookingId!.Value.ToString())
        };

        entity.EnsureId(model.Id);

        return entity;
    }
}