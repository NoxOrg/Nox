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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityExactlyOneToZeroOrOneFactoryBase : IEntityFactory<TestEntityExactlyOneToZeroOrOneEntity, TestEntityExactlyOneToZeroOrOneCreateDto, TestEntityExactlyOneToZeroOrOneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityExactlyOneToZeroOrOneFactoryBase
    (
        )
    {
    }

    public virtual TestEntityExactlyOneToZeroOrOneEntity CreateEntity(TestEntityExactlyOneToZeroOrOneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityExactlyOneToZeroOrOneEntity entity, TestEntityExactlyOneToZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityExactlyOneToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne ToEntity(TestEntityExactlyOneToZeroOrOneCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne();
        entity.Id = TestEntityExactlyOneToZeroOrOneMetadata.CreateId(createDto.Id!);
        entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(createDto.TextTestField2);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityExactlyOneToZeroOrOneEntity entity, TestEntityExactlyOneToZeroOrOneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField2 = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateTextTestField2(updateDto.TextTestField2.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityExactlyOneToZeroOrOneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityExactlyOneToZeroOrOneFactory : TestEntityExactlyOneToZeroOrOneFactoryBase
{
}