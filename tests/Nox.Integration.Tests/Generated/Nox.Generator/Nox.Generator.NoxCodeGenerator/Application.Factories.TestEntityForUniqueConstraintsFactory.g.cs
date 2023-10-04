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
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityForUniqueConstraintsFactoryBase : IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto>
{

    public TestEntityForUniqueConstraintsFactoryBase
    (
        )
    {
    }

    public virtual TestEntityForUniqueConstraintsEntity CreateEntity(TestEntityForUniqueConstraintsCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityForUniqueConstraintsEntity entity, TestEntityForUniqueConstraintsUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityForUniqueConstraintsEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityForUniqueConstraints ToEntity(TestEntityForUniqueConstraintsCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityForUniqueConstraints();
        entity.Id = TestEntityForUniqueConstraintsMetadata.CreateId(createDto.Id);
        entity.TextField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(createDto.TextField);
        entity.NumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(createDto.NumberField);
        entity.UniqueNumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(createDto.UniqueNumberField);
        entity.UniqueCountryCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(createDto.UniqueCountryCode);
        entity.UniqueCurrencyCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(createDto.UniqueCurrencyCode);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityForUniqueConstraintsEntity entity, TestEntityForUniqueConstraintsUpdateDto updateDto)
    {
        entity.TextField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>());
        entity.NumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>());
        entity.UniqueNumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(updateDto.UniqueNumberField.NonNullValue<System.Int16>());
        entity.UniqueCountryCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(updateDto.UniqueCountryCode.NonNullValue<System.String>());
        entity.UniqueCurrencyCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(updateDto.UniqueCurrencyCode.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(TestEntityForUniqueConstraintsEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextField", out var TextFieldUpdateValue))
        {
            if (TextFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextField' can't be null");
            }
            {
                entity.TextField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(TextFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NumberField", out var NumberFieldUpdateValue))
        {
            if (NumberFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'NumberField' can't be null");
            }
            {
                entity.NumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(NumberFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("UniqueNumberField", out var UniqueNumberFieldUpdateValue))
        {
            if (UniqueNumberFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'UniqueNumberField' can't be null");
            }
            {
                entity.UniqueNumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(UniqueNumberFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("UniqueCountryCode", out var UniqueCountryCodeUpdateValue))
        {
            if (UniqueCountryCodeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'UniqueCountryCode' can't be null");
            }
            {
                entity.UniqueCountryCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(UniqueCountryCodeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("UniqueCurrencyCode", out var UniqueCurrencyCodeUpdateValue))
        {
            if (UniqueCurrencyCodeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'UniqueCurrencyCode' can't be null");
            }
            {
                entity.UniqueCurrencyCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(UniqueCurrencyCodeUpdateValue);
            }
        }
    }
}

internal partial class TestEntityForUniqueConstraintsFactory : TestEntityForUniqueConstraintsFactoryBase
{
}