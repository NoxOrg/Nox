using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashCustomerDataSeeder : DataSeederBase<CustomerDto, Customer>
{
    public CryptocashCustomerDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashCustomer.json";

    protected override Customer TransformToEntity(CustomerDto model)
    {
        return new() {
        };
    }
}