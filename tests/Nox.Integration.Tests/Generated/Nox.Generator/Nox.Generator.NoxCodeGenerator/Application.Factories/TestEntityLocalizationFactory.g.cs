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

internal abstract class TestEntityLocalizationFactoryBase : IEntityFactory<TestEntityLocalizationEntity, TestEntityLocalizationCreateDto, TestEntityLocalizationUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityLocalizationFactoryBase
    (
        )
    {
    }

    public virtual TestEntityLocalizationEntity CreateEntity(TestEntityLocalizationCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityLocalization ToEntity(TestEntityLocalizationCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityLocalization();
        entity.Id = TestEntityLocalizationMetadata.CreateId(createDto.Id);
        entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(createDto.TextFieldToLocalize);
        entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(createDto.NumberField);
        return entity;
    }

    private void UpdateEntityInternal(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(IsDefaultCultureCode(cultureCode)) entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.NonNullValue<System.String>());
        entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(updateDto.NumberField.NonNullValue<System.Int16>());
    }

    private void PartialUpdateEntityInternal(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
        {
            if (TextFieldToLocalizeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextFieldToLocalize' can't be null");
            }
            {
                entity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NumberField", out var NumberFieldUpdateValue))
        {
            if (NumberFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'NumberField' can't be null");
            }
            {
                entity.NumberField = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateNumberField(NumberFieldUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityLocalizationFactory : TestEntityLocalizationFactoryBase
{
}