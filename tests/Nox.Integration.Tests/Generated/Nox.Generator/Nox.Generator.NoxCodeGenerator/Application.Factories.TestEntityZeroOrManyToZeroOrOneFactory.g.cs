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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrManyToZeroOrOneFactoryBase : IEntityFactory<TestEntityZeroOrManyToZeroOrOneEntity, TestEntityZeroOrManyToZeroOrOneCreateDto, TestEntityZeroOrManyToZeroOrOneUpdateDto>
{

    public TestEntityZeroOrManyToZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityZeroOrManyToZeroOrOneEntity CreateEntity(TestEntityZeroOrManyToZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityZeroOrManyToZeroOrOneEntity entity, TestEntityZeroOrManyToZeroOrOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrManyToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne ToEntity(TestEntityZeroOrManyToZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne();
        entity.Id = TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrManyToZeroOrOneEntity entity, TestEntityZeroOrManyToZeroOrOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrManyToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class TestEntityZeroOrManyToZeroOrOneFactory : TestEntityZeroOrManyToZeroOrOneFactoryBase
{
}