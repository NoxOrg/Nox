﻿// Generated

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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CountryTimeZoneEntity = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application.Factories;

internal abstract class CountryTimeZoneFactoryBase : IEntityFactory<CountryTimeZoneEntity, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public CountryTimeZoneFactoryBase
    (
        )
    {
    }

    public virtual CountryTimeZoneEntity CreateEntity(CountryTimeZoneCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryTimeZoneEntity entity, CountryTimeZoneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryTimeZoneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.CountryTimeZone ToEntity(CountryTimeZoneCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.CountryTimeZone();
        entity.TimeZoneCode = Cryptocash.Domain.CountryTimeZoneMetadata.CreateTimeZoneCode(createDto.TimeZoneCode);
        return entity;
    }

    private void UpdateEntityInternal(CountryTimeZoneEntity entity, CountryTimeZoneUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TimeZoneCode = Cryptocash.Domain.CountryTimeZoneMetadata.CreateTimeZoneCode(updateDto.TimeZoneCode.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(CountryTimeZoneEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("TimeZoneCode", out var TimeZoneCodeUpdateValue))
        {
            if (TimeZoneCodeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TimeZoneCode' can't be null");
            }
            {
                entity.TimeZoneCode = Cryptocash.Domain.CountryTimeZoneMetadata.CreateTimeZoneCode(TimeZoneCodeUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class CountryTimeZoneFactory : CountryTimeZoneFactoryBase
{
}