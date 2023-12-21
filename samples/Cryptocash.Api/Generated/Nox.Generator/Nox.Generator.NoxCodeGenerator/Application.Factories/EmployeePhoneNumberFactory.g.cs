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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Factories;

internal partial class EmployeePhoneNumberFactory : EmployeePhoneNumberFactoryBase
{
    public EmployeePhoneNumberFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class EmployeePhoneNumberFactoryBase : IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberUpsertDto, EmployeePhoneNumberUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public EmployeePhoneNumberFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<EmployeePhoneNumberEntity> CreateEntityAsync(EmployeePhoneNumberUpsertDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(EmployeePhoneNumberEntity entity, EmployeePhoneNumberUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(EmployeePhoneNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<Cryptocash.Domain.EmployeePhoneNumber> ToEntityAsync(EmployeePhoneNumberUpsertDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        exceptionCollector.Collect("PhoneNumberType", () => entity.SetIfNotNull(createDto.PhoneNumberType, (entity) => entity.PhoneNumberType = 
            Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(createDto.PhoneNumberType.NonNullValue<System.String>())));
        exceptionCollector.Collect("PhoneNumber", () => entity.SetIfNotNull(createDto.PhoneNumber, (entity) => entity.PhoneNumber = 
            Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(createDto.PhoneNumber.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EmployeePhoneNumberEntity entity, EmployeePhoneNumberUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("PhoneNumberType",() => entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(updateDto.PhoneNumberType.NonNullValue<System.String>()));
        exceptionCollector.Collect("PhoneNumber",() => entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(updateDto.PhoneNumber.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EmployeePhoneNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("PhoneNumberType", out var PhoneNumberTypeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PhoneNumberTypeUpdateValue, "Attribute 'PhoneNumberType' can't be null.");
            {
                exceptionCollector.Collect("PhoneNumberType",() =>entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(PhoneNumberTypeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumber", out var PhoneNumberUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PhoneNumberUpdateValue, "Attribute 'PhoneNumber' can't be null.");
            {
                exceptionCollector.Collect("PhoneNumber",() =>entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(PhoneNumberUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}