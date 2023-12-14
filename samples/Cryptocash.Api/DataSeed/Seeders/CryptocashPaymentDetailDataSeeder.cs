using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Application.Factories;

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
        PaymentDetail entity = new() {
            PaymentAccountName = Text.From(model.PaymentAccountName),
            PaymentAccountNumber = Text.From(model.PaymentAccountNumber),
            PaymentAccountSortCode = model.PaymentAccountNumber == null ? null : Text.From(model.PaymentAccountSortCode!),
            CustomerId = Nox.Types.Guid.From(model.CustomerId!.Value.ToString()),
            PaymentProviderId = Nox.Types.Guid.From(model.PaymentProviderId!.Value.ToString())
        };

        return entity;
    }
}