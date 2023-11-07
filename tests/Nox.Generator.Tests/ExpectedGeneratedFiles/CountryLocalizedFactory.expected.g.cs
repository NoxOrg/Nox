// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;
using CountryEntity = SampleWebApp.Domain.Country;

namespace SampleWebApp.Application.Factories;

internal partial class CountryLocalizedFactory : CountryLocalizedFactoryBase
{
}

internal abstract class CountryLocalizedFactoryBase : IEntityLocalizedFactory<CountryLocalized, CountryEntity, CountryUpdateDto>
{
    public virtual CountryLocalized CreateLocalizedEntity(CountryEntity entity, CultureCode cultureCode, bool withAttributes = true)
    {
        var localizedEntity = new CountryLocalized
        {
            Id = entity.Id,
            CultureCode = cultureCode,
        };

        if (withAttributes)
        {
            localizedEntity.FormalName = entity.FormalName;
            localizedEntity.AlphaCode3 = entity.AlphaCode3;
            localizedEntity.Capital = entity.Capital;
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(CountryLocalized localizedEntity, CountryUpdateDto updateDto)
    {
        localizedEntity.SetIfNotNull(updateDto.FormalName, (localizedEntity) => localizedEntity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(updateDto.FormalName.ToValueFromNonNull<System.String>()));
        localizedEntity.SetIfNotNull(updateDto.AlphaCode3, (localizedEntity) => localizedEntity.AlphaCode3 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(updateDto.AlphaCode3.ToValueFromNonNull<System.String>()));
        localizedEntity.SetIfNotNull(updateDto.Capital, (localizedEntity) => localizedEntity.Capital = SampleWebApp.Domain.CountryMetadata.CreateCapital(updateDto.Capital.ToValueFromNonNull<System.String>()));
    }

    public virtual void PartialUpdateLocalizedEntity(CountryLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("FormalName", out var FormalNameUpdateValue))
        {
            if (FormalNameUpdateValue == null)
            {
                localizedEntity.FormalName = null;
            }
            else
            {
                localizedEntity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(FormalNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AlphaCode3", out var AlphaCode3UpdateValue))
        {
            if (AlphaCode3UpdateValue == null)
            {
                localizedEntity.AlphaCode3 = null;
            }
            else
            {
                localizedEntity.AlphaCode3 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(AlphaCode3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Capital", out var CapitalUpdateValue))
        {
            if (CapitalUpdateValue == null)
            {
                localizedEntity.Capital = null;
            }
            else
            {
                localizedEntity.Capital = SampleWebApp.Domain.CountryMetadata.CreateCapital(CapitalUpdateValue);
            }
        }
    }
}