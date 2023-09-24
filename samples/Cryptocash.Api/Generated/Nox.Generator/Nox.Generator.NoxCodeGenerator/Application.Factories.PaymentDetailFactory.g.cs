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
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application.Factories;

public abstract class PaymentDetailFactoryBase : IEntityFactory<PaymentDetail, PaymentDetailCreateDto, PaymentDetailUpdateDto>
{

    public PaymentDetailFactoryBase
    (
        )
    {
    }

    public virtual PaymentDetail CreateEntity(PaymentDetailCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(PaymentDetail entity, PaymentDetailUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(PaymentDetail entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.PaymentDetail ToEntity(PaymentDetailCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentDetail();
        entity.PaymentAccountName = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountName(createDto.PaymentAccountName);
        entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountNumber(createDto.PaymentAccountNumber);
        if (createDto.PaymentAccountSortCode is not null)entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountSortCode(createDto.PaymentAccountSortCode.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(PaymentDetail entity, PaymentDetailUpdateDto updateDto)
    {
        entity.PaymentAccountName = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountName(updateDto.PaymentAccountName.NonNullValue<System.String>());
        entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountNumber(updateDto.PaymentAccountNumber.NonNullValue<System.String>());
        if (updateDto.PaymentAccountSortCode == null) { entity.PaymentAccountSortCode = null; } else {
            entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountSortCode(updateDto.PaymentAccountSortCode.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(PaymentDetail entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("PaymentAccountName", out var PaymentAccountNameUpdateValue))
        {
            if (PaymentAccountNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PaymentAccountName' can't be null");
            }
            {
                entity.PaymentAccountName = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountName(PaymentAccountNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PaymentAccountNumber", out var PaymentAccountNumberUpdateValue))
        {
            if (PaymentAccountNumberUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PaymentAccountNumber' can't be null");
            }
            {
                entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountNumber(PaymentAccountNumberUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PaymentAccountSortCode", out var PaymentAccountSortCodeUpdateValue))
        {
            if (PaymentAccountSortCodeUpdateValue == null) { entity.PaymentAccountSortCode = null; }
            else
            {
                entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountSortCode(PaymentAccountSortCodeUpdateValue);
            }
        }
    }
}

public partial class PaymentDetailFactory : PaymentDetailFactoryBase
{
}