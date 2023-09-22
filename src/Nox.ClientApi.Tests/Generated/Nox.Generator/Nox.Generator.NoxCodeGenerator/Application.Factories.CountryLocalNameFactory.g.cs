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

public abstract class CountryLocalNameFactoryBase : IEntityFactory<CountryLocalName, CountryLocalNameCreateDto, CountryLocalNameUpdateDto>
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

    private ClientApi.Domain.CountryLocalName ToEntity(CountryLocalNameCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.Name = ClientApi.Domain.CountryLocalName.CreateName(createDto.Name);
        if (createDto.NativeName is not null)entity.NativeName = ClientApi.Domain.CountryLocalName.CreateNativeName(createDto.NativeName.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(CountryLocalName entity, CountryLocalNameUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.CountryLocalName.CreateName(updateDto.Name.NonNullValue<System.String>());
        if (updateDto.NativeName == null) { entity.NativeName = null; } else {
            entity.NativeName = ClientApi.Domain.CountryLocalName.CreateNativeName(updateDto.NativeName.ToValueFromNonNull<System.String>());
        }
    }
}

public partial class CountryLocalNameFactory : CountryLocalNameFactoryBase
{
}