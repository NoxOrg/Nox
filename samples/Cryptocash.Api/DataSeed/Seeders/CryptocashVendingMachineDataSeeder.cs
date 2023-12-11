using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Types.Common;

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
        VendingMachine entity = new VendingMachine { };
        entity.EnsureId(model.Id);
        entity.MacAddress = MacAddress.From(model.MacAddress);
        entity.PublicIp = IpAddress.From(model.PublicIp);
        entity.SerialNumber = Text.From(model.SerialNumber);
        entity.InstallationFootPrint = Area.From((QuantityValue)model.InstallationFootPrint!, AreaTypeUnit.SquareMeter);
        entity.CountryId = CountryCode2.From(model.CountryId!);
        entity.LandLordId = Nox.Types.Guid.From(model.LandLordId.ToString()!);
        entity.GeoLocation = LatLong.From(model.GeoLocation.Latitude, model.GeoLocation.Longitude);
        entity.StreetAddress = StreetAddress.From(new StreetAddressItem
        {
            StreetNumber = model.StreetAddress.StreetNumber,
            AddressLine1 = model.StreetAddress.AddressLine1,
            AddressLine2 = model.StreetAddress.AddressLine2,
            Route = model.StreetAddress.Route,
            Locality = model.StreetAddress.Locality,
            Neighborhood = model.StreetAddress.Neighborhood,
            AdministrativeArea1 = model.StreetAddress.AdministrativeArea1,
            AdministrativeArea2 = model.StreetAddress.AdministrativeArea2,
            PostalCode = model.StreetAddress.PostalCode,
            CountryId = model.StreetAddress.CountryId,
        });
        entity.RentPerSquareMetre = Money.From(model.RentPerSquareMetre!.Amount, model.RentPerSquareMetre.CurrencyCode);
        
        return entity;
    }
}