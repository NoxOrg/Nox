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
using TestEntityZeroOrOneToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrOneToExactlyOneFactoryBase : IEntityFactory<TestEntityZeroOrOneToExactlyOneEntity, TestEntityZeroOrOneToExactlyOneCreateDto, TestEntityZeroOrOneToExactlyOneUpdateDto>
{

    public TestEntityZeroOrOneToExactlyOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityZeroOrOneToExactlyOneEntity CreateEntity(TestEntityZeroOrOneToExactlyOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityZeroOrOneToExactlyOneEntity entity, TestEntityZeroOrOneToExactlyOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrOneToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne ToEntity(TestEntityZeroOrOneToExactlyOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne();
        entity.Id = TestEntityZeroOrOneToExactlyOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrOneToExactlyOneEntity entity, TestEntityZeroOrOneToExactlyOneUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToExactlyOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityZeroOrOneToExactlyOneFactory : TestEntityZeroOrOneToExactlyOneFactoryBase
{
}