// Generated

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

internal abstract class StoreOwnerFactoryBase : IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto>
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

    public virtual void UpdateEntity(StoreOwner entity, StoreOwnerUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(StoreOwner entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
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
        return entity;
    }

    private void UpdateEntityInternal(StoreOwner entity, StoreOwnerUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.StoreOwner.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.TemporaryOwnerName = ClientApi.Domain.StoreOwner.CreateTemporaryOwnerName(updateDto.TemporaryOwnerName.NonNullValue<System.String>());
        if (updateDto.VatNumber == null) { entity.VatNumber = null; } else {
            entity.VatNumber = ClientApi.Domain.StoreOwner.CreateVatNumber(updateDto.VatNumber.ToValueFromNonNull<VatNumberDto>());
        }
        if (updateDto.StreetAddress == null) { entity.StreetAddress = null; } else {
            entity.StreetAddress = ClientApi.Domain.StoreOwner.CreateStreetAddress(updateDto.StreetAddress.ToValueFromNonNull<StreetAddressDto>());
        }
        if (updateDto.LocalGreeting == null) { entity.LocalGreeting = null; } else {
            entity.LocalGreeting = ClientApi.Domain.StoreOwner.CreateLocalGreeting(updateDto.LocalGreeting.ToValueFromNonNull<TranslatedTextDto>());
        }
        if (updateDto.Notes == null) { entity.Notes = null; } else {
            entity.Notes = ClientApi.Domain.StoreOwner.CreateNotes(updateDto.Notes.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(StoreOwner entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.StoreOwner.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TemporaryOwnerName", out var TemporaryOwnerNameUpdateValue))
        {
            if (TemporaryOwnerNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TemporaryOwnerName' can't be null");
            }
            {
                entity.TemporaryOwnerName = ClientApi.Domain.StoreOwner.CreateTemporaryOwnerName(TemporaryOwnerNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("VatNumber", out var VatNumberUpdateValue))
        {
            if (VatNumberUpdateValue == null) { entity.VatNumber = null; }
            else
            {
                entity.VatNumber = ClientApi.Domain.StoreOwner.CreateVatNumber(VatNumberUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StreetAddress", out var StreetAddressUpdateValue))
        {
            if (StreetAddressUpdateValue == null) { entity.StreetAddress = null; }
            else
            {
                entity.StreetAddress = ClientApi.Domain.StoreOwner.CreateStreetAddress(StreetAddressUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("LocalGreeting", out var LocalGreetingUpdateValue))
        {
            if (LocalGreetingUpdateValue == null) { entity.LocalGreeting = null; }
            else
            {
                entity.LocalGreeting = ClientApi.Domain.StoreOwner.CreateLocalGreeting(LocalGreetingUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Notes", out var NotesUpdateValue))
        {
            if (NotesUpdateValue == null) { entity.Notes = null; }
            else
            {
                entity.Notes = ClientApi.Domain.StoreOwner.CreateNotes(NotesUpdateValue);
            }
        }
    }
}

internal partial class StoreOwnerFactory : StoreOwnerFactoryBase
{
}