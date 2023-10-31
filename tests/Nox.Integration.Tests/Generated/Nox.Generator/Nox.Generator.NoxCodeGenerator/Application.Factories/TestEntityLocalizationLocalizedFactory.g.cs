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

internal abstract class TestEntityLocalizationLocalizedFactoryBase : IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity>
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
}