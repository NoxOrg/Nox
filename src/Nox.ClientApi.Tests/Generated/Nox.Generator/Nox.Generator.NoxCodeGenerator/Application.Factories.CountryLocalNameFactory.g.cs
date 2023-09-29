// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryLocalName = ClientApi.Domain.CountryLocalName;

namespace ClientApi.Application.Factories;

internal abstract class CountryLocalNameFactoryBase : IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto>
{

    public CountryLocalNameFactoryBase
    (
        )
    {
    }

    public virtual CountryLocalName CreateEntity(CountryLocalNameCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryLocalName entity, CountryLocalNameUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CountryLocalName entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.CountryLocalName ToEntity(CountryLocalNameCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(createDto.Name);
        if (createDto.NativeName is not null)entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(createDto.NativeName.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(CountryLocalName entity, CountryLocalNameUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.CountryLocalNameMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if (updateDto.NativeName == null) { entity.NativeName = null; } else {
            entity.NativeName = ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(updateDto.NativeName.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(CountryLocalName entity, Dictionary<string, dynamic> updatedProperties)
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
}

internal partial class CountryLocalNameFactory : CountryLocalNameFactoryBase
{
}