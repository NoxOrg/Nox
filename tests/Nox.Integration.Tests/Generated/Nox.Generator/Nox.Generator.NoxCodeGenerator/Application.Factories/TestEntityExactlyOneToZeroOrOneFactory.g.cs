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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityExactlyOneToZeroOrOneFactoryBase : IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto>
{

    public TestEntityExactlyOneToZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityExactlyOneToZeroOrOneEntity CreateEntity(TestEntityExactlyOneToZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityExactlyOneToZeroOrOneEntity entity, TestEntityExactlyOneToZeroOrOneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityExactlyOneToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne ToEntity(TestEntityExactlyOneToZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne();
        entity.Id = TestEntityExactlyOneToZeroOrOneMetadata.CreateId(createDto.Id);
        entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityExactlyOneToZeroOrOneEntity entity, TestEntityExactlyOneToZeroOrOneUpdateDto updateDto)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityExactlyOneToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField2", out var TextTestField2UpdateValue))
        {
            if (TextTestField2UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField2' can't be null");
            }
            {
                entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(TextTestField2UpdateValue);
            }
        }
    }
}

internal partial class TestEntityExactlyOneToZeroOrOneFactory : TestEntityExactlyOneToZeroOrOneFactoryBase
{
}