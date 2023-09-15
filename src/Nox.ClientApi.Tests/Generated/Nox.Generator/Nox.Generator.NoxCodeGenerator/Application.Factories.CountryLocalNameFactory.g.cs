using System;// Generated

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

public abstract class CountryLocalNameFactoryBase: IEntityFactory<CountryLocalName,CountryLocalNameCreateDto>
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
    private ClientApi.Domain.CountryLocalName ToEntity(CountryLocalNameCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.Name = ClientApi.Domain.CountryLocalName.CreateName(createDto.Name);
        if (createDto.NativeName is not null)entity.NativeName = ClientApi.Domain.CountryLocalName.CreateNativeName(createDto.NativeName.NonNullValue<System.String>());
        return entity;
    }
}

public partial class CountryLocalNameFactory : CountryLocalNameFactoryBase
{
}