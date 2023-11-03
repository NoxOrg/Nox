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
    public virtual TestEntityLocalizationLocalized CreateLocalizedEntity(TestEntityLocalizationEntity entity, CultureCode cultureCode)
    {
        var localizedEntity = new TestEntityLocalizationLocalized
        {
            Id = entity.Id,
            CultureCode = cultureCode,
            TextFieldToLocalize = entity.TextFieldToLocalize,
        };

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(TestEntityLocalizationLocalized localizedEntity, TestEntityLocalizationUpdateDto updateDto, CultureCode cultureCode)
    {
        localizedEntity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.NonNullValue<System.String>());
    }

    public virtual void PartialUpdateEntity(TestEntityLocalizationLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties, CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
        {
            if (TextFieldToLocalizeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextFieldToLocalize' can't be null");
            }
            {
                localizedEntity.TextFieldToLocalize = TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue);
            }
        }
    }
}