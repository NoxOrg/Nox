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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrManyToOneOrManyFactoryBase : IEntityFactory<TestEntityZeroOrManyToOneOrManyEntity, TestEntityZeroOrManyToOneOrManyCreateDto, TestEntityZeroOrManyToOneOrManyUpdateDto>
{

    public TestEntityZeroOrManyToOneOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityZeroOrManyToOneOrManyEntity CreateEntity(TestEntityZeroOrManyToOneOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityZeroOrManyToOneOrManyEntity entity, TestEntityZeroOrManyToOneOrManyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrManyToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany ToEntity(TestEntityZeroOrManyToOneOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany();
        entity.Id = TestEntityZeroOrManyToOneOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrManyToOneOrManyEntity entity, TestEntityZeroOrManyToOneOrManyUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrManyToOneOrManyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class TestEntityZeroOrManyToOneOrManyFactory : TestEntityZeroOrManyToOneOrManyFactoryBase
{
}