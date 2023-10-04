// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using PaymentDetailEntity = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Factories;

internal abstract class PaymentDetailFactoryBase : IEntityFactory<PaymentDetailEntity, PaymentDetailCreateDto, PaymentDetailUpdateDto>
{

    public PaymentDetailFactoryBase
    (
        )
    {
    }

    public virtual PaymentDetailEntity CreateEntity(PaymentDetailCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(PaymentDetailEntity entity, PaymentDetailUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(PaymentDetailEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.PaymentDetail ToEntity(PaymentDetailCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentDetail();
        entity.PaymentAccountName = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountName(createDto.PaymentAccountName);
        entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountNumber(createDto.PaymentAccountNumber);
        if (createDto.PaymentAccountSortCode is not null)entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountSortCode(createDto.PaymentAccountSortCode.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(PaymentDetailEntity entity, PaymentDetailUpdateDto updateDto)
    {
        entity.PaymentAccountName = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountName(updateDto.PaymentAccountName.NonNullValue<System.String>());
        entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountNumber(updateDto.PaymentAccountNumber.NonNullValue<System.String>());
        if (updateDto.PaymentAccountSortCode == null) { entity.PaymentAccountSortCode = null; } else {
            entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountSortCode(updateDto.PaymentAccountSortCode.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(PaymentDetailEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("PaymentAccountName", out var PaymentAccountNameUpdateValue))
        {
            if (PaymentAccountNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PaymentAccountName' can't be null");
            }
            {
                entity.PaymentAccountName = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountName(PaymentAccountNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PaymentAccountNumber", out var PaymentAccountNumberUpdateValue))
        {
            if (PaymentAccountNumberUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PaymentAccountNumber' can't be null");
            }
            {
                entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountNumber(PaymentAccountNumberUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PaymentAccountSortCode", out var PaymentAccountSortCodeUpdateValue))
        {
            if (PaymentAccountSortCodeUpdateValue == null) { entity.PaymentAccountSortCode = null; }
            else
            {
                entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetailMetadata.CreatePaymentAccountSortCode(PaymentAccountSortCodeUpdateValue);
            }
        }
    }
}

internal partial class PaymentDetailFactory : PaymentDetailFactoryBase
{
}