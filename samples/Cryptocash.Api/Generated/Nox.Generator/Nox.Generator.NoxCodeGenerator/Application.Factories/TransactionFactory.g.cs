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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Factories;

internal partial class TransactionFactory : TransactionFactoryBase
{
    public TransactionFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TransactionFactoryBase : IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TransactionFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TransactionEntity> CreateEntityAsync(TransactionCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(TransactionEntity entity, TransactionUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(TransactionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.Transaction> ToEntityAsync(TransactionCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Transaction();
        entity.SetIfNotNull(createDto.TransactionType, (entity) => entity.TransactionType = 
            Cryptocash.Domain.TransactionMetadata.CreateTransactionType(createDto.TransactionType.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.ProcessedOnDateTime, (entity) => entity.ProcessedOnDateTime = 
            Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(createDto.ProcessedOnDateTime.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.Amount, (entity) => entity.Amount = 
            Cryptocash.Domain.TransactionMetadata.CreateAmount(createDto.Amount.NonNullValue<MoneyDto>()));
        entity.SetIfNotNull(createDto.Reference, (entity) => entity.Reference = 
            Cryptocash.Domain.TransactionMetadata.CreateReference(createDto.Reference.NonNullValue<System.String>()));
        entity.EnsureId(createDto.Id);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TransactionEntity entity, TransactionUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TransactionType = Cryptocash.Domain.TransactionMetadata.CreateTransactionType(updateDto.TransactionType.NonNullValue<System.String>());
        entity.ProcessedOnDateTime = Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(updateDto.ProcessedOnDateTime.NonNullValue<System.DateTimeOffset>());
        entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
        entity.Reference = Cryptocash.Domain.TransactionMetadata.CreateReference(updateDto.Reference.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TransactionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TransactionType", out var TransactionTypeUpdateValue))
        {
            if (TransactionTypeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TransactionType' can't be null");
            }
            {
                entity.TransactionType = Cryptocash.Domain.TransactionMetadata.CreateTransactionType(TransactionTypeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("ProcessedOnDateTime", out var ProcessedOnDateTimeUpdateValue))
        {
            if (ProcessedOnDateTimeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'ProcessedOnDateTime' can't be null");
            }
            {
                entity.ProcessedOnDateTime = Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(ProcessedOnDateTimeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            if (AmountUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Amount' can't be null");
            }
            {
                var entityToUpdate = entity.Amount is null ? new MoneyDto() : entity.Amount.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountUpdateValue);
                entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(entityToUpdate);
            }
        }

        if (updatedProperties.TryGetValue("Reference", out var ReferenceUpdateValue))
        {
            if (ReferenceUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Reference' can't be null");
            }
            {
                entity.Reference = Cryptocash.Domain.TransactionMetadata.CreateReference(ReferenceUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}