// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Factories;

internal partial class TenantContactLocalizedFactory : TenantContactLocalizedFactoryBase
{
}

internal abstract class TenantContactLocalizedFactoryBase : IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto>
{
    public virtual TenantContactLocalized CreateLocalizedEntity(TenantContactEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new TenantContactLocalized
        {
            TenantContact = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.Description = entity.Description;
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(TenantContactLocalized localizedEntity, TenantContactUpsertDto updateDto)
    {
        localizedEntity.Description = updateDto.Description == null
            ? null
            : ClientApi.Domain.TenantContactMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
    }

    public virtual void PartialUpdateLocalizedEntity(TenantContactLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            localizedEntity.Description = DescriptionUpdateValue == null
                ? null
                : ClientApi.Domain.TenantContactMetadata.CreateDescription(DescriptionUpdateValue);
        }
    }
}