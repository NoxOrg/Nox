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
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;

namespace ClientApi.Application.Factories;

internal partial class WorkplaceAddressLocalizedFactory : WorkplaceAddressLocalizedFactoryBase
{
    public WorkplaceAddressLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class WorkplaceAddressLocalizedFactoryBase : IEntityLocalizedFactory<WorkplaceAddressLocalized, WorkplaceAddressEntity, WorkplaceAddressUpsertDto>
{
    protected readonly IRepository Repository;

    protected WorkplaceAddressLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual WorkplaceAddressLocalized CreateLocalizedEntity(WorkplaceAddressEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = CreateInternal(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(WorkplaceAddressEntity entity, WorkplaceAddressUpsertDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<WorkplaceAddressLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        entityLocalized.AddressLine = updateDto.AddressLine == null
            ? null
            : Dto.WorkplaceAddressMetadata.CreateAddressLine(updateDto.AddressLine.ToValueFromNonNull<System.String>());
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(WorkplaceAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<WorkplaceAddressLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        if (updatedProperties.TryGetValue("AddressLine", out var AddressLineUpdateValue))
        {
            entityLocalized.AddressLine = AddressLineUpdateValue == null
                ? null
                : Dto.WorkplaceAddressMetadata.CreateAddressLine(AddressLineUpdateValue);
        }
    }

    private WorkplaceAddressLocalized CreateInternal(WorkplaceAddressEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new WorkplaceAddressLocalized
        {
            WorkplaceAddress = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.AddressLine = entity.AddressLine;
        }
        entity.CreateRefToLocalizedWorkplaceAddresses(localizedEntity);
        return localizedEntity;
    }
}