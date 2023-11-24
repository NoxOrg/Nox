using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashVendingMachineDataSeeder : DataSeederBase<VendingMachineDto, VendingMachine>
{
    public CryptocashVendingMachineDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashVendingMachine.json";

    protected override VendingMachine TransformToEntity(VendingMachineDto model)
    {
        return new() {
        };
    }
}