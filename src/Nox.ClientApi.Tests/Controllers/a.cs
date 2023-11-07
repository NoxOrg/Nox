// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Factories2;

internal partial class WorkplaceLocalizedFactory : WorkplaceLocalizedFactoryBase
{
}

internal abstract class WorkplaceLocalizedFactoryBase : IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto>
{
    public virtual WorkplaceLocalized CreateLocalizedEntity(WorkplaceEntity entity, CultureCode cultureCode, bool withAttributes = true)
    {
        var localizedEntity = new WorkplaceLocalized
        {
            Id = entity.Id,
            CultureCode = cultureCode,
        };

        if (withAttributes)
        {
            localizedEntity.Description = entity.Description;
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(WorkplaceLocalized localizedEntity, WorkplaceUpdateDto updateDto)
    {
        localizedEntity.Description = updateDto.Description == null
            ? null
            : ClientApi.Domain.WorkplaceMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
    }

    public virtual void PartialUpdateLocalizedEntity(WorkplaceLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            localizedEntity.Description = DescriptionUpdateValue == null
                ? null
                : ClientApi.Domain.WorkplaceMetadata.CreateDescription(DescriptionUpdateValue);
        }
    }
}