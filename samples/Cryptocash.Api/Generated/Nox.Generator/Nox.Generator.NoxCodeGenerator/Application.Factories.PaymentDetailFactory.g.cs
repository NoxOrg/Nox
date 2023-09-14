using System;// Generated

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

public abstract class PaymentDetailFactoryBase: IEntityFactory<PaymentDetail,PaymentDetailCreateDto>
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
    private Cryptocash.Domain.PaymentDetail ToEntity(PaymentDetailCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentDetail();
        entity.PaymentAccountName = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountName(createDto.PaymentAccountName);
        entity.PaymentAccountNumber = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountNumber(createDto.PaymentAccountNumber);
        if (createDto.PaymentAccountSortCode is not null)entity.PaymentAccountSortCode = Cryptocash.Domain.PaymentDetail.CreatePaymentAccountSortCode(createDto.PaymentAccountSortCode.NonNullValue<System.String>());
        //entity.Customer = Customer.ToEntity();
        //entity.PaymentProvider = PaymentProvider.ToEntity();
        return entity;
    }
}

public partial class PaymentDetailFactory : PaymentDetailFactoryBase
{
}