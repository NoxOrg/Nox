// Generated

#nullable enable

using System.Net.Mime;
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
    
    public virtual WorkplaceLocalized CreateLocalizedEntityFromDto(WorkplaceLocalizedDto localizedDto)
    {
        var localizedEntity = new WorkplaceLocalized
        {Id = Nuid.FromDatabase(localizedDto.Id),
            CultureCode = CultureCode.From(localizedDto.CultureCode),
            Description = Text.From(localizedDto.Description),
        };

        return localizedEntity;
    }
}