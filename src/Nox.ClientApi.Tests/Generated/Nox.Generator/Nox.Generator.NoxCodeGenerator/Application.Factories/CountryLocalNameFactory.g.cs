// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryLocalNameEntity = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Factories;

internal abstract class CountryLocalNameFactoryBase : IEntityFactory<CountryLocalNameEntity, CountryLocalNameCreateDto, CountryLocalNameUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public CountryLocalNameFactoryBase
    (
        )
    {
    }

    public virtual CountryLocalNameEntity CreateEntity(CountryLocalNameCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryLocalNameEntity entity, CountryLocalNameUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.CountryLocalName ToEntity(CountryLocalNameCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(createDto.Name);
        entity.SetIfNotNull(createDto.NativeName, (entity) => entity.NativeName =ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(createDto.NativeName.NonNullValue<System.String>()));
        return entity;
    }

    private void UpdateEntityInternal(CountryLocalNameEntity entity, CountryLocalNameUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.SetIfNotNull(updateDto.NativeName, (entity) => entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(updateDto.NativeName.ToValueFromNonNull<System.String>()));
    }

    private void PartialUpdateEntityInternal(CountryLocalNameEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NativeName", out var NativeNameUpdateValue))
        {
            if (NativeNameUpdateValue == null) { entity.NativeName = null; }
            else
            {
                entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(NativeNameUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class CountryLocalNameFactory : CountryLocalNameFactoryBase
{
}