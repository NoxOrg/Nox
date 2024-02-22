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
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Factories;

internal partial class CountryLocalNameLocalizedFactory : CountryLocalNameLocalizedFactoryBase
{
    public CountryLocalNameLocalizedFactory(IRepository repository):base(repository)
    {
    }
}

internal abstract class CountryLocalNameLocalizedFactoryBase : IEntityLocalizedFactory<CountryLocalNameLocalized, CountryLocalNameEntity, CountryLocalNameUpsertDto>
{
    protected readonly IRepository Repository;

    protected CountryLocalNameLocalizedFactoryBase(IRepository repository)
    {
        Repository = repository;
    }

    public virtual CountryLocalNameLocalized CreateLocalizedEntity(CountryLocalNameEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = CreateInternal(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync(CountryLocalNameEntity entity, CountryLocalNameUpsertDto updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<CountryLocalNameLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        entityLocalized.Description = updateDto.Description == null
            ? null
            : Dto.CountryLocalNameMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>());
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<CountryLocalNameLocalized>().Where(x => x.Id == entity.Id && x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        if (updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            entityLocalized.Description = DescriptionUpdateValue == null
                ? null
                : Dto.CountryLocalNameMetadata.CreateDescription(DescriptionUpdateValue);
        }
    }

    private CountryLocalNameLocalized CreateInternal(CountryLocalNameEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new CountryLocalNameLocalized
        {
            CountryLocalName = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.Description = entity.Description;
        }
        entity.CreateRefToLocalizedCountryLocalNames(localizedEntity);
        return localizedEntity;
    }
}