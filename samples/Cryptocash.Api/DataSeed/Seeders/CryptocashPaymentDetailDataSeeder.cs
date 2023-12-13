using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure;

internal class CryptocashPaymentDetailDataSeeder : DataSeederBase<PaymentDetailDto, PaymentDetail>
{
    public CryptocashPaymentDetailDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashPaymentDetail.json";

    protected override PaymentDetail TransformToEntity(PaymentDetailDto model)
    {
        return new() {
        };
    }
}