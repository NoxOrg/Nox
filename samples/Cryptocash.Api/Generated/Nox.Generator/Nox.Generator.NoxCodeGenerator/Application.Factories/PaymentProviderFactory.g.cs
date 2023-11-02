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

internal abstract class PaymentProviderFactoryBase : IEntityFactory<PaymentProviderEntity, PaymentProviderCreateDto, PaymentProviderUpdateDto>
{

    public PaymentProviderFactoryBase
    (
        )
    {
    }

    public virtual PaymentProviderEntity CreateEntity(PaymentProviderCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.PaymentProvider ToEntity(PaymentProviderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentProvider();
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(createDto.PaymentProviderName);
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(createDto.PaymentProviderType);
        return entity;
    }

    private void UpdateEntityInternal(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto)
    {
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(updateDto.PaymentProviderName.NonNullValue<System.String>());
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(updateDto.PaymentProviderType.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("PaymentProviderName", out var PaymentProviderNameUpdateValue))
        {
            if (PaymentProviderNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PaymentProviderName' can't be null");
            }
            {
                entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(PaymentProviderNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PaymentProviderType", out var PaymentProviderTypeUpdateValue))
        {
            if (PaymentProviderTypeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PaymentProviderType' can't be null");
            }
            {
                entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(PaymentProviderTypeUpdateValue);
            }
        }
    }
}

internal partial class PaymentProviderFactory : PaymentProviderFactoryBase
{
}