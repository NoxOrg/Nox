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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrOneToZeroOrManyFactoryBase : IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto>
{

    public TestEntityZeroOrOneToZeroOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityZeroOrOneToZeroOrManyEntity CreateEntity(TestEntityZeroOrOneToZeroOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityZeroOrOneToZeroOrManyEntity entity, TestEntityZeroOrOneToZeroOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany ToEntity(TestEntityZeroOrOneToZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany();
        entity.Id = TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrOneToZeroOrManyEntity entity, TestEntityZeroOrOneToZeroOrManyUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityZeroOrOneToZeroOrManyFactory : TestEntityZeroOrOneToZeroOrManyFactoryBase
{
}