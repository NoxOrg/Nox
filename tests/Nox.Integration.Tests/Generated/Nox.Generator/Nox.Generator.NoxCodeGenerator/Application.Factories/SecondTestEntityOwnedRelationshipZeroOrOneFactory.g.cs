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
using SecondTestEntityOwnedRelationshipZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityOwnedRelationshipZeroOrOneFactoryBase : IEntityFactory<SecondTestEntityOwnedRelationshipZeroOrOneEntity, SecondTestEntityOwnedRelationshipZeroOrOneCreateDto, SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto>
{

    public SecondTestEntityOwnedRelationshipZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityOwnedRelationshipZeroOrOneEntity CreateEntity(SecondTestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne ToEntity(SecondTestEntityOwnedRelationshipZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOne();
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOwnedRelationshipZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityOwnedRelationshipZeroOrOneFactory : SecondTestEntityOwnedRelationshipZeroOrOneFactoryBase
{
}