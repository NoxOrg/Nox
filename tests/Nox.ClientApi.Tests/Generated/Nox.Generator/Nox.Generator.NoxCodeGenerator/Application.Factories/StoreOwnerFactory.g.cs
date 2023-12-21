// Generated

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

internal partial class StoreOwnerFactory : StoreOwnerFactoryBase
{
    public StoreOwnerFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class StoreOwnerFactoryBase : IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public StoreOwnerFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<StoreOwnerEntity> CreateEntityAsync(StoreOwnerCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(StoreOwnerEntity entity, StoreOwnerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(StoreOwnerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.StoreOwner> ToEntityAsync(StoreOwnerCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.StoreOwner();
        exceptionCollector.Collect("Id",() => entity.Id = StoreOwnerMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.StoreOwnerMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("TemporaryOwnerName", () => entity.SetIfNotNull(createDto.TemporaryOwnerName, (entity) => entity.TemporaryOwnerName = 
            ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(createDto.TemporaryOwnerName.NonNullValue<System.String>())));
        exceptionCollector.Collect("VatNumber", () => entity.SetIfNotNull(createDto.VatNumber, (entity) => entity.VatNumber = 
            ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>())));
        exceptionCollector.Collect("StreetAddress", () => entity.SetIfNotNull(createDto.StreetAddress, (entity) => entity.StreetAddress = 
            ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(createDto.StreetAddress.NonNullValue<StreetAddressDto>())));
        exceptionCollector.Collect("LocalGreeting", () => entity.SetIfNotNull(createDto.LocalGreeting, (entity) => entity.LocalGreeting = 
            ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(createDto.LocalGreeting.NonNullValue<TranslatedTextDto>())));
        exceptionCollector.Collect("Notes", () => entity.SetIfNotNull(createDto.Notes, (entity) => entity.Notes = 
            ClientApi.Domain.StoreOwnerMetadata.CreateNotes(createDto.Notes.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(StoreOwnerEntity entity, StoreOwnerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = ClientApi.Domain.StoreOwnerMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("TemporaryOwnerName",() => entity.TemporaryOwnerName = ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(updateDto.TemporaryOwnerName.NonNullValue<System.String>()));
        if(updateDto.VatNumber is null)
        {
             entity.VatNumber = null;
        }
        else
        {
            exceptionCollector.Collect("VatNumber",() =>entity.VatNumber = ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(updateDto.VatNumber.ToValueFromNonNull<VatNumberDto>()));
        }
        if(updateDto.StreetAddress is null)
        {
             entity.StreetAddress = null;
        }
        else
        {
            exceptionCollector.Collect("StreetAddress",() =>entity.StreetAddress = ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(updateDto.StreetAddress.ToValueFromNonNull<StreetAddressDto>()));
        }
        if(updateDto.LocalGreeting is null)
        {
             entity.LocalGreeting = null;
        }
        else
        {
            exceptionCollector.Collect("LocalGreeting",() =>entity.LocalGreeting = ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(updateDto.LocalGreeting.ToValueFromNonNull<TranslatedTextDto>()));
        }
        if(updateDto.Notes is null)
        {
             entity.Notes = null;
        }
        else
        {
            exceptionCollector.Collect("Notes",() =>entity.Notes = ClientApi.Domain.StoreOwnerMetadata.CreateNotes(updateDto.Notes.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(StoreOwnerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.StoreOwnerMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TemporaryOwnerName", out var TemporaryOwnerNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TemporaryOwnerNameUpdateValue, "Attribute 'TemporaryOwnerName' can't be null.");
            {
                exceptionCollector.Collect("TemporaryOwnerName",() =>entity.TemporaryOwnerName = ClientApi.Domain.StoreOwnerMetadata.CreateTemporaryOwnerName(TemporaryOwnerNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("VatNumber", out var VatNumberUpdateValue))
        {
            if (VatNumberUpdateValue == null) { entity.VatNumber = null; }
            else
            {
                var entityToUpdate = entity.VatNumber is null ? new VatNumberDto() : entity.VatNumber.ToDto();
                VatNumberDto.UpdateFromDictionary(entityToUpdate, VatNumberUpdateValue);
                exceptionCollector.Collect("VatNumber",() =>entity.VatNumber = ClientApi.Domain.StoreOwnerMetadata.CreateVatNumber(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("StreetAddress", out var StreetAddressUpdateValue))
        {
            if (StreetAddressUpdateValue == null) { entity.StreetAddress = null; }
            else
            {
                var entityToUpdate = entity.StreetAddress is null ? new StreetAddressDto() : entity.StreetAddress.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, StreetAddressUpdateValue);
                exceptionCollector.Collect("StreetAddress",() =>entity.StreetAddress = ClientApi.Domain.StoreOwnerMetadata.CreateStreetAddress(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("LocalGreeting", out var LocalGreetingUpdateValue))
        {
            if (LocalGreetingUpdateValue == null) { entity.LocalGreeting = null; }
            else
            {
                var entityToUpdate = entity.LocalGreeting is null ? new TranslatedTextDto() : entity.LocalGreeting.ToDto();
                TranslatedTextDto.UpdateFromDictionary(entityToUpdate, LocalGreetingUpdateValue);
                exceptionCollector.Collect("LocalGreeting",() =>entity.LocalGreeting = ClientApi.Domain.StoreOwnerMetadata.CreateLocalGreeting(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("Notes", out var NotesUpdateValue))
        {
            if (NotesUpdateValue == null) { entity.Notes = null; }
            else
            {
                exceptionCollector.Collect("Notes",() =>entity.Notes = ClientApi.Domain.StoreOwnerMetadata.CreateNotes(NotesUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}