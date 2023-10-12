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
using TestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOwnedRelationshipOneOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipOneOrManyEntity, TestEntityOwnedRelationshipOneOrManyCreateDto, TestEntityOwnedRelationshipOneOrManyUpdateDto>
{
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> SecondTestEntityOwnedRelationshipOneOrManyFactory {get;}

    public TestEntityOwnedRelationshipOneOrManyFactoryBase
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> secondtestentityownedrelationshiponeormanyfactory
        )
    {
        SecondTestEntityOwnedRelationshipOneOrManyFactory = secondtestentityownedrelationshiponeormanyfactory;
    }

    public virtual TestEntityOwnedRelationshipOneOrManyEntity CreateEntity(TestEntityOwnedRelationshipOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany ToEntity(TestEntityOwnedRelationshipOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany();
        entity.Id = TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        entity.SecondTestEntityOwnedRelationshipOneOrMany = createDto.SecondTestEntityOwnedRelationshipOneOrMany.Select(dto => SecondTestEntityOwnedRelationshipOneOrManyFactory.CreateEntity(dto)).ToList();
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipOneOrManyEntity entity, TestEntityOwnedRelationshipOneOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityOwnedRelationshipOneOrManyFactory : TestEntityOwnedRelationshipOneOrManyFactoryBase
{
    public TestEntityOwnedRelationshipOneOrManyFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto> secondtestentityownedrelationshiponeormanyfactory
    ) : base(secondtestentityownedrelationshiponeormanyfactory)
    {}
}