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
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TransactionEntity entity, TransactionUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TransactionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<Cryptocash.Domain.Transaction> ToEntityAsync(TransactionCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Transaction();
        exceptionCollector.Collect("TransactionType", () => entity.SetIfNotNull(createDto.TransactionType, (entity) => entity.TransactionType = 
            Cryptocash.Domain.TransactionMetadata.CreateTransactionType(createDto.TransactionType.NonNullValue<System.String>())));
        exceptionCollector.Collect("ProcessedOnDateTime", () => entity.SetIfNotNull(createDto.ProcessedOnDateTime, (entity) => entity.ProcessedOnDateTime = 
            Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(createDto.ProcessedOnDateTime.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("Amount", () => entity.SetIfNotNull(createDto.Amount, (entity) => entity.Amount = 
            Cryptocash.Domain.TransactionMetadata.CreateAmount(createDto.Amount.NonNullValue<MoneyDto>())));
        exceptionCollector.Collect("Reference", () => entity.SetIfNotNull(createDto.Reference, (entity) => entity.Reference = 
            Cryptocash.Domain.TransactionMetadata.CreateReference(createDto.Reference.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TransactionEntity entity, TransactionUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TransactionType",() => entity.TransactionType = Cryptocash.Domain.TransactionMetadata.CreateTransactionType(updateDto.TransactionType.NonNullValue<System.String>()));
        exceptionCollector.Collect("ProcessedOnDateTime",() => entity.ProcessedOnDateTime = Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(updateDto.ProcessedOnDateTime.NonNullValue<System.DateTimeOffset>()));
        exceptionCollector.Collect("Amount",() => entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>()));
        exceptionCollector.Collect("Reference",() => entity.Reference = Cryptocash.Domain.TransactionMetadata.CreateReference(updateDto.Reference.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TransactionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TransactionType", out var TransactionTypeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TransactionTypeUpdateValue, "Attribute 'TransactionType' can't be null.");
            {
                exceptionCollector.Collect("TransactionType",() =>entity.TransactionType = Cryptocash.Domain.TransactionMetadata.CreateTransactionType(TransactionTypeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("ProcessedOnDateTime", out var ProcessedOnDateTimeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(ProcessedOnDateTimeUpdateValue, "Attribute 'ProcessedOnDateTime' can't be null.");
            {
                exceptionCollector.Collect("ProcessedOnDateTime",() =>entity.ProcessedOnDateTime = Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(ProcessedOnDateTimeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AmountUpdateValue, "Attribute 'Amount' can't be null.");
            {
                var entityToUpdate = entity.Amount is null ? new MoneyDto() : entity.Amount.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountUpdateValue);
                exceptionCollector.Collect("Amount",() =>entity.Amount = Cryptocash.Domain.TransactionMetadata.CreateAmount(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("Reference", out var ReferenceUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(ReferenceUpdateValue, "Attribute 'Reference' can't be null.");
            {
                exceptionCollector.Collect("Reference",() =>entity.Reference = Cryptocash.Domain.TransactionMetadata.CreateReference(ReferenceUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}