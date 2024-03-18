// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Factories;

internal partial class CountryLocalizedFactory : CountryLocalizedFactoryBase
{
    public CountryLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class CountryLocalizedFactoryBase : IEntityLocalizedFactory<CountryLocalized, CountryEntity, CountryUpdateDto>
{
    protected readonly IRepository Repository;

    protected CountryLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual CountryLocalized CreateLocalizedEntity(CountryEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = CreateInternal(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(CountryEntity entity, CountryUpdateDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<CountryLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        entityLocalized.TestAttForLocalization = updateDto.TestAttForLocalization == null
            ? null
            : Dto.CountryMetadata.CreateTestAttForLocalization(updateDto.TestAttForLocalization.ToValueFromNonNull<System.String>());
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<CountryLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        if (updatedProperties.TryGetValue("TestAttForLocalization", out var TestAttForLocalizationUpdateValue))
        {
            entityLocalized.TestAttForLocalization = TestAttForLocalizationUpdateValue == null
                ? null
                : Dto.CountryMetadata.CreateTestAttForLocalization(TestAttForLocalizationUpdateValue);
        }
    }

    private CountryLocalized CreateInternal(CountryEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new CountryLocalized
        {
            Country = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.TestAttForLocalization = entity.TestAttForLocalization;
        }
        entity.CreateRefToLocalizedCountries(localizedEntity);
        return localizedEntity;
    }
}