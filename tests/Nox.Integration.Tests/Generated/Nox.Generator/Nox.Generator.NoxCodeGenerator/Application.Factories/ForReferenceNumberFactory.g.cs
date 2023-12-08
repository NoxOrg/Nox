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

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Factories;

internal partial class ForReferenceNumberFactory : ForReferenceNumberFactoryBase
{
    public ForReferenceNumberFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class ForReferenceNumberFactoryBase : IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public ForReferenceNumberFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<ForReferenceNumberEntity> CreateEntityAsync(ForReferenceNumberCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.ForReferenceNumber> ToEntityAsync(ForReferenceNumberCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.ForReferenceNumber();
        var nextSequenceId =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ForReferenceNumber", "Id"));
        entity.EnsureId(nextSequenceId,TestWebApp.Domain.ForReferenceNumberMetadata.IdTypeOptions);
        var nextSequenceWorkplaceNumber =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ForReferenceNumber", "WorkplaceNumber"));
        entity.EnsureWorkplaceNumber(nextSequenceWorkplaceNumber,TestWebApp.Domain.ForReferenceNumberMetadata.WorkplaceNumberTypeOptions);
        return entity;
    }

    private async Task UpdateEntityInternalAsync(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}