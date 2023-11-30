using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

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
        return new() {
        };
    }
}