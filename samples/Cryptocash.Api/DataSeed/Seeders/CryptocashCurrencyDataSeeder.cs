using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashCurrencyDataSeeder : DataSeederBase<CurrencyDto, Currency>
{
    public CryptocashCurrencyDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCurrency.json";

    protected override Currency TransformToEntity(CurrencyDto model)
    {
        Currency rtnCurrency = new() {
            Id = CurrencyCode3.From(model.Id!),
            Name = Text.From(model.Name!),
            CurrencyIsoNumeric = CurrencyNumber.From(model.CurrencyIsoNumeric!),
            Symbol = Text.From(model.Symbol!),
            ThousandsSeparator = Text.From(model.ThousandsSeparator!),
            DecimalSeparator = Text.From(model.DecimalSeparator!),
            SpaceBetweenAmountAndSymbol = Nox.Types.Boolean.From(model.SpaceBetweenAmountAndSymbol!),
            DecimalDigits = Number.From(model.DecimalDigits!),
            MajorName = Text.From(model.MajorName!),
            MajorSymbol = Text.From(model.MajorSymbol!),
            MinorName = Text.From(model.MinorName!),
            MinorSymbol = Text.From(model.MinorSymbol!),
            MinorToMajorValue = Money.From(model.MinorToMajorValue!.Amount, model.MinorToMajorValue!.CurrencyCode)
        };

        if (model.BankNotes != null)
        {
            foreach (BankNoteDto currentBankNote in model.BankNotes)
            {
                rtnCurrency.CreateRefToBankNotes(
                    new()
                    {
                        CashNote = Text.From(currentBankNote.CashNote),
                        Value = Money.From(currentBankNote!.Value.Amount, currentBankNote!.Value!.CurrencyCode)                        
                    }
                );
            }
        }

        return rtnCurrency;
    }
}