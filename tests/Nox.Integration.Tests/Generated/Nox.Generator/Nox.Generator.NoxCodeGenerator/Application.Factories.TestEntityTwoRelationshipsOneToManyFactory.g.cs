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
using TestEntityTwoRelationshipsOneToMany = TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityTwoRelationshipsOneToManyFactoryBase : IEntityFactory<TestEntityTwoRelationshipsOneToMany, TestEntityTwoRelationshipsOneToManyCreateDto, TestEntityTwoRelationshipsOneToManyUpdateDto>
{

    public TestEntityTwoRelationshipsOneToManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityTwoRelationshipsOneToMany CreateEntity(TestEntityTwoRelationshipsOneToManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityTwoRelationshipsOneToMany entity, TestEntityTwoRelationshipsOneToManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsOneToMany entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany ToEntity(TestEntityTwoRelationshipsOneToManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany();
        entity.Id = TestEntityTwoRelationshipsOneToManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityTwoRelationshipsOneToMany entity, TestEntityTwoRelationshipsOneToManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityTwoRelationshipsOneToMany entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityTwoRelationshipsOneToManyFactory : TestEntityTwoRelationshipsOneToManyFactoryBase
{
}