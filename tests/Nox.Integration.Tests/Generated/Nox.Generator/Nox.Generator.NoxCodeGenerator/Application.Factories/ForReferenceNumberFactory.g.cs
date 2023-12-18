
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
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(ForReferenceNumberEntity entity, ForReferenceNumberUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(ForReferenceNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    private async Task<TestWebApp.Domain.ForReferenceNumber> ToEntityAsync(ForReferenceNumberCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.ForReferenceNumber();

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        var nextSequenceId =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ForReferenceNumber", "Id"));
        entity.EnsureId(nextSequenceId,TestWebApp.Domain.ForReferenceNumberMetadata.IdTypeOptions);
        var nextSequenceWorkplaceNumber =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ForReferenceNumber", "WorkplaceNumber"));
        entity.EnsureWorkplaceNumber(nextSequenceWorkplaceNumber,TestWebApp.Domain.ForReferenceNumberMetadata.WorkplaceNumberTypeOptions);        
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