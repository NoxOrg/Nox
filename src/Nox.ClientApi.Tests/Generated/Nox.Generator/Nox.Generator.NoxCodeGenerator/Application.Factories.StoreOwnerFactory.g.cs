﻿// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Factories;

public abstract class StoreOwnerFactoryBase : IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto>
{

    public StoreOwnerFactoryBase
    (
        )
    {
    }

    public virtual StoreOwner CreateEntity(StoreOwnerCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public void UpdateEntity(StoreOwner entity, StoreOwnerUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private ClientApi.Domain.StoreOwner ToEntity(StoreOwnerCreateDto createDto)
    {
        var entity = new ClientApi.Domain.StoreOwner();
        entity.Id = StoreOwner.CreateId(createDto.Id);
        entity.Name = ClientApi.Domain.StoreOwner.CreateName(createDto.Name);
        entity.TemporaryOwnerName = ClientApi.Domain.StoreOwner.CreateTemporaryOwnerName(createDto.TemporaryOwnerName);
        if (createDto.VatNumber is not null)entity.VatNumber = ClientApi.Domain.StoreOwner.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>());
        if (createDto.StreetAddress is not null)entity.StreetAddress = ClientApi.Domain.StoreOwner.CreateStreetAddress(createDto.StreetAddress.NonNullValue<StreetAddressDto>());
        if (createDto.LocalGreeting is not null)entity.LocalGreeting = ClientApi.Domain.StoreOwner.CreateLocalGreeting(createDto.LocalGreeting.NonNullValue<TranslatedTextDto>());
        if (createDto.Notes is not null)entity.Notes = ClientApi.Domain.StoreOwner.CreateNotes(createDto.Notes.NonNullValue<System.String>());
        //entity.Stores = Stores.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

    private void MapEntity(StoreOwner entity, StoreOwnerUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.Name = ClientApi.Domain.StoreOwner.CreateName(updateDto.Name);
        entity.TemporaryOwnerName = ClientApi.Domain.StoreOwner.CreateTemporaryOwnerName(updateDto.TemporaryOwnerName);
        if (updateDto.VatNumber is not null)entity.VatNumber = ClientApi.Domain.StoreOwner.CreateVatNumber(updateDto.VatNumber.NonNullValue<VatNumberDto>());
        if (updateDto.StreetAddress is not null)entity.StreetAddress = ClientApi.Domain.StoreOwner.CreateStreetAddress(updateDto.StreetAddress.NonNullValue<StreetAddressDto>());
        if (updateDto.LocalGreeting is not null)entity.LocalGreeting = ClientApi.Domain.StoreOwner.CreateLocalGreeting(updateDto.LocalGreeting.NonNullValue<TranslatedTextDto>());
        if (updateDto.Notes is not null)entity.Notes = ClientApi.Domain.StoreOwner.CreateNotes(updateDto.Notes.NonNullValue<System.String>());

        // TODO: discuss about keys
        //entity.Stores = Stores.Select(dto => dto.ToEntity()).ToList();
    }
}

public partial class StoreOwnerFactory : StoreOwnerFactoryBase
{
}