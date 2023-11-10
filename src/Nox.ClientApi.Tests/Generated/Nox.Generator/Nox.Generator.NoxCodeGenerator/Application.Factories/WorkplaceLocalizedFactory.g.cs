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

internal abstract class WorkplaceLocalizedFactoryBase : IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceLocalizedCreateDto>
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
    
    public virtual WorkplaceLocalized CreateLocalizedEntity(WorkplaceLocalizedCreateDto localizedCreateDto)
    {
        var localizedEntity = new WorkplaceLocalized
        {Id = Nuid.FromDatabase(localizedCreateDto.Id),
            CultureCode = CultureCode.From(localizedCreateDto.CultureCode),
            Description = Text.From(localizedCreateDto.Description.ToValueFromNonNull()),
        };

        return localizedEntity;
    }
}