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
using SecondTestEntityOwnedRelationshipOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityOwnedRelationshipOneOrManyFactoryBase : IEntityFactory<SecondTestEntityOwnedRelationshipOneOrManyEntity, SecondTestEntityOwnedRelationshipOneOrManyCreateDto, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto>
{

    public SecondTestEntityOwnedRelationshipOneOrManyFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityOwnedRelationshipOneOrManyEntity CreateEntity(SecondTestEntityOwnedRelationshipOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityOwnedRelationshipOneOrManyEntity entity, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany ToEntity(SecondTestEntityOwnedRelationshipOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrMany();
        entity.Id = SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityOwnedRelationshipOneOrManyEntity entity, SecondTestEntityOwnedRelationshipOneOrManyUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityOwnedRelationshipOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityOwnedRelationshipOneOrManyMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityOwnedRelationshipOneOrManyFactory : SecondTestEntityOwnedRelationshipOneOrManyFactoryBase
{
}