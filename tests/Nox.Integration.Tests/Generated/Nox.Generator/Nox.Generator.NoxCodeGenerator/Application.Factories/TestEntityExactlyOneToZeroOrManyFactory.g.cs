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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityExactlyOneToZeroOrManyFactoryBase : IEntityFactory<TestEntityExactlyOneToZeroOrManyEntity, TestEntityExactlyOneToZeroOrManyCreateDto, TestEntityExactlyOneToZeroOrManyUpdateDto>
{

    public TestEntityExactlyOneToZeroOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityExactlyOneToZeroOrManyEntity CreateEntity(TestEntityExactlyOneToZeroOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityExactlyOneToZeroOrManyEntity entity, TestEntityExactlyOneToZeroOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityExactlyOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany ToEntity(TestEntityExactlyOneToZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany();
        entity.Id = TestEntityExactlyOneToZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityExactlyOneToZeroOrManyEntity entity, TestEntityExactlyOneToZeroOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityExactlyOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityExactlyOneToZeroOrManyFactory : TestEntityExactlyOneToZeroOrManyFactoryBase
{
}