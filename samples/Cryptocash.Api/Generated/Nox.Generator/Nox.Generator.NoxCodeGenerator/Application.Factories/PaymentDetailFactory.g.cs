

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
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Factories;

internal partial class PaymentDetailFactory : PaymentDetailFactoryBase
{
    public PaymentDetailFactory
    (
    ) : base()
    {}
}

internal abstract class PaymentDetailFactoryBase : IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto>
{

    public PaymentDetailFactoryBase(
        )
    {
    }

    public virtual async Task<PaymentDetailEntity> CreateEntityAsync(PaymentDetailCreateDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(PaymentDetailEntity entity, PaymentDetailUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(PaymentDetailEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.PaymentDetail> ToEntityAsync(PaymentDetailCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.PaymentDetail();
        exceptionCollector.Collect("PaymentAccountName", () => entity.SetIfNotNull(createDto.PaymentAccountName, (entity) => entity.PaymentAccountName = 
            Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountName(createDto.PaymentAccountName.NonNullValue<System.String>())));
        exceptionCollector.Collect("PaymentAccountNumber", () => entity.SetIfNotNull(createDto.PaymentAccountNumber, (entity) => entity.PaymentAccountNumber = 
            Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountNumber(createDto.PaymentAccountNumber.NonNullValue<System.String>())));
        exceptionCollector.Collect("PaymentAccountSortCode", () => entity.SetIfNotNull(createDto.PaymentAccountSortCode, (entity) => entity.PaymentAccountSortCode = 
            Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountSortCode(createDto.PaymentAccountSortCode.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(PaymentDetailEntity entity, PaymentDetailUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("PaymentAccountName",() => entity.PaymentAccountName = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountName(updateDto.PaymentAccountName.NonNullValue<System.String>()));
        exceptionCollector.Collect("PaymentAccountNumber",() => entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountNumber(updateDto.PaymentAccountNumber.NonNullValue<System.String>()));
        if(updateDto.PaymentAccountSortCode is null)
        {
             entity.PaymentAccountSortCode = null;
        }
        else
        {
            exceptionCollector.Collect("PaymentAccountSortCode",() =>entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountSortCode(updateDto.PaymentAccountSortCode.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(PaymentDetailEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("PaymentAccountName", out var PaymentAccountNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PaymentAccountNameUpdateValue, "Attribute 'PaymentAccountName' can't be null.");
            {
                exceptionCollector.Collect("PaymentAccountName",() =>entity.PaymentAccountName = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountName(PaymentAccountNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PaymentAccountNumber", out var PaymentAccountNumberUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PaymentAccountNumberUpdateValue, "Attribute 'PaymentAccountNumber' can't be null.");
            {
                exceptionCollector.Collect("PaymentAccountNumber",() =>entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountNumber(PaymentAccountNumberUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PaymentAccountSortCode", out var PaymentAccountSortCodeUpdateValue))
        {
            if (PaymentAccountSortCodeUpdateValue == null) { entity.PaymentAccountSortCode = null; }
            else
            {
                exceptionCollector.Collect("PaymentAccountSortCode",() =>entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountSortCode(PaymentAccountSortCodeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}