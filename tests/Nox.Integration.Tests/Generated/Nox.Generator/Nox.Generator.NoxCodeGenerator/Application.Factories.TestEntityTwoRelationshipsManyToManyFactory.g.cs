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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityTwoRelationshipsManyToManyFactoryBase : IEntityFactory<TestEntityTwoRelationshipsManyToManyEntity, TestEntityTwoRelationshipsManyToManyCreateDto, TestEntityTwoRelationshipsManyToManyUpdateDto>
{

    public TestEntityTwoRelationshipsManyToManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityTwoRelationshipsManyToManyEntity CreateEntity(TestEntityTwoRelationshipsManyToManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityTwoRelationshipsManyToManyEntity entity, TestEntityTwoRelationshipsManyToManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsManyToManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany ToEntity(TestEntityTwoRelationshipsManyToManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany();
        entity.Id = TestEntityTwoRelationshipsManyToManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityTwoRelationshipsManyToManyEntity entity, TestEntityTwoRelationshipsManyToManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityTwoRelationshipsManyToManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityTwoRelationshipsManyToManyFactory : TestEntityTwoRelationshipsManyToManyFactoryBase
{
}