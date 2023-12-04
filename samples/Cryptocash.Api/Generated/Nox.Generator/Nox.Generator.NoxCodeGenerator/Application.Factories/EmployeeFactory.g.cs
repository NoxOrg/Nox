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

internal abstract class EmployeeFactoryBase : IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> EmployeePhoneNumberFactory {get;}

    public EmployeeFactoryBase
    (
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory,
        IRepository repository
        )
    {
        EmployeePhoneNumberFactory = employeephonenumberfactory;
        _repository = repository;
    }

    public virtual EmployeeEntity CreateEntity(EmployeeCreateDto createDto)
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

    public virtual void UpdateEntity(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(EmployeeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.Employee ToEntity(EmployeeCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Employee();
        entity.FirstName = Cryptocash.Domain.EmployeeMetadata.CreateFirstName(createDto.FirstName);
        entity.LastName = Cryptocash.Domain.EmployeeMetadata.CreateLastName(createDto.LastName);
        entity.EmailAddress = Cryptocash.Domain.EmployeeMetadata.CreateEmailAddress(createDto.EmailAddress);
        entity.Address = Cryptocash.Domain.EmployeeMetadata.CreateAddress(createDto.Address);
        entity.FirstWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateFirstWorkingDay(createDto.FirstWorkingDay);
        entity.SetIfNotNull(createDto.LastWorkingDay, (entity) => entity.LastWorkingDay =Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(createDto.LastWorkingDay.NonNullValue<System.DateTime>()));
        createDto.EmployeePhoneNumbers.ForEach(dto => entity.CreateRefToEmployeePhoneNumbers(EmployeePhoneNumberFactory.CreateEntity(dto)));
        return entity;
    }

    private void UpdateEntityInternal(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
	    UpdateOwnedEntities(entity, updateDto, cultureCode);
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
                entity.Address = Cryptocash.Domain.EmployeeMetadata.CreateAddress(AddressUpdateValue);
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

	private void UpdateOwnedEntities(EmployeeEntity entity, EmployeeUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.EmployeePhoneNumbers.Any())
        { 
            _repository.DeleteOwnedRange(entity.EmployeePhoneNumbers);
			entity.DeleteAllRefToEmployeePhoneNumbers();
        }
		else
		{
			var updatedEmployeePhoneNumbers = new List<Cryptocash.Domain.EmployeePhoneNumber>();
			foreach(var ownedUpsertDto in updateDto.EmployeePhoneNumbers)
			{
				if(ownedUpsertDto.Id is null)
					updatedEmployeePhoneNumbers.Add(EmployeePhoneNumberFactory.CreateEntity(ownedUpsertDto));
				else
				{
					var key = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.EmployeePhoneNumbers.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("EmployeePhoneNumbers.Id", key.ToString());
					else
					{
						EmployeePhoneNumberFactory.UpdateEntity(ownedEntity, ownedUpsertDto, cultureCode);
						updatedEmployeePhoneNumbers.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwnedRange<Cryptocash.Domain.EmployeePhoneNumber>(
                entity.EmployeePhoneNumbers.Where(x => !updatedEmployeePhoneNumbers.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToEmployeePhoneNumbers(updatedEmployeePhoneNumbers);
		}
	}
}

internal partial class EmployeeFactory : EmployeeFactoryBase
{
    public EmployeeFactory
    (
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory,
        IRepository repository
    ) : base(employeephonenumberfactory, repository)
    {}
}