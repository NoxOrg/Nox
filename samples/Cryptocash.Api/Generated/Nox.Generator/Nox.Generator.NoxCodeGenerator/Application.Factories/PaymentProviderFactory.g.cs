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
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public PaymentProviderFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual PaymentProviderEntity CreateEntity(PaymentProviderCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.PaymentProvider ToEntity(PaymentProviderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentProvider();
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(createDto.PaymentProviderName);
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(createDto.PaymentProviderType);
        return entity;
    }

    private void UpdateEntityInternal(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(updateDto.PaymentProviderName.NonNullValue<System.String>());
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(updateDto.PaymentProviderType.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class PaymentProviderFactory : PaymentProviderFactoryBase
{
    public PaymentProviderFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}