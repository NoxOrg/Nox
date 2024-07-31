
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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Factories;

internal partial class SecondTestEntityTwoRelationshipsManyToManyFactory : SecondTestEntityTwoRelationshipsManyToManyFactoryBase
{
    public SecondTestEntityTwoRelationshipsManyToManyFactory
    (
    ) : base()
    {}
}

internal abstract class SecondTestEntityTwoRelationshipsManyToManyFactoryBase : IEntityFactory<SecondTestEntityTwoRelationshipsManyToManyEntity, SecondTestEntityTwoRelationshipsManyToManyCreateDto, SecondTestEntityTwoRelationshipsManyToManyUpdateDto>
{

    public SecondTestEntityTwoRelationshipsManyToManyFactoryBase(
        )
    {
    }

    public virtual async Task<SecondTestEntityTwoRelationshipsManyToManyEntity> CreateEntityAsync(SecondTestEntityTwoRelationshipsManyToManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(SecondTestEntityTwoRelationshipsManyToManyEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(SecondTestEntityTwoRelationshipsManyToManyEntity entity, SecondTestEntityTwoRelationshipsManyToManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(SecondTestEntityTwoRelationshipsManyToManyEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(SecondTestEntityTwoRelationshipsManyToManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(SecondTestEntityTwoRelationshipsManyToManyEntity));
        }   
    }

    private async Task<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany> ToEntityAsync(SecondTestEntityTwoRelationshipsManyToManyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField2", () => entity.SetIfNotNull(createDto.TextTestField2, (entity) => entity.TextTestField2 = 
            Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField2(createDto.TextTestField2.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(SecondTestEntityTwoRelationshipsManyToManyEntity entity, SecondTestEntityTwoRelationshipsManyToManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField2",() => entity.TextTestField2 = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(SecondTestEntityTwoRelationshipsManyToManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestField2UpdateValue, "Attribute 'TextTestField2' can't be null.");
            {
                exceptionCollector.Collect("TextTestField2",() =>entity.TextTestField2 = Dto.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField2(TextTestField2UpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}