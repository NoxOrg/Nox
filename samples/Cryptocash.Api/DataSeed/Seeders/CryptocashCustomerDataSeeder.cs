using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Types.Common;

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
        Customer entity = new()
        {
            FirstName = Text.From(model.FirstName),
            LastName = Text.From(model.LastName),
            EmailAddress = Email.From(model.EmailAddress),
            CountryId = CountryCode2.From(model.CountryId!),
            MobileNumber = PhoneNumber.From(model.MobileNumber!),
            Address = StreetAddress.From(new StreetAddressItem
            {
                StreetNumber = model.Address.StreetNumber,
                AddressLine1 = model.Address.AddressLine1,
                AddressLine2 = model.Address.AddressLine2,
                Route = model.Address.Route,
                Locality = model.Address.Locality,
                Neighborhood = model.Address.Neighborhood,
                AdministrativeArea1 = model.Address.AdministrativeArea1,
                AdministrativeArea2 = model.Address.AdministrativeArea2,
                PostalCode = model.Address.PostalCode,
                CountryId = model.Address.CountryId,
            })
        };

        entity.EnsureId(model.Id);

        return entity;
    }
}