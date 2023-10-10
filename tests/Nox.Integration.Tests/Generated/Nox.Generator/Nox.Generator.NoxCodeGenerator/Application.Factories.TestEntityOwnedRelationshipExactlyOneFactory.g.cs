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
using TestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOwnedRelationshipExactlyOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipExactlyOneEntity, TestEntityOwnedRelationshipExactlyOneCreateDto, TestEntityOwnedRelationshipExactlyOneUpdateDto>
{
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto> SecondTestEntityOwnedRelationshipExactlyOneFactory {get;}

    public TestEntityOwnedRelationshipExactlyOneFactoryBase
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto> secondtestentityownedrelationshipexactlyonefactory
        )
    {
        SecondTestEntityOwnedRelationshipExactlyOneFactory = secondtestentityownedrelationshipexactlyonefactory;
    }

    public virtual TestEntityOwnedRelationshipExactlyOneEntity CreateEntity(TestEntityOwnedRelationshipExactlyOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne ToEntity(TestEntityOwnedRelationshipExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne();
        entity.Id = TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(createDto.TextTestField);
        if (createDto.SecondTestEntityOwnedRelationshipExactlyOne is not null)
        {
            entity.CreateRefToSecondTestEntityOwnedRelationshipExactlyOne(SecondTestEntityOwnedRelationshipExactlyOneFactory.CreateEntity(createDto.SecondTestEntityOwnedRelationshipExactlyOne));
        }
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipExactlyOneEntity entity, TestEntityOwnedRelationshipExactlyOneUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityOwnedRelationshipExactlyOneFactory : TestEntityOwnedRelationshipExactlyOneFactoryBase
{
    public TestEntityOwnedRelationshipExactlyOneFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto> secondtestentityownedrelationshipexactlyonefactory
    ) : base(secondtestentityownedrelationshipexactlyonefactory)
    {}
}