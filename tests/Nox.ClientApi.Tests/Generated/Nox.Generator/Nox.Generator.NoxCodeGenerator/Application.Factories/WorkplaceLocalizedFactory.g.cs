// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Factories;

internal partial class WorkplaceLocalizedFactory : WorkplaceLocalizedFactoryBase
{
    public WorkplaceLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class WorkplaceLocalizedFactoryBase : IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto>
{
    protected readonly IRepository Repository;

    protected WorkplaceLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual async Task<WorkplaceLocalized> CreateLocalizedEntityAsync(WorkplaceEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = await CreateInternalAsync(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<WorkplaceLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = await CreateLocalizedEntityAsync(entity, cultureCode);
        }
        else
        {
            entityLocalized.Description = updateDto.Description == null
                ? null
                : ClientApi.Domain.WorkplaceMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
            
            Repository.Update(entityLocalized);
        }
        
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(WorkplaceEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<WorkplaceLocalized>(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = await CreateLocalizedEntityAsync(entity, cultureCode);
        }
        else
        {

            if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
            {
                entityLocalized.Description = DescriptionUpdateValue == null
                    ? null
                    : ClientApi.Domain.WorkplaceMetadata.CreateDescription(DescriptionUpdateValue);
            }
            Repository.Update(entityLocalized);
        }
        
    }

    private async  Task<WorkplaceLocalized> CreateInternalAsync(WorkplaceEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new WorkplaceLocalized
        {
            Id = entity.Id,
            Workplace = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.Description = entity.Description;
        }
        await Repository.AddAsync(localizedEntity);
        return localizedEntity;
    }
}