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

internal abstract class TransactionFactoryBase : IEntityFactory<TransactionEntity, TransactionCreateDto, TransactionUpdateDto>
{

    public TransactionFactoryBase
    (
        )
    {
    }

    public virtual TransactionEntity CreateEntity(TransactionCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TransactionEntity entity, TransactionUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TransactionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.Transaction ToEntity(TransactionCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Transaction();
        entity.TransactionType = Cryptocash.Domain.TransactionMetadata.CreateTransactionType(createDto.TransactionType);
        entity.ProcessedOnDateTime = Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(createDto.ProcessedOnDateTime);
        entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(createDto.Amount);
        entity.Reference = Cryptocash.Domain.TransactionMetadata.CreateReference(createDto.Reference);
        return entity;
    }

    private void UpdateEntityInternal(TransactionEntity entity, TransactionUpdateDto updateDto)
    {
        entity.TransactionType = Cryptocash.Domain.TransactionMetadata.CreateTransactionType(updateDto.TransactionType.NonNullValue<System.String>());
        entity.ProcessedOnDateTime = Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(updateDto.ProcessedOnDateTime.NonNullValue<System.DateTimeOffset>());
        entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
        entity.Reference = Cryptocash.Domain.TransactionMetadata.CreateReference(updateDto.Reference.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TransactionEntity entity, Dictionary<string, dynamic> updatedProperties)
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
                entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(AmountUpdateValue);
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
}

internal partial class TransactionFactory : TransactionFactoryBase
{
}