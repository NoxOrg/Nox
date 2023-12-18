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
        IRepository repository
    ) : base( repository)
    {}
}

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

    public virtual async Task<PaymentProviderEntity> CreateEntityAsync(PaymentProviderCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(PaymentProviderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.PaymentProvider> ToEntityAsync(PaymentProviderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.PaymentProvider();
        entity.SetIfNotNull(createDto.PaymentProviderName, (entity) => entity.PaymentProviderName = 
            Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(createDto.PaymentProviderName.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.PaymentProviderType, (entity) => entity.PaymentProviderType = 
            Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(createDto.PaymentProviderType.NonNullValue<System.String>()));
        entity.EnsureId(createDto.Id);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(PaymentProviderEntity entity, PaymentProviderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.PaymentProviderName = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderName(updateDto.PaymentProviderName.NonNullValue<System.String>());
        entity.PaymentProviderType = Cryptocash.Domain.PaymentProviderMetadata.CreatePaymentProviderType(updateDto.PaymentProviderType.NonNullValue<System.String>());
        await Task.CompletedTask;
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