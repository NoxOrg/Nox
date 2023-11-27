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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityZeroOrOneToZeroOrManyFactoryBase : IEntityFactory<TestEntityZeroOrOneToZeroOrManyEntity, TestEntityZeroOrOneToZeroOrManyCreateDto, TestEntityZeroOrOneToZeroOrManyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityZeroOrOneToZeroOrManyFactoryBase()
    {
    }

    public virtual TestEntityZeroOrOneToZeroOrManyEntity CreateEntity(TestEntityZeroOrOneToZeroOrManyCreateDto createDto)
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

    public virtual void UpdateEntity(TestEntityZeroOrOneToZeroOrManyEntity entity, TestEntityZeroOrOneToZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityZeroOrOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany ToEntity(TestEntityZeroOrOneToZeroOrManyCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany();
        entity.Id = TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(createDto.TextTestField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityZeroOrOneToZeroOrManyEntity entity, TestEntityZeroOrOneToZeroOrManyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityZeroOrOneToZeroOrManyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityZeroOrOneToZeroOrManyFactory : TestEntityZeroOrOneToZeroOrManyFactoryBase
{
}