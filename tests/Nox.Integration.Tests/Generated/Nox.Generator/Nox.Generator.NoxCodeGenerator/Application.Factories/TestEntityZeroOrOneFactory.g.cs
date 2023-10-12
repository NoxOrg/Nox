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
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrOneFactoryBase : IEntityFactory<TestEntityZeroOrOneEntity, TestEntityZeroOrOneCreateDto, TestEntityZeroOrOneUpdateDto>
{

    public TestEntityZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityZeroOrOneEntity CreateEntity(TestEntityZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityZeroOrOneEntity entity, TestEntityZeroOrOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityZeroOrOne ToEntity(TestEntityZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrOne();
        entity.Id = TestEntityZeroOrOneMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrOneEntity entity, TestEntityZeroOrOneUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityZeroOrOneFactory : TestEntityZeroOrOneFactoryBase
{
}