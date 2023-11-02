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
using TestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOwnedRelationshipZeroOrOneFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrOneEntity, TestEntityOwnedRelationshipZeroOrOneCreateDto, TestEntityOwnedRelationshipZeroOrOneUpdateDto>
{
    protected IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneCreateDto, SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto> SecondTestEntityOwnedRelationshipZeroOrOneFactory {get;}

    public TestEntityOwnedRelationshipZeroOrOneFactoryBase
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneCreateDto, SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto> secondtestentityownedrelationshipzerooronefactory
        )
    {
        SecondTestEntityOwnedRelationshipZeroOrOneFactory = secondtestentityownedrelationshipzerooronefactory;
    }

    public virtual TestEntityOwnedRelationshipZeroOrOneEntity CreateEntity(TestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne ToEntity(TestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne();
        entity.Id = TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(createDto.TextTestField);
        if (createDto.SecondTestEntityOwnedRelationshipZeroOrOne is not null)
        {
            entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrOne(SecondTestEntityOwnedRelationshipZeroOrOneFactory.CreateEntity(createDto.SecondTestEntityOwnedRelationshipZeroOrOne));
        }
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipZeroOrOneEntity entity, TestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityOwnedRelationshipZeroOrOneFactory : TestEntityOwnedRelationshipZeroOrOneFactoryBase
{
    public TestEntityOwnedRelationshipZeroOrOneFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne, SecondTestEntityOwnedRelationshipZeroOrOneCreateDto, SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto> secondtestentityownedrelationshipzerooronefactory
    ) : base(secondtestentityownedrelationshipzerooronefactory)
    {}
}