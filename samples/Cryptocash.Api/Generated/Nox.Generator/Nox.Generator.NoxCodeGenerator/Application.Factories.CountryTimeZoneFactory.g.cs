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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CountryTimeZone = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Factories;

internal abstract class CountryTimeZoneFactoryBase : IEntityFactory<CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto>
{

    public CountryTimeZoneFactoryBase
    (
        )
    {
    }

    public virtual CountryTimeZone CreateEntity(CountryTimeZoneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryTimeZone entity, CountryTimeZoneUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private Cryptocash.Domain.CountryTimeZone ToEntity(CountryTimeZoneCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.CountryTimeZone();
        entity.TimeZoneCode = Cryptocash.Domain.CountryTimeZone.CreateTimeZoneCode(createDto.TimeZoneCode);
        return entity;
    }

    private void UpdateEntityInternal(CountryTimeZone entity, CountryTimeZoneUpdateDto updateDto)
    {
        entity.TimeZoneCode = Cryptocash.Domain.CountryTimeZone.CreateTimeZoneCode(updateDto.TimeZoneCode.NonNullValue<System.String>());
    }
}

internal partial class CountryTimeZoneFactory : CountryTimeZoneFactoryBase
{
}