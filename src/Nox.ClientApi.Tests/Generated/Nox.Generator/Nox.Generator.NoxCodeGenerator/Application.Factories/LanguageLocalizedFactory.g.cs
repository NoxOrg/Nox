// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using LanguageEntity = ClientApi.Domain.Language;

namespace ClientApi.Application.Factories;

internal partial class LanguageLocalizedFactory : LanguageLocalizedFactoryBase
{
}

internal abstract class LanguageLocalizedFactoryBase : IEntityLocalizedFactory<LanguageLocalized, LanguageEntity, LanguageUpdateDto>
{
    public virtual LanguageLocalized CreateLocalizedEntity(LanguageEntity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new LanguageLocalized
        {
            Language = entity,
            CultureCode = cultureCode,
        };

        if (copyEntityAttributes)
        {
            localizedEntity.Name = entity.Name;
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity(LanguageLocalized localizedEntity, LanguageUpdateDto updateDto)
    {
        localizedEntity.Name = updateDto.Name == null
            ? null
            : ClientApi.Domain.LanguageMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>());
    }

    public virtual void PartialUpdateLocalizedEntity(LanguageLocalized localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            localizedEntity.Name = NameUpdateValue == null
                ? null
                : ClientApi.Domain.LanguageMetadata.CreateName(NameUpdateValue);
        }
    }
}