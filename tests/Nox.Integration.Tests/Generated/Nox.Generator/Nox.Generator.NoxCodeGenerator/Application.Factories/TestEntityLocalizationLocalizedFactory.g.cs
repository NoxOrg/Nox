// Generated

#nullable enable

using System.Net.Mime;
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

internal abstract class TestEntityLocalizationLocalizedFactoryBase : IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationLocalizedCreateDto>
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
    
    public virtual TestEntityLocalizationLocalized CreateLocalizedEntity(TestEntityLocalizationLocalizedCreateDto localizedCreateDto)
    {
        var localizedEntity = new TestEntityLocalizationLocalized
        { 
            Id = Text.From(localizedCreateDto.Id),
            CultureCode = CultureCode.From(localizedCreateDto.CultureCode),
            TextFieldToLocalize = Text.From(localizedCreateDto.TextFieldToLocalize.ToValueFromNonNull()),
        };

        return localizedEntity;
    }
}