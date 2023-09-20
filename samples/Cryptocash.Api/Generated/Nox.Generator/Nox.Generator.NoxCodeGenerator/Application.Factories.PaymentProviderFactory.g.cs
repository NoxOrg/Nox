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
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application.Factories;

public abstract class PaymentProviderFactoryBase : IEntityFactory<PaymentProvider, PaymentProviderCreateDto, PaymentProviderUpdateDto>
{

    public PaymentProviderFactoryBase
    (
        )
    {
    }

    public virtual PaymentProvider CreateEntity(PaymentProviderCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(PaymentProvider entity, PaymentProviderUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private Cryptocash.Domain.PaymentProvider ToEntity(PaymentProviderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentProvider();
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProvider.CreatePaymentProviderName(createDto.PaymentProviderName);
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProvider.CreatePaymentProviderType(createDto.PaymentProviderType);
        //entity.PaymentDetails = PaymentDetails.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

    private void UpdateEntityInternal(PaymentProvider entity, PaymentProviderUpdateDto updateDto)
    {
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProvider.CreatePaymentProviderName(updateDto.PaymentProviderName.NonNullValue<System.String>());
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProvider.CreatePaymentProviderType(updateDto.PaymentProviderType.NonNullValue<System.String>());
        //entity.PaymentDetails = PaymentDetails.Select(dto => dto.ToEntity()).ToList();
    }
}

public partial class PaymentProviderFactory : PaymentProviderFactoryBase
{
}