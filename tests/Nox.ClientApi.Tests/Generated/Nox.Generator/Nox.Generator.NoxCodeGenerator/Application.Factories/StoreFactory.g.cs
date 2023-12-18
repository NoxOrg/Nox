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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Factories;

internal partial class StoreFactory : StoreFactoryBase
{
    public StoreFactory
    (
        IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> emailaddressfactory,
        IRepository repository
    ) : base(emailaddressfactory, repository)
    {}
}

internal abstract class StoreFactoryBase : IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> EmailAddressFactory {get;}

    public StoreFactoryBase(
        IEntityFactory<ClientApi.Domain.EmailAddress, EmailAddressUpsertDto, EmailAddressUpsertDto> emailaddressfactory,
        IRepository repository
        )
    {
        EmailAddressFactory = emailaddressfactory;
        _repository = repository;
    }

    public virtual async Task<StoreEntity> CreateEntityAsync(StoreCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
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
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(StoreEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<ClientApi.Domain.Store> ToEntityAsync(StoreCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Store();
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.StoreMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            ClientApi.Domain.StoreMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>()));
        entity.SetIfNotNull(createDto.Location, (entity) => entity.Location = 
            ClientApi.Domain.StoreMetadata.CreateLocation(createDto.Location.NonNullValue<LatLongDto>()));
        entity.SetIfNotNull(createDto.OpeningDay, (entity) => entity.OpeningDay = 
            ClientApi.Domain.StoreMetadata.CreateOpeningDay(createDto.OpeningDay.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.Status, (entity) => entity.Status = 
            ClientApi.Domain.StoreMetadata.CreateStatus(createDto.Status.NonNullValue<System.Int32>()));
        entity.EnsureId(createDto.Id);
        if (createDto.EmailAddress is not null)
        {
            entity.CreateRefToEmailAddress(await EmailAddressFactory.CreateEntityAsync(createDto.EmailAddress));
        }
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.StoreMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Address = ClientApi.Domain.StoreMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
        entity.Location = ClientApi.Domain.StoreMetadata.CreateLocation(updateDto.Location.NonNullValue<LatLongDto>());
        if(updateDto.OpeningDay is null)
        {
             entity.OpeningDay = null;
        }
        else
        {
            entity.OpeningDay = ClientApi.Domain.StoreMetadata.CreateOpeningDay(updateDto.OpeningDay.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if(updateDto.Status is null)
        {
             entity.Status = null;
        }
        else
        {
            entity.Status = ClientApi.Domain.StoreMetadata.CreateStatus(updateDto.Status.ToValueFromNonNull<System.Int32>());
        }
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(StoreEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.StoreMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            if (AddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Address' can't be null");
            }
            {
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                entity.Address = ClientApi.Domain.StoreMetadata.CreateAddress(entityToUpdate);
            }
        }

        if (updatedProperties.TryGetValue("Location", out var LocationUpdateValue))
        {
            if (LocationUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Location' can't be null");
            }
            {
                var entityToUpdate = entity.Location is null ? new LatLongDto() : entity.Location.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, LocationUpdateValue);
                entity.Location = ClientApi.Domain.StoreMetadata.CreateLocation(entityToUpdate);
            }
        }

        if (updatedProperties.TryGetValue("OpeningDay", out var OpeningDayUpdateValue))
        {
            if (OpeningDayUpdateValue == null) { entity.OpeningDay = null; }
            else
            {
                entity.OpeningDay = ClientApi.Domain.StoreMetadata.CreateOpeningDay(OpeningDayUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Status", out var StatusUpdateValue))
        {
            if (StatusUpdateValue == null) { entity.Status = null; }
            else
            {
                entity.Status = ClientApi.Domain.StoreMetadata.CreateStatus(StatusUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(StoreEntity entity, StoreUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
			    entity.CreateRefToEmailAddress(await EmailAddressFactory.CreateEntityAsync(updateDto.EmailAddress));
		}
	}
}