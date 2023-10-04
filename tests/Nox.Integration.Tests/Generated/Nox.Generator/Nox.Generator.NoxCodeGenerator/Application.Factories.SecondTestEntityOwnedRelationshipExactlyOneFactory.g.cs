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
using SecondTestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityOwnedRelationshipExactlyOneFactoryBase : IEntityFactory<SecondTestEntityOwnedRelationshipExactlyOneEntity, SecondTestEntityOwnedRelationshipExactlyOneCreateDto, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto>
{

    public SecondTestEntityOwnedRelationshipExactlyOneFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityOwnedRelationshipExactlyOneEntity CreateEntity(SecondTestEntityOwnedRelationshipExactlyOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityOwnedRelationshipExactlyOneEntity entity, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne ToEntity(SecondTestEntityOwnedRelationshipExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne();
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityOwnedRelationshipExactlyOneEntity entity, SecondTestEntityOwnedRelationshipExactlyOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOwnedRelationshipExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityOwnedRelationshipExactlyOneFactory : SecondTestEntityOwnedRelationshipExactlyOneFactoryBase
{
}