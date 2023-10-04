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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityExactlyOneToOneOrManyFactoryBase : IEntityFactory<TestEntityExactlyOneToOneOrManyEntity, TestEntityExactlyOneToOneOrManyCreateDto, TestEntityExactlyOneToOneOrManyUpdateDto>
{

    public TestEntityExactlyOneToOneOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityExactlyOneToOneOrManyEntity CreateEntity(TestEntityExactlyOneToOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityExactlyOneToOneOrManyEntity entity, TestEntityExactlyOneToOneOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityExactlyOneToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityExactlyOneToOneOrMany ToEntity(TestEntityExactlyOneToOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityExactlyOneToOneOrMany();
        entity.Id = TestEntityExactlyOneToOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityExactlyOneToOneOrManyEntity entity, TestEntityExactlyOneToOneOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityExactlyOneToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityExactlyOneToOneOrManyFactory : TestEntityExactlyOneToOneOrManyFactoryBase
{
}