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
using TestEntityForUniqueConstraintsEntity = TestWebApp.Domain.TestEntityForUniqueConstraints;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityForUniqueConstraintsFactory : TestEntityForUniqueConstraintsFactoryBase
{
    public TestEntityForUniqueConstraintsFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityForUniqueConstraintsFactoryBase : IEntityFactory<TestEntityForUniqueConstraintsEntity, TestEntityForUniqueConstraintsCreateDto, TestEntityForUniqueConstraintsUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityForUniqueConstraintsFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityForUniqueConstraintsEntity> CreateEntityAsync(TestEntityForUniqueConstraintsCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityForUniqueConstraintsEntity entity, TestEntityForUniqueConstraintsUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityForUniqueConstraintsEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityForUniqueConstraints> ToEntityAsync(TestEntityForUniqueConstraintsCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityForUniqueConstraints();
        entity.Id = TestEntityForUniqueConstraintsMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.TextField, (entity) => entity.TextField = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(createDto.TextField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.NumberField, (entity) => entity.NumberField = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(createDto.NumberField.NonNullValue<System.Int16>()));
        entity.SetIfNotNull(createDto.UniqueNumberField, (entity) => entity.UniqueNumberField = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(createDto.UniqueNumberField.NonNullValue<System.Int16>()));
        entity.SetIfNotNull(createDto.UniqueCountryCode, (entity) => entity.UniqueCountryCode = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(createDto.UniqueCountryCode.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.UniqueCurrencyCode, (entity) => entity.UniqueCurrencyCode = 
            TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(createDto.UniqueCurrencyCode.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityForUniqueConstraintsEntity entity, TestEntityForUniqueConstraintsUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateTextField(updateDto.TextField.NonNullValue<System.String>());
        entity.NumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>());
        entity.UniqueNumberField = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueNumberField(updateDto.UniqueNumberField.NonNullValue<System.Int16>());
        entity.UniqueCountryCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCountryCode(updateDto.UniqueCountryCode.NonNullValue<System.String>());
        entity.UniqueCurrencyCode = TestWebApp.Domain.TestEntityForUniqueConstraintsMetadata.CreateUniqueCurrencyCode(updateDto.UniqueCurrencyCode.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityForUniqueConstraintsEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}