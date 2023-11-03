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
    public virtual CountryLocalized CreateLocalizedEntity(CountryEntity entity, CultureCode cultureCode)
    {
        var localizedEntity = new CountryLocalized
        {
            Id = entity.Id,
            CultureCode = cultureCode,
            FormalName = entity.FormalName,
            AlphaCode3 = entity.AlphaCode3,
            Capital = entity.Capital,
        };

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(CountryLocalized localizedEntity, CountryUpdateDto updateDto, CultureCode cultureCode)
    {
        localizedEntity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(updateDto.FormalName.NonNullValue<System.String>());
        localizedEntity.AlphaCode3 = SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(updateDto.AlphaCode3.NonNullValue<System.String>());
        localizedEntity.SetIfNotNull(updateDto.Capital, (localizedEntity) => localizedEntity.Capital = SampleWebApp.Domain.CountryMetadata.CreateCapital(updateDto.Capital.ToValueFromNonNull<System.String>()));
    }

    public virtual void PartialUpdateEntity(CountryLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties, CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("FormalName", out var FormalNameUpdateValue))
        {
            if (FormalNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'FormalName' can't be null");
            }
            {
                localizedEntity.FormalName = SampleWebApp.Domain.CountryMetadata.CreateFormalName(FormalNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AlphaCode3", out var AlphaCode3UpdateValue))
        {
            if (AlphaCode3UpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AlphaCode3' can't be null");
            }
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