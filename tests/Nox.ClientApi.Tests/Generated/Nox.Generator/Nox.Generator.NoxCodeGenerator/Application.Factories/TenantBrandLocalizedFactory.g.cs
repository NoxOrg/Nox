// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Factories;

internal partial class TenantBrandLocalizedFactory : TenantBrandLocalizedFactoryBase
{
    public TenantBrandLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class TenantBrandLocalizedFactoryBase : IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto>
{
    protected readonly IRepository Repository;

    protected TenantBrandLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual TenantBrandLocalized CreateLocalizedEntity(TenantBrandEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = CreateInternal(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TenantBrandLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        entityLocalized.Description = updateDto.Description == null
            ? null
            : Dto.TenantBrandMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<TenantBrandLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            entityLocalized.Description = DescriptionUpdateValue == null
                ? null
                : Dto.TenantBrandMetadata.CreateDescription(DescriptionUpdateValue);
        }
    }

    private TenantBrandLocalized CreateInternal(TenantBrandEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
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
        entity.CreateRefToLocalizedTenantBrands(localizedEntity);
        return localizedEntity;
    }
}