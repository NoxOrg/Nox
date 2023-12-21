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
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityLocalizationFactory : TestEntityLocalizationFactoryBase
{
    public TestEntityLocalizationFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class TestEntityLocalizationFactoryBase : IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public TestEntityLocalizationFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<TestEntityLocalizationEntity> CreateEntityAsync(TestEntityLocalizationCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<TestWebApp.Domain.TestEntityLocalization> ToEntityAsync(TestEntityLocalizationCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityLocalization();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityLocalizationMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextFieldToLocalize", () => entity.SetIfNotNull(createDto.TextFieldToLocalize, (entity) => entity.TextFieldToLocalize = 
            TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(createDto.TextFieldToLocalize.NonNullValue<System.String>())));
        exceptionCollector.Collect("NumberField", () => entity.SetIfNotNull(createDto.NumberField, (entity) => entity.NumberField = 
            TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(createDto.NumberField.NonNullValue<System.Int16>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("TextFieldToLocalize",() => entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.NonNullValue<System.String>()));
        exceptionCollector.Collect("NumberField",() => entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextFieldToLocalizeUpdateValue, "Attribute 'TextFieldToLocalize' can't be null.");
            {
                exceptionCollector.Collect("TextFieldToLocalize",() =>entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NumberField", out var NumberFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NumberFieldUpdateValue, "Attribute 'NumberField' can't be null.");
            {
                exceptionCollector.Collect("NumberField",() =>entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(NumberFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}