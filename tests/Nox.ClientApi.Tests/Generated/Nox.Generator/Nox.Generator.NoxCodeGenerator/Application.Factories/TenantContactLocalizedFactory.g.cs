// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Factories;

internal partial class TenantContactLocalizedFactory : TenantContactLocalizedFactoryBase
{
    public TenantContactLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class TenantContactLocalizedFactoryBase : IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto>
{
    protected readonly IRepository Repository;

    protected TenantContactLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual async Task<TenantContactLocalized> CreateLocalizedEntityAsync(TenantContactEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = await CreateInternalAsync(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(TenantContactEntity entity, TenantContactUpsertDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TenantContactLocalized>(x => x.TenantId == entity.TenantId && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = await CreateLocalizedEntityAsync(entity, cultureCode);
        }
        else
        {
            entityLocalized.Description = updateDto.Description == null
                ? null
                : ClientApi.Domain.TenantContactMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
            
            Repository.Update(entityLocalized);
        }
        
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TenantContactLocalized>(x => x.TenantId == entity.TenantId && x.CultureCode == cultureCode).FirstOrDefaultAsync();
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
                    : ClientApi.Domain.TenantContactMetadata.CreateDescription(DescriptionUpdateValue);
            }
            Repository.Update(entityLocalized);
        }
        
    }

    private async  Task<TenantContactLocalized> CreateInternalAsync(TenantContactEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
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
        await Repository.AddAsync(localizedEntity);
        return localizedEntity;
    }
}