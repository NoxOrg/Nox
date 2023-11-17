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
using TestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOwnedRelationshipZeroOrManyFactoryBase : IEntityFactory<TestEntityOwnedRelationshipZeroOrManyEntity, TestEntityOwnedRelationshipZeroOrManyCreateDto, TestEntityOwnedRelationshipZeroOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
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

    public virtual void UpdateEntity(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany ToEntity(TestEntityOwnedRelationshipZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany();
        entity.Id = TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        createDto.SecondTestEntityOwnedRelationshipZeroOrMany.ForEach(dto => entity.CreateRefToSecondTestEntityOwnedRelationshipZeroOrMany(SecondTestEntityOwnedRelationshipZeroOrManyFactory.CreateEntity(dto)));
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOwnedRelationshipZeroOrManyEntity entity, TestEntityOwnedRelationshipZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOwnedRelationshipZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityOwnedRelationshipZeroOrManyFactory : TestEntityOwnedRelationshipZeroOrManyFactoryBase
{
    public TestEntityOwnedRelationshipZeroOrManyFactory
    (
        IEntityFactory<TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany, SecondTestEntityOwnedRelationshipZeroOrManyCreateDto, SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> secondtestentityownedrelationshipzeroormanyfactory
    ) : base(secondtestentityownedrelationshipzeroormanyfactory)
    {}
}