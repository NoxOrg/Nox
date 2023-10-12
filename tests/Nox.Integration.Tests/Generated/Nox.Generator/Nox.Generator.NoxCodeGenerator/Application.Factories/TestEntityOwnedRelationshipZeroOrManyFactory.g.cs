// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto>
{
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> SecondTestEntityOwnedRelationshipZeroOrManyFactory {get;}

    public TestEntityOwnedRelationshipZeroOrManyFactoryBase
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> secondtestentityownedrelationshipzeroormanyfactory
        )
    {
        SecondTestEntityOwnedRelationshipZeroOrManyFactory = secondtestentityownedrelationshipzeroormanyfactory;
    }

    public virtual TestEntityOwnedRelationshipZeroOrManyEntity CreateEntity(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany ToEntity(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany();
        entity.Id = TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        entity.SecondTestEntityOwnedRelationshipZeroOrMany = createDto.SecondTestEntityOwnedRelationshipZeroOrMany.Select(dto => SecondTestEntityOwnedRelationshipZeroOrManyFactory.CreateEntity(dto)).ToList();
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityOwnedRelationshipZeroOrManyFactory : TestEntityOwnedRelationshipZeroOrManyFactoryBase
{
    public TestEntityOwnedRelationshipZeroOrManyFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> secondtestentityownedrelationshipzeroormanyfactory
    ) : base(secondtestentityownedrelationshipzeroormanyfactory)
    {}
}