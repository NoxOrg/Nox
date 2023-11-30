﻿using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashPaymentProviderDataSeeder : DataSeederBase<PaymentProviderDto, PaymentProvider>
{
    public CryptocashPaymentProviderDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashPaymentProvider.json";

    protected override PaymentProvider TransformToEntity(PaymentProviderDto model)
    {
        return new() {
            PaymentProviderName = Text.From(model.PaymentProviderName!),
            PaymentProviderType = Text.From(model.PaymentProviderType!)
        };
    }
}