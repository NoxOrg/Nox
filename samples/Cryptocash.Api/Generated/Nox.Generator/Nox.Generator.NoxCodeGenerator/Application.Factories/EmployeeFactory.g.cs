

// Generated
//TODO: if CultureCode is not needed, remove it from the factory
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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Factories;

internal partial class EmployeeFactory : EmployeeFactoryBase
{
    public EmployeeFactory
    (
        IRepository repository,
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory
    ) : base(repository, employeephonenumberfactory)
    {}
}

internal abstract class EmployeeFactoryBase : IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> EmployeePhoneNumberFactory {get;}

    public EmployeeFactoryBase(
        IRepository repository,
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory
        )
    {
        _repository = repository;
        EmployeePhoneNumberFactory = employeephonenumberfactory;
    }

    public virtual async Task<EmployeeEntity> CreateEntityAsync(EmployeeCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(EmployeeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<Cryptocash.Domain.Employee> ToEntityAsync(EmployeeCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Employee();
<<<<<<< main
        exceptionCollector.Collect("FirstName", () => entity.SetIfNotNull(createDto.FirstName, (entity) => entity.FirstName = 
            Cryptocash.Domain.EmployeeMetadata.CreateFirstName(createDto.FirstName.NonNullValue<System.String>())));
        exceptionCollector.Collect("LastName", () => entity.SetIfNotNull(createDto.LastName, (entity) => entity.LastName = 
            Cryptocash.Domain.EmployeeMetadata.CreateLastName(createDto.LastName.NonNullValue<System.String>())));
        exceptionCollector.Collect("EmailAddress", () => entity.SetIfNotNull(createDto.EmailAddress, (entity) => entity.EmailAddress = 
            Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(createDto.EmailAddress.NonNullValue<System.String>())));
        exceptionCollector.Collect("Address", () => entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            Cryptocash.Domain.EmployeeMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>())));
        exceptionCollector.Collect("FirstWorkingDay", () => entity.SetIfNotNull(createDto.FirstWorkingDay, (entity) => entity.FirstWorkingDay = 
            Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(createDto.FirstWorkingDay.NonNullValue<System.DateTime>())));
        exceptionCollector.Collect("LastWorkingDay", () => entity.SetIfNotNull(createDto.LastWorkingDay, (entity) => entity.LastWorkingDay = 
            Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(createDto.LastWorkingDay.NonNullValue<System.DateTime>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
=======
        entity.SetIfNotNull(createDto.FirstName, (entity) => entity.FirstName = 
            Cryptocash.Domain.EmployeeMetadata.CreateFirstName(createDto.FirstName.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.LastName, (entity) => entity.LastName = 
            Cryptocash.Domain.EmployeeMetadata.CreateLastName(createDto.LastName.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.EmailAddress, (entity) => entity.EmailAddress = 
            Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(createDto.EmailAddress.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            Cryptocash.Domain.EmployeeMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>()));
        entity.SetIfNotNull(createDto.FirstWorkingDay, (entity) => entity.FirstWorkingDay = 
            Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(createDto.FirstWorkingDay.NonNullValue<System.DateTime>()));
        entity.SetIfNotNull(createDto.LastWorkingDay, (entity) => entity.LastWorkingDay = 
            Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(createDto.LastWorkingDay.NonNullValue<System.DateTime>()));
<<<<<<< main
>>>>>>> Factory classes refactor has been completed (without tests)
        entity.EnsureId(createDto.Id);
        foreach (var dto in createDto.EmployeePhoneNumbers)
=======
        createDto.EmployeePhoneNumbers?.ForEach(async dto =>
>>>>>>> Factory classes refactor has been completed (without tests)
        {
<<<<<<< main
            var newRelatedEntity = await EmployeePhoneNumberFactory.CreateEntityAsync(dto);
            entity.CreateRefToEmployeePhoneNumbers(newRelatedEntity);
        }        
=======
            var employeePhoneNumber = await EmployeePhoneNumberFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToEmployeePhoneNumbers(employeePhoneNumber);
        });
>>>>>>> Factory classes refactor has been completed (without tests)
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("FirstName",() => entity.FirstName = Cryptocash.Domain.EmployeeMetadata.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>()));
        exceptionCollector.Collect("LastName",() => entity.LastName = Cryptocash.Domain.EmployeeMetadata.CreateLastName(updateDto.LastName.NonNullValue<System.String>()));
        exceptionCollector.Collect("EmailAddress",() => entity.EmailAddress = Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(updateDto.EmailAddress.NonNullValue<System.String>()));
        exceptionCollector.Collect("Address",() => entity.Address = Cryptocash.Domain.EmployeeMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>()));
        exceptionCollector.Collect("FirstWorkingDay",() => entity.FirstWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(updateDto.FirstWorkingDay.NonNullValue<System.DateTime>()));
        if(updateDto.LastWorkingDay is null)
        {
             entity.LastWorkingDay = null;
        }
        else
        {
            exceptionCollector.Collect("LastWorkingDay",() =>entity.LastWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(updateDto.LastWorkingDay.ToValueFromNonNull<System.DateTime>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(EmployeeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("FirstName", out var FirstNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(FirstNameUpdateValue, "Attribute 'FirstName' can't be null.");
            {
                exceptionCollector.Collect("FirstName",() =>entity.FirstName = Cryptocash.Domain.EmployeeMetadata.CreateFirstName(FirstNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LastName", out var LastNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(LastNameUpdateValue, "Attribute 'LastName' can't be null.");
            {
                exceptionCollector.Collect("LastName",() =>entity.LastName = Cryptocash.Domain.EmployeeMetadata.CreateLastName(LastNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EmailAddress", out var EmailAddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EmailAddressUpdateValue, "Attribute 'EmailAddress' can't be null.");
            {
                exceptionCollector.Collect("EmailAddress",() =>entity.EmailAddress = Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(EmailAddressUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AddressUpdateValue, "Attribute 'Address' can't be null.");
            {
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                exceptionCollector.Collect("Address",() =>entity.Address = Cryptocash.Domain.EmployeeMetadata.CreateAddress(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("FirstWorkingDay", out var FirstWorkingDayUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(FirstWorkingDayUpdateValue, "Attribute 'FirstWorkingDay' can't be null.");
            {
                exceptionCollector.Collect("FirstWorkingDay",() =>entity.FirstWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(FirstWorkingDayUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LastWorkingDay", out var LastWorkingDayUpdateValue))
        {
            if (LastWorkingDayUpdateValue == null) { entity.LastWorkingDay = null; }
            else
            {
                exceptionCollector.Collect("LastWorkingDay",() =>entity.LastWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(LastWorkingDayUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.EmployeePhoneNumbers.Any())
        { 
            _repository.DeleteOwned(entity.EmployeePhoneNumbers);
			entity.DeleteAllRefToEmployeePhoneNumbers();
        }
		else
		{
			var updatedEmployeePhoneNumbers = new List<Cryptocash.Domain.EmployeePhoneNumber>();
			foreach(var ownedUpsertDto in updateDto.EmployeePhoneNumbers)
			{
				if(ownedUpsertDto.Id is null)
                {
                    var ownedEntity = await EmployeePhoneNumberFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedEmployeePhoneNumbers.Add(ownedEntity);
                }
				else
				{
					var key = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.EmployeePhoneNumbers.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("EmployeePhoneNumbers.Id", key.ToString());
					else
					{
						await EmployeePhoneNumberFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedEmployeePhoneNumbers.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<Cryptocash.Domain.EmployeePhoneNumber>(
                entity.EmployeePhoneNumbers.Where(x => !updatedEmployeePhoneNumbers.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToEmployeePhoneNumbers(updatedEmployeePhoneNumbers);
		}
	}
}