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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Factories;

internal partial class EmployeeFactory : EmployeeFactoryBase
{
    public EmployeeFactory
    (
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory,
        IRepository repository
    ) : base(employeephonenumberfactory, repository)
    {}
}

internal abstract class EmployeeFactoryBase : IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> EmployeePhoneNumberFactory {get;}

    public EmployeeFactoryBase(
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory,
        IRepository repository
        )
    {
        EmployeePhoneNumberFactory = employeephonenumberfactory;
        _repository = repository;
    }

    public virtual async Task<EmployeeEntity> CreateEntityAsync(EmployeeCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(EmployeeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.Employee> ToEntityAsync(EmployeeCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Employee();
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
        foreach (var dto in createDto.EmployeePhoneNumbers)
        {
            var newRelatedEntity = await EmployeePhoneNumberFactory.CreateEntityAsync(dto);
            entity.CreateRefToEmployeePhoneNumbers(newRelatedEntity);
        }
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.FirstName = Cryptocash.Domain.EmployeeMetadata.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>());
        entity.LastName = Cryptocash.Domain.EmployeeMetadata.CreateLastName(updateDto.LastName.NonNullValue<System.String>());
        entity.EmailAddress = Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(updateDto.EmailAddress.NonNullValue<System.String>());
        entity.Address = Cryptocash.Domain.EmployeeMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
        entity.FirstWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(updateDto.FirstWorkingDay.NonNullValue<System.DateTime>());
        if(updateDto.LastWorkingDay is null)
        {
             entity.LastWorkingDay = null;
        }
        else
        {
            entity.LastWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(updateDto.LastWorkingDay.ToValueFromNonNull<System.DateTime>());
        }
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(EmployeeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("FirstName", out var FirstNameUpdateValue))
        {
            if (FirstNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'FirstName' can't be null");
            }
            {
                entity.FirstName = Cryptocash.Domain.EmployeeMetadata.CreateFirstName(FirstNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("LastName", out var LastNameUpdateValue))
        {
            if (LastNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'LastName' can't be null");
            }
            {
                entity.LastName = Cryptocash.Domain.EmployeeMetadata.CreateLastName(LastNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EmailAddress", out var EmailAddressUpdateValue))
        {
            if (EmailAddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'EmailAddress' can't be null");
            }
            {
                entity.EmailAddress = Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(EmailAddressUpdateValue);
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
                entity.Address = Cryptocash.Domain.EmployeeMetadata.CreateAddress(entityToUpdate);
            }
        }

        if (updatedProperties.TryGetValue("FirstWorkingDay", out var FirstWorkingDayUpdateValue))
        {
            if (FirstWorkingDayUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'FirstWorkingDay' can't be null");
            }
            {
                entity.FirstWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(FirstWorkingDayUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("LastWorkingDay", out var LastWorkingDayUpdateValue))
        {
            if (LastWorkingDayUpdateValue == null) { entity.LastWorkingDay = null; }
            else
            {
                entity.LastWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(LastWorkingDayUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

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
					updatedEmployeePhoneNumbers.Add(await EmployeePhoneNumberFactory.CreateEntityAsync(ownedUpsertDto));
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
                entity.EmployeePhoneNumbers.Where(x => !updatedEmployeePhoneNumbers.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToEmployeePhoneNumbers(updatedEmployeePhoneNumbers);
		}
	}
}