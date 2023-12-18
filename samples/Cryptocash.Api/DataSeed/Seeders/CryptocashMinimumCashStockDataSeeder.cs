using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using Nox.Types;

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
        List<VendingMachine> VendingMachineList = new();
        if (model.VendingMachines != null)
        {
            foreach (VendingMachineDto CurrentVendingMachine in model.VendingMachines)
            {
                if (!String.IsNullOrWhiteSpace(CurrentVendingMachine.Id.ToString()))
                {
                    VendingMachine AddVendingMachine = new VendingMachine();
                    AddVendingMachine.EnsureId(CurrentVendingMachine.Id);

                    VendingMachineList.Add(AddVendingMachine);
                }    
            }
        }
        MinimumCashStock entity = new()
        {
            Amount = Money.From(model.Amount!.Amount, model.Amount!.CurrencyCode),
            CurrencyId = CurrencyCode3.From(model.CurrencyId!),            
        };

        entity.UpdateRefToVendingMachines(VendingMachineList);

        return entity;
    }
}