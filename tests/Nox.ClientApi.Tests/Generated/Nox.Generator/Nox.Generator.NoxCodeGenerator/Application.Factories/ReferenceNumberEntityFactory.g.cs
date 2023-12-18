
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

using ClientApi.Application.Dto;
using ClientApi.Domain;
using ReferenceNumberEntityEntity = ClientApi.Domain.ReferenceNumberEntity;

namespace ClientApi.Application.Factories;

internal partial class ReferenceNumberEntityFactory : ReferenceNumberEntityFactoryBase
{
    public ReferenceNumberEntityFactory
    (
        IRepository repository
    ) : base(repository)
    {}
}

internal abstract class ReferenceNumberEntityFactoryBase : IEntityFactory<ReferenceNumberEntityEntity, ReferenceNumberEntityCreateDto, ReferenceNumberEntityUpdateDto>
{
    private readonly IRepository _repository;

    public ReferenceNumberEntityFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<ReferenceNumberEntityEntity> CreateEntityAsync(ReferenceNumberEntityCreateDto createDto, Nox.Types.CultureCode cultureCode)
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

    public virtual async Task UpdateEntityAsync(ReferenceNumberEntityEntity entity, ReferenceNumberEntityUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(ReferenceNumberEntityEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<ClientApi.Domain.ReferenceNumberEntity> ToEntityAsync(ReferenceNumberEntityCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.ReferenceNumberEntity();

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        var nextSequenceId =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ReferenceNumberEntity", "Id"));
        entity.EnsureId(nextSequenceId,ClientApi.Domain.ReferenceNumberEntityMetadata.IdTypeOptions);
        var nextSequenceReferenceNumber =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("ReferenceNumberEntity", "ReferenceNumber"));
        entity.EnsureReferenceNumber(nextSequenceReferenceNumber,ClientApi.Domain.ReferenceNumberEntityMetadata.ReferenceNumberTypeOptions);        
        return entity;
    }

    private async Task UpdateEntityInternalAsync(ReferenceNumberEntityEntity entity, ReferenceNumberEntityUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(ReferenceNumberEntityEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}