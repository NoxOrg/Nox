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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityOneOrManyToZeroOrManyFactoryBase : IEntityFactory<TestEntityOneOrManyToZeroOrManyEntity, TestEntityOneOrManyToZeroOrManyCreateDto, TestEntityOneOrManyToZeroOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityOneOrManyToZeroOrManyFactoryBase
    (
        )
    {
    }

    public virtual TestEntityOneOrManyToZeroOrManyEntity CreateEntity(TestEntityOneOrManyToZeroOrManyCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(TestEntityOneOrManyToZeroOrManyEntity entity, TestEntityOneOrManyToZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityOneOrManyToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany ToEntity(TestEntityOneOrManyToZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany();
        entity.Id = TestEntityOneOrManyToZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityOneOrManyToZeroOrManyEntity entity, TestEntityOneOrManyToZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityOneOrManyToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityOneOrManyToZeroOrManyFactory : TestEntityOneOrManyToZeroOrManyFactoryBase
{
}