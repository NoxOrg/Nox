using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using Nox.Types;
using SampleWebApp.SeedData.Models;

namespace SampleWebApp.SeedData;

internal class VendingMachineDataSeeder : SampleDataSeederBase<VendingMachineModel, VendingMachine>
{
    public VendingMachineDataSeeder(SampleWebAppDbContext dbContext) : base(dbContext)
    {
    }

    protected override string SourceFile => "vending-machines.json";

    protected override IEnumerable<VendingMachine> TransformToEntities(IEnumerable<VendingMachineModel> models)
    {
        var entities = models.Select(x =>
            new VendingMachine
            {
                Name = Text.From(x.Name),
                Address = StreetAddress.From(CreateAddressItem(x.Address)),
                LatLong = LatLong.From(x.Latitude, x.Longitude),
                SupportNumber = Text.From(x.Phone),// TODO: should be Phone type
                CreatedAtUtc = System.DateTime.Now
            }).ToList();

        return entities;
    }

    private static StreetAddressItem CreateAddressItem(string input)
    {
        //Suppose address format is:Shopping Center, 8957-11 Spreitenbach, CH
        var addressChunks = input.Split(",")
            .Select(x => x.TrimStart().TrimEnd())
            .ToArray();
        var postalData = addressChunks[1].Split(" ");

        return new StreetAddressItem
        {
            AddressLine1 = addressChunks[0],
            PostalCode = string.Join(" ", postalData.Take(postalData.Length - 1)),
            Locality = postalData[postalData.Length - 1],
            CountryId = CountryCode2.From(addressChunks[2])
        };
    }
}