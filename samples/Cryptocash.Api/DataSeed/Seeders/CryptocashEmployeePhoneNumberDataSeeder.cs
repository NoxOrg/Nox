using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cryptocash.Infrastructure;

internal class CryptocashEmployeePhoneNumberDataSeeder : DataSeederBase<EmployeePhoneNumberDto, EmployeePhoneNumber>
{
    public CryptocashEmployeePhoneNumberDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashEmployeePhoneNumber.json";

    protected override EmployeePhoneNumber TransformToEntity(EmployeePhoneNumberDto model)
    {
        return new() {
        };
    }
}