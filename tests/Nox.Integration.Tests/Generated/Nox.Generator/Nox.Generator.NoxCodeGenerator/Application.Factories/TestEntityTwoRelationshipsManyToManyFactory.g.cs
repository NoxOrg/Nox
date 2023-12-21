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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityTwoRelationshipsManyToManyFactory : TestEntityTwoRelationshipsManyToManyFactoryBase
{
    public TestEntityTwoRelationshipsManyToManyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityTwoRelationshipsManyToManyFactoryBase : IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityTwoRelationshipsManyToManyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityTwoRelationshipsManyToManyEntity> CreateEntityAsync(TestEntityTwoRelationshipsManyToManyCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TestEntityTwoRelationshipsManyToManyEntity entity, TestEntityTwoRelationshipsManyToManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsManyToManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany> ToEntityAsync(TestEntityTwoRelationshipsManyToManyCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityTwoRelationshipsManyToManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityTwoRelationshipsManyToManyEntity entity, TestEntityTwoRelationshipsManyToManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityTwoRelationshipsManyToManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}