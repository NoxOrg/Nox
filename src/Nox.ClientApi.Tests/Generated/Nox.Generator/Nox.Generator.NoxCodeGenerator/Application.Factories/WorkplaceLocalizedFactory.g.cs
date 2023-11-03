// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Factories;

internal partial class WorkplaceLocalizedFactory : WorkplaceLocalizedFactoryBase
{
}

internal abstract class WorkplaceLocalizedFactoryBase : IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto>
{
    public virtual WorkplaceLocalized CreateLocalizedEntity(WorkplaceEntity entity, CultureCode cultureCode)
    {
        var localizedEntity = new WorkplaceLocalized
        {
            Id = entity.Id,
            CultureCode = cultureCode,
            Description = entity.Description,
        };

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(WorkplaceLocalized localizedEntity, WorkplaceUpdateDto updateDto, CultureCode cultureCode)
    {
        localizedEntity.SetIfNotNull(updateDto.Description, (localizedEntity) => localizedEntity.Description = ClientApi.Domain.WorkplaceMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>()));
    }

    public virtual void PartialUpdateEntity(WorkplaceLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties, CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            if (DescriptionUpdateValue == null)
            {
                localizedEntity.Description = null;
            }
            else
            {
                localizedEntity.Description = ClientApi.Domain.WorkplaceMetadata.CreateDescription(DescriptionUpdateValue);
            }
        }
    }
}