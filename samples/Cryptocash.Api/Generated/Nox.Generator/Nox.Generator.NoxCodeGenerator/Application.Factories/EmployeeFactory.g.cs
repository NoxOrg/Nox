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
    protected IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> EmployeePhoneNumberFactory {get;}

    public EmployeeFactoryBase
    (
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory
        )
    {
        EmployeePhoneNumberFactory = employeephonenumberfactory;
    }

    public virtual EmployeeEntity CreateEntity(EmployeeCreateDto createDto)
    {
        return ToEntity(createDto);
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
        entity.SetIfNotNull(updateDto.LastWorkingDay, (entity) => entity.LastWorkingDay = Cryptocash.Domain.EmployeeMetadata.CreateLastWorkingDay(updateDto.LastWorkingDay.ToValueFromNonNull<System.DateTime>()));
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
}

internal partial class EmployeeFactory : EmployeeFactoryBase
{
    public EmployeeFactory
    (
        IEntityFactory<Cryptocash.Domain.EmployeePhoneNumber, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto> employeephonenumberfactory
    ) : base(employeephonenumberfactory)
    {}
}