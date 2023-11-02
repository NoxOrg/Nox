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
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityTwoRelationshipsOneToOneFactoryBase : IEntityFactory<TestEntityTwoRelationshipsOneToOneEntity, TestEntityTwoRelationshipsOneToOneCreateDto, TestEntityTwoRelationshipsOneToOneUpdateDto>
{

    public TestEntityTwoRelationshipsOneToOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityTwoRelationshipsOneToOneEntity CreateEntity(TestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityTwoRelationshipsOneToOneEntity entity, TestEntityTwoRelationshipsOneToOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne ToEntity(TestEntityTwoRelationshipsOneToOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne();
        entity.Id = TestEntityTwoRelationshipsOneToOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityTwoRelationshipsOneToOneEntity entity, TestEntityTwoRelationshipsOneToOneUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityTwoRelationshipsOneToOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityTwoRelationshipsOneToOneFactory : TestEntityTwoRelationshipsOneToOneFactoryBase
{
}