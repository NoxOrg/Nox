
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
using PersonEntity = ClientApi.Domain.Person;

namespace ClientApi.Application.Factories;

internal partial class PersonFactory : PersonFactoryBase
{
    public PersonFactory
    (
        IRepository repository,
        IEntityFactory<ClientApi.Domain.UserContactSelection, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> usercontactselectionfactory
    ) : base(repository, usercontactselectionfactory)
    {}
}

internal abstract class PersonFactoryBase : IEntityFactory<PersonEntity, PersonCreateDto, PersonUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.UserContactSelection, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> UserContactSelectionFactory {get;}

    public PersonFactoryBase(
        IRepository repository,
        IEntityFactory<ClientApi.Domain.UserContactSelection, UserContactSelectionUpsertDto, UserContactSelectionUpsertDto> usercontactselectionfactory
        )
    {
        _repository = repository;
        UserContactSelectionFactory = usercontactselectionfactory;
    }

    public virtual async Task<PersonEntity> CreateEntityAsync(PersonCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PersonEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PersonEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(PersonEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PersonEntity));
        }   
    }

    private async Task<ClientApi.Domain.Person> ToEntityAsync(PersonCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Person();
        exceptionCollector.Collect("FirstName", () => entity.SetIfNotNull(createDto.FirstName, (entity) => entity.FirstName = 
            Dto.PersonMetadata.CreateFirstName(createDto.FirstName.NonNullValue<System.String>())));
        exceptionCollector.Collect("LastName", () => entity.SetIfNotNull(createDto.LastName, (entity) => entity.LastName = 
            Dto.PersonMetadata.CreateLastName(createDto.LastName.NonNullValue<System.String>())));
        exceptionCollector.Collect("TenantId", () => entity.SetIfNotNull(createDto.TenantId, (entity) => entity.TenantId = 
            Dto.PersonMetadata.CreateTenantId(createDto.TenantId.NonNullValue<System.Guid>())));
        exceptionCollector.Collect("PrimaryEmailAddress", () => entity.SetIfNotNull(createDto.PrimaryEmailAddress, (entity) => entity.PrimaryEmailAddress = 
            Dto.PersonMetadata.CreatePrimaryEmailAddress(createDto.PrimaryEmailAddress.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);
        if (createDto.UserContactSelection is not null)
        {
            var userContactSelection = await UserContactSelectionFactory.CreateEntityAsync(createDto.UserContactSelection, cultureCode);
            entity.CreateRefToUserContactSelection(userContactSelection);
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("FirstName",() => entity.FirstName = Dto.PersonMetadata.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>()));
        exceptionCollector.Collect("LastName",() => entity.LastName = Dto.PersonMetadata.CreateLastName(updateDto.LastName.NonNullValue<System.String>()));
        exceptionCollector.Collect("TenantId",() => entity.TenantId = Dto.PersonMetadata.CreateTenantId(updateDto.TenantId.NonNullValue<System.Guid>()));
        exceptionCollector.Collect("PrimaryEmailAddress",() => entity.PrimaryEmailAddress = Dto.PersonMetadata.CreatePrimaryEmailAddress(updateDto.PrimaryEmailAddress.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(PersonEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("FirstName", out var FirstNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(FirstNameUpdateValue, "Attribute 'FirstName' can't be null.");
            {
                exceptionCollector.Collect("FirstName",() =>entity.FirstName = Dto.PersonMetadata.CreateFirstName(FirstNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LastName", out var LastNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(LastNameUpdateValue, "Attribute 'LastName' can't be null.");
            {
                exceptionCollector.Collect("LastName",() =>entity.LastName = Dto.PersonMetadata.CreateLastName(LastNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TenantId", out var TenantIdUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TenantIdUpdateValue, "Attribute 'TenantId' can't be null.");
            {
                exceptionCollector.Collect("TenantId",() =>entity.TenantId = Dto.PersonMetadata.CreateTenantId(TenantIdUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PrimaryEmailAddress", out var PrimaryEmailAddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PrimaryEmailAddressUpdateValue, "Attribute 'PrimaryEmailAddress' can't be null.");
            {
                exceptionCollector.Collect("PrimaryEmailAddress",() =>entity.PrimaryEmailAddress = Dto.PersonMetadata.CreatePrimaryEmailAddress(PrimaryEmailAddressUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		await UpdateUserContactSelectionAsync(entity, updateDto, cultureCode);
	}

    private async Task UpdateUserContactSelectionAsync(PersonEntity entity, PersonUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		if(updateDto.UserContactSelection is null)
        {
            if(entity.UserContactSelection is not null) 
                _repository.DeleteOwned(entity.UserContactSelection);
            entity.DeleteAllRefToUserContactSelection();
        }
		else
		{
            if(entity.UserContactSelection is not null)
                await UserContactSelectionFactory.UpdateEntityAsync(entity.UserContactSelection, updateDto.UserContactSelection, cultureCode);
            else
			    entity.CreateRefToUserContactSelection(await UserContactSelectionFactory.CreateEntityAsync(updateDto.UserContactSelection, cultureCode));
        }
	}
}