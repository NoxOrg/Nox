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

internal partial class MinimumCashStockFactory : MinimumCashStockFactoryBase
{
    public MinimumCashStockFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class MinimumCashStockFactoryBase : IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public MinimumCashStockFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<MinimumCashStockEntity> CreateEntityAsync(MinimumCashStockCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(MinimumCashStockEntity entity, MinimumCashStockUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(MinimumCashStockEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<Cryptocash.Domain.MinimumCashStock> ToEntityAsync(MinimumCashStockCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.MinimumCashStock();
        entity.SetIfNotNull(createDto.Amount, (entity) => entity.Amount = 
            Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(createDto.Amount.NonNullValue<MoneyDto>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(MinimumCashStockEntity entity, MinimumCashStockUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
        await Task.CompletedTask;
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
                var entityToUpdate = entity.Amount is null ? new MoneyDto() : entity.Amount.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountUpdateValue);
                entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(entityToUpdate);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}