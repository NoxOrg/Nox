using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

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