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
    public virtual CountryLocalized CreateLocalizedEntity(CountryEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
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

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(CountryLocalized localizedEntity, CountryUpdateDto updateDto)
    {
        localizedEntity.FormalName = updateDto.FormalName == null
            ? null
            : SampleWebApp.Domain.CountryMetadata.CreateFormalName(updateDto.FormalName.ToValueFromNonNull<System.String>());
        localizedEntity.AlphaCode3 = updateDto.AlphaCode3 == null
            ? null
            : SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(updateDto.AlphaCode3.ToValueFromNonNull<System.String>());
        localizedEntity.Capital = updateDto.Capital == null
            ? null
            : SampleWebApp.Domain.CountryMetadata.CreateCapital(updateDto.Capital.ToValueFromNonNull<System.String>());
    }

    public virtual void PartialUpdateLocalizedEntity(CountryLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("FormalName", out var FormalNameUpdateValue))
        {
            localizedEntity.FormalName = FormalNameUpdateValue == null
                ? null
                : SampleWebApp.Domain.CountryMetadata.CreateFormalName(FormalNameUpdateValue);
        }

        if (updatedProperties.TryGetValue("AlphaCode3", out var AlphaCode3UpdateValue))
        {
            localizedEntity.AlphaCode3 = AlphaCode3UpdateValue == null
                ? null
                : SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(AlphaCode3UpdateValue);
        }

        if (updatedProperties.TryGetValue("Capital", out var CapitalUpdateValue))
        {
            localizedEntity.Capital = CapitalUpdateValue == null
                ? null
                : SampleWebApp.Domain.CountryMetadata.CreateCapital(CapitalUpdateValue);
        }
    }
}