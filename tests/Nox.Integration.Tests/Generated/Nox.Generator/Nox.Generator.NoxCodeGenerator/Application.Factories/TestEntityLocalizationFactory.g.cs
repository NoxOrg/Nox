
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
using Dto = TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityLocalizationFactory : TestEntityLocalizationFactoryBase
{
    public TestEntityLocalizationFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> testEntityLocalizationLocalizedFactory,
        NoxSolution noxSolution
    ) : base(repository, testEntityLocalizationLocalizedFactory, noxSolution)
    {}
}

internal abstract class TestEntityLocalizationFactoryBase : IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto>
{
    private readonly Nox.Types.CultureCode _defaultCultureCode;
    protected readonly IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> TestEntityLocalizationLocalizedFactory;
    private readonly IRepository _repository;

    public TestEntityLocalizationFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto> testEntityLocalizationLocalizedFactory,
        NoxSolution noxSolution
        )
    {
        _repository = repository;
        TestEntityLocalizationLocalizedFactory = testEntityLocalizationLocalizedFactory;
        _defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);
    }

    public virtual async Task<TestEntityLocalizationEntity> CreateEntityAsync(TestEntityLocalizationCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            TestEntityLocalizationLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityLocalizationEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await TestEntityLocalizationLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityLocalizationEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await TestEntityLocalizationLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TestEntityLocalizationEntity));
        }   
    }

    private async Task<TestWebApp.Domain.TestEntityLocalization> ToEntityAsync(TestEntityLocalizationCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityLocalization();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.TestEntityLocalizationMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextFieldToLocalize", () => entity.SetIfNotNull(createDto.TextFieldToLocalize, (entity) => entity.TextFieldToLocalize = 
            Dto.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(createDto.TextFieldToLocalize.NonNullValue<System.String>())));
        exceptionCollector.Collect("NumberField", () => entity.SetIfNotNull(createDto.NumberField, (entity) => entity.NumberField = 
            Dto.TestEntityLocalizationMetadata.CreateNumberField(createDto.NumberField.NonNullValue<System.Int16>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("TextFieldToLocalize",() => entity.TextFieldToLocalize = Dto.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.NonNullValue<System.String>()));
        exceptionCollector.Collect("NumberField",() => entity.NumberField = Dto.TestEntityLocalizationMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>()));

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
                exceptionCollector.Collect("TextFieldToLocalize",() =>entity.TextFieldToLocalize = Dto.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NumberField", out var NumberFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NumberFieldUpdateValue, "Attribute 'NumberField' can't be null.");
            {
                exceptionCollector.Collect("NumberField",() =>entity.NumberField = Dto.TestEntityLocalizationMetadata.CreateNumberField(NumberFieldUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}