﻿
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
using Dto = Cryptocash.Application.Dto;
using Cryptocash.Domain;
using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Factories;

internal partial class PaymentProviderFactory : PaymentProviderFactoryBase
{
    public PaymentProviderFactory
    (
    ) : base()
    {}
}

internal abstract class PaymentProviderFactoryBase : IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto>
{

    public PaymentProviderFactoryBase(
        )
    {
    }

    public virtual async Task<PaymentProviderEntity> CreateEntityAsync(PaymentProviderCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PaymentProviderEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PaymentProviderEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(PaymentProviderEntity));
        }   
    }

    private async Task<Cryptocash.Domain.PaymentProvider> ToEntityAsync(PaymentProviderCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.PaymentProvider();
        exceptionCollector.Collect("PaymentProviderName", () => entity.SetIfNotNull(createDto.PaymentProviderName, (entity) => entity.PaymentProviderName = 
            Dto.PaymentProviderMetadata.CreatePaymentProviderName(createDto.PaymentProviderName.NonNullValue<System.String>())));
        exceptionCollector.Collect("PaymentProviderType", () => entity.SetIfNotNull(createDto.PaymentProviderType, (entity) => entity.PaymentProviderType = 
            Dto.PaymentProviderMetadata.CreatePaymentProviderType(createDto.PaymentProviderType.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("PaymentProviderName",() => entity.PaymentProviderName = Dto.PaymentProviderMetadata.CreatePaymentProviderName(updateDto.PaymentProviderName.NonNullValue<System.String>()));
        exceptionCollector.Collect("PaymentProviderType",() => entity.PaymentProviderType = Dto.PaymentProviderMetadata.CreatePaymentProviderType(updateDto.PaymentProviderType.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("PaymentProviderName", out var PaymentProviderNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PaymentProviderNameUpdateValue, "Attribute 'PaymentProviderName' can't be null.");
            {
                exceptionCollector.Collect("PaymentProviderName",() =>entity.PaymentProviderName = Dto.PaymentProviderMetadata.CreatePaymentProviderName(PaymentProviderNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PaymentProviderType", out var PaymentProviderTypeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PaymentProviderTypeUpdateValue, "Attribute 'PaymentProviderType' can't be null.");
            {
                exceptionCollector.Collect("PaymentProviderType",() =>entity.PaymentProviderType = Dto.PaymentProviderMetadata.CreatePaymentProviderType(PaymentProviderTypeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}