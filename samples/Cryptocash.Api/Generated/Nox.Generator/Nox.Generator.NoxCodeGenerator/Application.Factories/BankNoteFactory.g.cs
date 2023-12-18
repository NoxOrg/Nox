﻿// Generated

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
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Factories;

internal partial class BankNoteFactory : BankNoteFactoryBase
{
    public BankNoteFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class BankNoteFactoryBase : IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public BankNoteFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<BankNoteEntity> CreateEntityAsync(BankNoteUpsertDto createDto)
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

    public virtual async Task UpdateEntityAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.BankNote> ToEntityAsync(BankNoteUpsertDto createDto)
    {
        var entity = new Cryptocash.Domain.BankNote();
        entity.SetIfNotNull(createDto.CashNote, (entity) => entity.CashNote = 
            Cryptocash.Domain.BankNoteMetadata.CreateCashNote(createDto.CashNote.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Value, (entity) => entity.Value = 
            Cryptocash.Domain.BankNoteMetadata.CreateValue(createDto.Value.NonNullValue<MoneyDto>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(updateDto.CashNote.NonNullValue<System.String>());
        entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(updateDto.Value.NonNullValue<MoneyDto>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("CashNote", out var CashNoteUpdateValue))
        {
            if (CashNoteUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'CashNote' can't be null");
            }
            {
                entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(CashNoteUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Value", out var ValueUpdateValue))
        {
            if (ValueUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Value' can't be null");
            }
            {
                var entityToUpdate = entity.Value is null ? new MoneyDto() : entity.Value.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, ValueUpdateValue);
                entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(entityToUpdate);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}