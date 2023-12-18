
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

    public virtual async Task UpdateEntityAsync(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    private async Task<Cryptocash.Domain.PaymentProvider> ToEntityAsync(PaymentProviderCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.PaymentProvider();
        exceptionCollector.Collect("PaymentProviderName", () => entity.SetIfNotNull(createDto.PaymentProviderName, (entity) => entity.PaymentProviderName = 
            Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(createDto.PaymentProviderName.NonNullValue<System.String>())));
        exceptionCollector.Collect("PaymentProviderType", () => entity.SetIfNotNull(createDto.PaymentProviderType, (entity) => entity.PaymentProviderType = 
            Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(createDto.PaymentProviderType.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("PaymentProviderName",() => entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(updateDto.PaymentProviderName.NonNullValue<System.String>()));
        exceptionCollector.Collect("PaymentProviderType",() => entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(updateDto.PaymentProviderType.NonNullValue<System.String>()));

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
                exceptionCollector.Collect("PaymentProviderName",() =>entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(PaymentProviderNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PaymentProviderType", out var PaymentProviderTypeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PaymentProviderTypeUpdateValue, "Attribute 'PaymentProviderType' can't be null.");
            {
                exceptionCollector.Collect("PaymentProviderType",() =>entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(PaymentProviderTypeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}