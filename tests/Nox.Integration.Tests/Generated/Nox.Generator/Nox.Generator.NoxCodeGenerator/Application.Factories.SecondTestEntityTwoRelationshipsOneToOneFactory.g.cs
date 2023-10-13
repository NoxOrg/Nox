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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityTwoRelationshipsOneToOneFactoryBase : IEntityFactory<SecondTestEntityTwoRelationshipsOneToOneEntity, SecondTestEntityTwoRelationshipsOneToOneCreateDto, SecondTestEntityTwoRelationshipsOneToOneUpdateDto>
{

    public SecondTestEntityTwoRelationshipsOneToOneFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityTwoRelationshipsOneToOneEntity CreateEntity(SecondTestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityTwoRelationshipsOneToOneEntity entity, SecondTestEntityTwoRelationshipsOneToOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne ToEntity(SecondTestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne();
        entity.Id = SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityTwoRelationshipsOneToOneEntity entity, SecondTestEntityTwoRelationshipsOneToOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityTwoRelationshipsOneToOneFactory : SecondTestEntityTwoRelationshipsOneToOneFactoryBase
{
}