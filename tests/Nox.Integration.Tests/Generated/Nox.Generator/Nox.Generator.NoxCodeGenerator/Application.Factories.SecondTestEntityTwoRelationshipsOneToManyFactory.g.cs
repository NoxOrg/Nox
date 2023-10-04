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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Factories;

internal abstract class SecondTestEntityTwoRelationshipsOneToManyFactoryBase : IEntityFactory<SecondTestEntityTwoRelationshipsOneToManyEntity, SecondTestEntityTwoRelationshipsOneToManyCreateDto, SecondTestEntityTwoRelationshipsOneToManyUpdateDto>
{

    public SecondTestEntityTwoRelationshipsOneToManyFactoryBase
    (
        )
    {
    }

    public virtual SecondTestEntityTwoRelationshipsOneToManyEntity CreateEntity(SecondTestEntityTwoRelationshipsOneToManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(SecondTestEntityTwoRelationshipsOneToManyEntity entity, SecondTestEntityTwoRelationshipsOneToManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(SecondTestEntityTwoRelationshipsOneToManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany ToEntity(SecondTestEntityTwoRelationshipsOneToManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany();
        entity.Id = SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(SecondTestEntityTwoRelationshipsOneToManyEntity entity, SecondTestEntityTwoRelationshipsOneToManyUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(SecondTestEntityTwoRelationshipsOneToManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class SecondTestEntityTwoRelationshipsOneToManyFactory : SecondTestEntityTwoRelationshipsOneToManyFactoryBase
{
}