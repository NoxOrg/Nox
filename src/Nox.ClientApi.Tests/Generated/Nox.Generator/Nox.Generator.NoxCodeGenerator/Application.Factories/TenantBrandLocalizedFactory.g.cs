// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Factories;

internal partial class TenantBrandLocalizedFactory : TenantBrandLocalizedFactoryBase
{
}

internal abstract class TenantBrandLocalizedFactoryBase : IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto>
{
    public virtual TenantBrandLocalized CreateLocalizedEntity(TenantBrandEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new TenantBrandLocalized
        {
            TenantBrand = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.Description = entity.Description;
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(TenantBrandLocalized localizedEntity, TenantBrandUpsertDto updateDto)
    {
        localizedEntity.Description = updateDto.Description == null
            ? null
            : ClientApi.Domain.TenantBrandMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
    }

    public virtual void PartialUpdateLocalizedEntity(TenantBrandLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            localizedEntity.Description = DescriptionUpdateValue == null
                ? null
                : ClientApi.Domain.TenantBrandMetadata.CreateDescription(DescriptionUpdateValue);
        }
    }
}