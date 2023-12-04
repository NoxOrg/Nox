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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Factories;

internal abstract class MinimumCashStockFactoryBase : IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public MinimumCashStockFactoryBase
    (
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual MinimumCashStockEntity CreateEntity(MinimumCashStockCreateDto createDto)
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

    public virtual void UpdateEntity(MinimumCashStockEntity entity, MinimumCashStockUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(MinimumCashStockEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.MinimumCashStock ToEntity(MinimumCashStockCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.MinimumCashStock();
        entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(createDto.Amount);
        return entity;
    }

    private void UpdateEntityInternal(MinimumCashStockEntity entity, MinimumCashStockUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
    }

    private void PartialUpdateEntityInternal(MinimumCashStockEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            if (AmountUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Amount' can't be null");
            }
            {
                var updated = entity.Amount ?? new Nox.Types.Money();
                foreach(var pair in AmountUpdateValue)
                {
                    var property = typeof(Nox.Types.Money).GetProperty(pair.Key);
                    if (property != null)
                    {
                        var propertyValue = Convert.ChangeType(pair.Value, property.PropertyType);
                        property.SetValue(updated, propertyValue);
                    }
                }
                entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(updated);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class MinimumCashStockFactory : MinimumCashStockFactoryBase
{
    public MinimumCashStockFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}