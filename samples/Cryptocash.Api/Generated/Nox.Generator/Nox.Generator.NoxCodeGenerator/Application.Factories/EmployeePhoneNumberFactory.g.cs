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
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(EmployeePhoneNumberEntity entity, EmployeePhoneNumberUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(EmployeePhoneNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.EmployeePhoneNumber> ToEntityAsync(EmployeePhoneNumberUpsertDto createDto)
    {
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        entity.SetIfNotNull(createDto.PhoneNumberType, (entity) => entity.PhoneNumberType = 
            Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(createDto.PhoneNumberType.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.PhoneNumber, (entity) => entity.PhoneNumber = 
            Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(createDto.PhoneNumber.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(EmployeePhoneNumberEntity entity, EmployeePhoneNumberUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(updateDto.PhoneNumberType.NonNullValue<System.String>());
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(updateDto.PhoneNumber.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(EmployeePhoneNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("PhoneNumberType", out var PhoneNumberTypeUpdateValue))
        {
            if (PhoneNumberTypeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PhoneNumberType' can't be null");
            }
            {
                entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(PhoneNumberTypeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumber", out var PhoneNumberUpdateValue))
        {
            if (PhoneNumberUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PhoneNumber' can't be null");
            }
            {
                entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(PhoneNumberUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}