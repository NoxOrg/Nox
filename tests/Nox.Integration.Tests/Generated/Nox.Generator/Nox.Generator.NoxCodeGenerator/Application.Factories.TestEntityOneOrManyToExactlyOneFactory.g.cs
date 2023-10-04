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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOneOrManyToExactlyOneFactoryBase : IEntityFactory<TestEntityOneOrManyToExactlyOneEntity, TestEntityOneOrManyToExactlyOneCreateDto, TestEntityOneOrManyToExactlyOneUpdateDto>
{

    public TestEntityOneOrManyToExactlyOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityOneOrManyToExactlyOneEntity CreateEntity(TestEntityOneOrManyToExactlyOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityOneOrManyToExactlyOneEntity entity, TestEntityOneOrManyToExactlyOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityOneOrManyToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityOneOrManyToExactlyOne ToEntity(TestEntityOneOrManyToExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOneOrManyToExactlyOne();
        entity.Id = TestEntityOneOrManyToExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOneOrManyToExactlyOneEntity entity, TestEntityOneOrManyToExactlyOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOneOrManyToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class TestEntityOneOrManyToExactlyOneFactory : TestEntityOneOrManyToExactlyOneFactoryBase
{
}