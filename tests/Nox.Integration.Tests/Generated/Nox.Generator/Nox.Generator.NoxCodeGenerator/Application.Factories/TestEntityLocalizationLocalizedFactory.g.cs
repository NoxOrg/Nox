// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityLocalizationEntity = TestWebApp.Domain.TestEntityLocalization;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityLocalizationLocalizedFactory : TestEntityLocalizationLocalizedFactoryBase
{
    public TestEntityLocalizationLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class TestEntityLocalizationLocalizedFactoryBase : IEntityLocalizedFactory<TestEntityLocalizationLocalized, TestEntityLocalizationEntity, TestEntityLocalizationUpdateDto>
{
    protected readonly IRepository Repository;

    protected TestEntityLocalizationLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual TestEntityLocalizationLocalized CreateLocalizedEntity(TestEntityLocalizationEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = CreateInternal(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TestEntityLocalizationLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        entityLocalized.TextFieldToLocalize = updateDto.TextFieldToLocalize == null
            ? null
            : TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.ToValueFromNonNull<System.String>());
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TestEntityLocalizationLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        if (updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
        {
            entityLocalized.TextFieldToLocalize = TextFieldToLocalizeUpdateValue == null
                ? null
                : TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue);
        }
    }

    private TestEntityLocalizationLocalized CreateInternal(TestEntityLocalizationEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new TestEntityLocalizationLocalized
        {
            TestEntityLocalization = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.TextFieldToLocalize = entity.TextFieldToLocalize;
        }
        entity.CreateRefToLocalizedTestEntityLocalizations(localizedEntity);
        return localizedEntity;
    }
}