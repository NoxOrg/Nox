
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Factories;

internal partial class StoreFactory : StoreFactoryBase
{
    public StoreFactory
    (
        IRepository repository,
        IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> emailaddressfactory
    ) : base(repository, emailaddressfactory)
    {}
}

internal abstract class StoreFactoryBase : IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> EmailAddressFactory {get;}

    public StoreFactoryBase(
        IRepository repository,
        IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> emailaddressfactory
        )
    {
        _repository = repository;
        EmailAddressFactory = emailaddressfactory;
    }

    public virtual async Task<StoreEntity> CreateEntityAsync(StoreCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(StoreEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(StoreEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(StoreEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(StoreEntity));
        }   
    }

    private async Task<ClientApi.Domain.Store> ToEntityAsync(StoreCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Store();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.StoreMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Address", () => entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            Dto.StoreMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>())));
        exceptionCollector.Collect("Location", () => entity.SetIfNotNull(createDto.Location, (entity) => entity.Location = 
            Dto.StoreMetadata.CreateLocation(createDto.Location.NonNullValue<LatLongDto>())));
        exceptionCollector.Collect("OpeningDay", () => entity.SetIfNotNull(createDto.OpeningDay, (entity) => entity.OpeningDay = 
            Dto.StoreMetadata.CreateOpeningDay(createDto.OpeningDay.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("Status", () => entity.SetIfNotNull(createDto.Status, (entity) => entity.Status = 
            Dto.StoreMetadata.CreateStatus(createDto.Status.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);
        if (createDto.EmailAddress is not null)
        {
            var emailAddress = await EmailAddressFactory.CreateEntityAsync(createDto.EmailAddress, cultureCode);
            entity.CreateRefToEmailAddress(emailAddress);
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.StoreMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Address",() => entity.Address = Dto.StoreMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>()));
        exceptionCollector.Collect("Location",() => entity.Location = Dto.StoreMetadata.CreateLocation(updateDto.Location.NonNullValue<LatLongDto>()));
        if(updateDto.OpeningDay is null)
        {
             entity.OpeningDay = null;
        }
        else
        {
            exceptionCollector.Collect("OpeningDay",() =>entity.OpeningDay = Dto.StoreMetadata.CreateOpeningDay(updateDto.OpeningDay.ToValueFromNonNull<System.DateTimeOffset>()));
        }
        if(updateDto.Status is null)
        {
             entity.Status = null;
        }
        else
        {
            exceptionCollector.Collect("Status",() =>entity.Status = Dto.StoreMetadata.CreateStatus(updateDto.Status.ToValueFromNonNull<System.Int32>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(StoreEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.StoreMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AddressUpdateValue, "Attribute 'Address' can't be null.");
            {
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                exceptionCollector.Collect("Address",() =>entity.Address = Dto.StoreMetadata.CreateAddress(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("Location", out var LocationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(LocationUpdateValue, "Attribute 'Location' can't be null.");
            {
                var entityToUpdate = entity.Location is null ? new LatLongDto() : entity.Location.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, LocationUpdateValue);
                exceptionCollector.Collect("Location",() =>entity.Location = Dto.StoreMetadata.CreateLocation(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("OpeningDay", out var OpeningDayUpdateValue))
        {
            if (OpeningDayUpdateValue == null) { entity.OpeningDay = null; }
            else
            {
                exceptionCollector.Collect("OpeningDay",() =>entity.OpeningDay = Dto.StoreMetadata.CreateOpeningDay(OpeningDayUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Status", out var StatusUpdateValue))
        {
            if (StatusUpdateValue == null) { entity.Status = null; }
            else
            {
                exceptionCollector.Collect("Status",() =>entity.Status = Dto.StoreMetadata.CreateStatus(StatusUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		await UpdateEmailAddressAsync(entity, updateDto, cultureCode);
	}

    private async Task UpdateEmailAddressAsync(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.EmailAddress is null)
        {
            if(entity.EmailAddress is not null) 
                _repository.DeleteOwned(entity.EmailAddress);
            entity.DeleteAllRefToEmailAddress();
        }
		else
		{
            if(entity.EmailAddress is not null)
                await EmailAddressFactory.UpdateEntityAsync(entity.EmailAddress, updateDto.EmailAddress, cultureCode);
            else
			    entity.CreateRefToEmailAddress(await EmailAddressFactory.CreateEntityAsync(updateDto.EmailAddress, cultureCode));
        }
	}
}