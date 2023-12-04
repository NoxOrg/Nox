﻿// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Factories;

internal abstract class StoreOwnerFactoryBase : IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public StoreOwnerFactoryBase
    (
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual StoreOwnerEntity CreateEntity(StoreOwnerCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(StoreOwnerEntity entity, StoreOwnerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(StoreOwnerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.StoreOwner ToEntity(StoreOwnerCreateDto createDto)
    {
        var entity = new ClientApi.Domain.StoreOwner();
        entity.Id = StoreOwnerMetadata.CreateId(createDto.Id);
        entity.Name = ClientApi.Domain.StoreOwnerMetadata.CreateName(createDto.Name);
        entity.TemporaryOwnerName = ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(createDto.TemporaryOwnerName);
        entity.SetIfNotNull(createDto.VatNumber, (entity) => entity.VatNumber =ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>()));
        entity.SetIfNotNull(createDto.StreetAddress, (entity) => entity.StreetAddress =ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(createDto.StreetAddress.NonNullValue<StreetAddressDto>()));
        entity.SetIfNotNull(createDto.LocalGreeting, (entity) => entity.LocalGreeting =ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(createDto.LocalGreeting.NonNullValue<TranslatedTextDto>()));
        entity.SetIfNotNull(createDto.Notes, (entity) => entity.Notes =ClientApi.Domain.StoreOwnerMetadata.CreateNotes(createDto.Notes.NonNullValue<System.String>()));
        return entity;
    }

    private void UpdateEntityInternal(StoreOwnerEntity entity, StoreOwnerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.StoreOwnerMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.TemporaryOwnerName = ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(updateDto.TemporaryOwnerName.NonNullValue<System.String>());
        if(updateDto.VatNumber is null)
        {
             entity.VatNumber = null;
        }
        else
        {
            entity.VatNumber = ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(updateDto.VatNumber.ToValueFromNonNull<VatNumberDto>());
        }
        if(updateDto.StreetAddress is null)
        {
             entity.StreetAddress = null;
        }
        else
        {
            entity.StreetAddress = ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(updateDto.StreetAddress.ToValueFromNonNull<StreetAddressDto>());
        }
        if(updateDto.LocalGreeting is null)
        {
             entity.LocalGreeting = null;
        }
        else
        {
            entity.LocalGreeting = ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(updateDto.LocalGreeting.ToValueFromNonNull<TranslatedTextDto>());
        }
        if(updateDto.Notes is null)
        {
             entity.Notes = null;
        }
        else
        {
            entity.Notes = ClientApi.Domain.StoreOwnerMetadata.CreateNotes(updateDto.Notes.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(StoreOwnerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.StoreOwnerMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TemporaryOwnerName", out var TemporaryOwnerNameUpdateValue))
        {
            if (TemporaryOwnerNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TemporaryOwnerName' can't be null");
            }
            {
                entity.TemporaryOwnerName = ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(TemporaryOwnerNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("VatNumber", out var VatNumberUpdateValue))
        {
            if (VatNumberUpdateValue == null) { entity.VatNumber = null; }
            else
            {
                var updated = entity.VatNumber ?? new Nox.Types.VatNumber();
                foreach(var pair in VatNumberUpdateValue)
                {
                    var property = typeof(Nox.Types.VatNumber).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.VatNumber = ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(updated);
            }
        }

        if (updatedProperties.TryGetValue("StreetAddress", out var StreetAddressUpdateValue))
        {
            if (StreetAddressUpdateValue == null) { entity.StreetAddress = null; }
            else
            {
                var updated = entity.StreetAddress ?? new Nox.Types.StreetAddress();
                foreach(var pair in StreetAddressUpdateValue)
                {
                    var property = typeof(Nox.Types.StreetAddress).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.StreetAddress = ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(updated);
            }
        }

        if (updatedProperties.TryGetValue("LocalGreeting", out var LocalGreetingUpdateValue))
        {
            if (LocalGreetingUpdateValue == null) { entity.LocalGreeting = null; }
            else
            {
                var updated = entity.LocalGreeting ?? new Nox.Types.TranslatedText();
                foreach(var pair in LocalGreetingUpdateValue)
                {
                    var property = typeof(Nox.Types.TranslatedText).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.LocalGreeting = ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(updated);
            }
        }

        if (updatedProperties.TryGetValue("Notes", out var NotesUpdateValue))
        {
            if (NotesUpdateValue == null) { entity.Notes = null; }
            else
            {
                entity.Notes = ClientApi.Domain.StoreOwnerMetadata.CreateNotes(NotesUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class StoreOwnerFactory : StoreOwnerFactoryBase
{
    public StoreOwnerFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}