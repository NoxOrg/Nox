
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using RatingProgramEntity = ClientApi.Domain.RatingProgram;

namespace ClientApi.Application.Factories;

internal partial class RatingProgramFactory : RatingProgramFactoryBase
{
    public RatingProgramFactory
    (
    ) : base()
    {}
}

internal abstract class RatingProgramFactoryBase : IEntityFactory<RatingProgramEntity, RatingProgramCreateDto, RatingProgramUpdateDto>
{

    public RatingProgramFactoryBase(
        )
    {
    }

    public virtual async Task<RatingProgramEntity> CreateEntityAsync(RatingProgramCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(RatingProgramEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(RatingProgramEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(RatingProgramEntity));
        }   
    }

    private async Task<ClientApi.Domain.RatingProgram> ToEntityAsync(RatingProgramCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.RatingProgram();
        exceptionCollector.Collect("StoreId",() => entity.StoreId = Dto.RatingProgramMetadata.CreateStoreId(createDto.StoreId.NonNullValue<System.Guid>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.RatingProgramMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(RatingProgramEntity entity, RatingProgramUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.Name is null)
        {
             entity.Name = null;
        }
        else
        {
            exceptionCollector.Collect("Name",() =>entity.Name = Dto.RatingProgramMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(RatingProgramEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null) { entity.Name = null; }
            else
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.RatingProgramMetadata.CreateName(NameUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}