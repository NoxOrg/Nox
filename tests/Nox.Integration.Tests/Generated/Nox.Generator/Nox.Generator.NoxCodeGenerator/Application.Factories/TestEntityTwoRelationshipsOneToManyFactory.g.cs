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
using TestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityTwoRelationshipsOneToManyFactory : TestEntityTwoRelationshipsOneToManyFactoryBase
{
    public TestEntityTwoRelationshipsOneToManyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityTwoRelationshipsOneToManyFactoryBase : IEntityFactory<TestEntityTwoRelationshipsOneToManyEntity, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityTwoRelationshipsOneToManyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityTwoRelationshipsOneToManyEntity> CreateEntityAsync(TestEntityTwoRelationshipsOneToManyCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TestEntityTwoRelationshipsOneToManyEntity entity, TestEntityTwoRelationshipsOneToManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsOneToManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany> ToEntityAsync(TestEntityTwoRelationshipsOneToManyCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityTwoRelationshipsOneToManyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityTwoRelationshipsOneToManyEntity entity, TestEntityTwoRelationshipsOneToManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityTwoRelationshipsOneToManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}