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
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityExactlyOneToZeroOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityExactlyOneToZeroOrManyEntity CreateEntity(TestEntityExactlyOneToZeroOrManyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityExactlyOneToZeroOrManyEntity entity, TestEntityExactlyOneToZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityExactlyOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany ToEntity(TestEntityExactlyOneToZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany();
        entity.Id = TestEntityExactlyOneToZeroOrManyMetadata.CreateId(createDto.Id!);
        entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityExactlyOneToZeroOrManyEntity entity, TestEntityExactlyOneToZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityExactlyOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityExactlyOneToZeroOrManyFactory : TestEntityExactlyOneToZeroOrManyFactoryBase
{
}