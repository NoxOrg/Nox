﻿using Nox.Types;
using Cryptocash.DataSeed.Seeders;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using AutoMapper;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Types.Common;

namespace Cryptocash.Infrastructure;

internal class CryptocashLandLordDataSeeder : DataSeederBase<LandLordDto, LandLord>
{
    public CryptocashLandLordDataSeeder(
        AppDbContext dbContext,
        ISeedDataReader seedDataReader)
        : base(dbContext, seedDataReader)
    {
    }

    protected override string SourceFileName => "CryptocashLandLord.json";

    protected override LandLord TransformToEntity(LandLordDto model)
    {
        LandLord entity = new LandLord { };
        entity.Id = Nox.Types.Guid.From(model.Id);
        entity.Name = Text.From(model.Name);
        entity.Address = StreetAddress.From(new StreetAddressItem
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
        });

        return entity;
    }
}