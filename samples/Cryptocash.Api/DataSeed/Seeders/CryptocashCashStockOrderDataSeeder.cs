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
        CashStockOrder entity = new() {
            Amount = Money.From(model.Amount!.Amount, model.Amount!.CurrencyCode),
            RequestedDeliveryDate = Nox.Types.Date.From(model.RequestedDeliveryDate),
            VendingMachineId = Nox.Types.Guid.From(model.VendingMachineId!.Value.ToString()),
            EmployeeId = Nox.Types.Guid.From(model.EmployeeId!.Value.ToString())
        };

        return entity;
    }
}