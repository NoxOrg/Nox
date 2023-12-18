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

    public virtual async Task<TestEntityLocalizationLocalized> CreateLocalizedEntityAsync(TestEntityLocalizationEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = await CreateInternalAsync(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(TestEntityLocalizationEntity entity, TestEntityLocalizationUpdateDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TestEntityLocalizationLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = await CreateLocalizedEntityAsync(entity, cultureCode);
        }
        else
        {
            entityLocalized.TextFieldToLocalize = updateDto.TextFieldToLocalize == null
                ? null
                : TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(updateDto.TextFieldToLocalize.ToValueFromNonNull<System.String>());
            
            Repository.Update(entityLocalized);
        }
        
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(TestEntityLocalizationEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TestEntityLocalizationLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = await CreateLocalizedEntityAsync(entity, cultureCode);
        }
        else
        {

            if (updatedProperties.TryGetValue("TextFieldToLocalize", out var TextFieldToLocalizeUpdateValue))
            {
                entityLocalized.TextFieldToLocalize = TextFieldToLocalizeUpdateValue == null
                    ? null
                    : TestWebApp.Domain.TestEntityLocalizationMetadata.CreateTextFieldToLocalize(TextFieldToLocalizeUpdateValue);
            }
            Repository.Update(entityLocalized);
        }
        
    }

    private async  Task<TestEntityLocalizationLocalized> CreateInternalAsync(TestEntityLocalizationEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
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
        await Repository.AddAsync(localizedEntity);
        return localizedEntity;
    }
}