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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOneOrManyFactoryBase : IEntityFactory<TestEntityOneOrManyEntity, TestEntityOneOrManyCreateDto, TestEntityOneOrManyUpdateDto>
{

    public TestEntityOneOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityOneOrManyEntity CreateEntity(TestEntityOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityOneOrManyEntity entity, TestEntityOneOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityOneOrMany ToEntity(TestEntityOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOneOrMany();
        entity.Id = TestEntityOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOneOrManyEntity entity, TestEntityOneOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityOneOrManyFactory : TestEntityOneOrManyFactoryBase
{
}