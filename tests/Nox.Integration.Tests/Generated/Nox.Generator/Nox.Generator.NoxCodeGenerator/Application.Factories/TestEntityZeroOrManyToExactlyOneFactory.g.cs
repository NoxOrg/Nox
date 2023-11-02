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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrManyToExactlyOneFactoryBase : IEntityFactory<TestEntityZeroOrManyToExactlyOneEntity, TestEntityZeroOrManyToExactlyOneCreateDto, TestEntityZeroOrManyToExactlyOneUpdateDto>
{

    public TestEntityZeroOrManyToExactlyOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityZeroOrManyToExactlyOneEntity CreateEntity(TestEntityZeroOrManyToExactlyOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityZeroOrManyToExactlyOneEntity entity, TestEntityZeroOrManyToExactlyOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrManyToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne ToEntity(TestEntityZeroOrManyToExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne();
        entity.Id = TestEntityZeroOrManyToExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrManyToExactlyOneEntity entity, TestEntityZeroOrManyToExactlyOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrManyToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class TestEntityZeroOrManyToExactlyOneFactory : TestEntityZeroOrManyToExactlyOneFactoryBase
{
}