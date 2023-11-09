// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityLocalizationLocalizedFactory : TestEntityLocalizationLocalizedFactoryBase
{
}

internal abstract class TestEntityLocalizationLocalizedFactoryBase : IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto>
{
    public virtual TestEntityLocalizationLocalized CreateLocalizedEntity(TestEntityLocalizationEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new TestEntityLocalizationLocalized
        {
            Id = entity.Id,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.TextFieldToLocalize = entity.TextFieldToLocalize;
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(TestEntityLocalizationLocalized localizedEntity, TestEntityLocalizationUpdateDto updateDto)
    {
        localizedEntity.TextFieldToLocalize = updateDto.TextFieldToLocalize == null
            ? null
            : TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.ToValueFromNonNull<System.String>());
    }

    public virtual void PartialUpdateLocalizedEntity(TestEntityLocalizationLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
        {
            localizedEntity.TextFieldToLocalize = TextFieldToLocalizeUpdateValue == null
                ? null
                : TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue);
        }
    }
}