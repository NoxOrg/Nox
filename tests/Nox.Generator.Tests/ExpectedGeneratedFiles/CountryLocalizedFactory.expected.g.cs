// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;
using CountryEntity = SampleWebApp.Domain.Country;

namespace SampleWebApp.Application.Factories;

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
        var entityLocalized = await Repository.Query<CountryLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        entityLocalized.FormalName = updateDto.FormalName == null
            ? null
            : SampleWebApp.Domain.CountryMetadata.CreateFormalName(updateDto.FormalName.ToValueFromNonNull<System.String>());
        entityLocalized.AlphaCode3 = updateDto.AlphaCode3 == null
            ? null
            : SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(updateDto.AlphaCode3.ToValueFromNonNull<System.String>());
        entityLocalized.Capital = updateDto.Capital == null
            ? null
            : SampleWebApp.Domain.CountryMetadata.CreateCapital(updateDto.Capital.ToValueFromNonNull<System.String>());
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<CountryLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        if (updatedProperties.TryGetValue("FormalName", out var FormalNameUpdateValue))
        {
            entityLocalized.FormalName = FormalNameUpdateValue == null
                ? null
                : SampleWebApp.Domain.CountryMetadata.CreateFormalName(FormalNameUpdateValue);
        }
        if (updatedProperties.TryGetValue("AlphaCode3", out var AlphaCode3UpdateValue))
        {
            entityLocalized.AlphaCode3 = AlphaCode3UpdateValue == null
                ? null
                : SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(AlphaCode3UpdateValue);
        }
        if (updatedProperties.TryGetValue("Capital", out var CapitalUpdateValue))
        {
            entityLocalized.Capital = CapitalUpdateValue == null
                ? null
                : SampleWebApp.Domain.CountryMetadata.CreateCapital(CapitalUpdateValue);
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
            localizedEntity.FormalName = entity.FormalName;
            localizedEntity.AlphaCode3 = entity.AlphaCode3;
            localizedEntity.Capital = entity.Capital;
        }
        entity.CreateRefToLocalizedCountries(localizedEntity);
        return localizedEntity;
    }
}