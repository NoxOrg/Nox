
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

using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using TestWebApp.Domain;
using ForReferenceNumberEntity = TestWebApp.Domain.ForReferenceNumber;

namespace TestWebApp.Application.Factories;

internal partial class ForReferenceNumberFactory : ForReferenceNumberFactoryBase
{
    public ForReferenceNumberFactory
    (
        IRepository repository
    ) : base(repository)
    {}
}

internal abstract class ForReferenceNumberFactoryBase : IEntityFactory<ForReferenceNumberEntity, ForReferenceNumberCreateDto, ForReferenceNumberUpdateDto>
{
    private readonly IRepository _repository;

    public ForReferenceNumberFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<ForReferenceNumberEntity> CreateEntityAsync(ForReferenceNumberCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(ForReferenceNumberEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(ForReferenceNumberEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(ForReferenceNumberEntity));
        }   
    }

    private async Task<TestWebApp.Domain.ForReferenceNumber> ToEntityAsync(ForReferenceNumberCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.ForReferenceNumber();

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        var nextSequenceId =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ForReferenceNumber", "Id"));
        entity.EnsureId(nextSequenceId,Dto.ForReferenceNumberMetadata.IdTypeOptions);
        var nextSequenceWorkplaceNumber =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ForReferenceNumber", "WorkplaceNumber"));
        entity.EnsureWorkplaceNumber(nextSequenceWorkplaceNumber,Dto.ForReferenceNumberMetadata.WorkplaceNumberTypeOptions);        
        return entity;
    }

    private async Task UpdateEntityInternalAsync(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}