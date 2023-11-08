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

internal abstract class WorkplaceLocalizedFactoryBase : IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity>
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
}