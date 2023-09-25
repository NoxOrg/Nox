﻿// Generated

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
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application.Factories;

internal abstract class StoreFactoryBase : IEntityFactory<Store, StoreCreateDto, StoreUpdateDto>
{
    protected IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto> EmailAddressFactory {get;}

    public StoreFactoryBase
    (
        IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto> emailaddressfactory
        )
    {
        EmailAddressFactory = emailaddressfactory;
    }

    public virtual Store CreateEntity(StoreCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(Store entity, StoreUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private ClientApi.Domain.Store ToEntity(StoreCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Store();
        entity.Name = ClientApi.Domain.Store.CreateName(createDto.Name);
        entity.Address = ClientApi.Domain.Store.CreateAddress(createDto.Address);
        entity.Location = ClientApi.Domain.Store.CreateLocation(createDto.Location);
        if (createDto.OpeningDay is not null)entity.OpeningDay = ClientApi.Domain.Store.CreateOpeningDay(createDto.OpeningDay.NonNullValue<System.DateTimeOffset>());
        entity.EnsureId(createDto.Id);
        if (createDto.VerifiedEmails is not null)
        {
            entity.VerifiedEmails = EmailAddressFactory.CreateEntity(createDto.VerifiedEmails);
        }
        return entity;
    }

    private void UpdateEntityInternal(Store entity, StoreUpdateDto updateDto)
    {
        entity.Name = ClientApi.Domain.Store.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Address = ClientApi.Domain.Store.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
        entity.Location = ClientApi.Domain.Store.CreateLocation(updateDto.Location.NonNullValue<LatLongDto>());
        if (updateDto.OpeningDay == null) { entity.OpeningDay = null; } else {
            entity.OpeningDay = ClientApi.Domain.Store.CreateOpeningDay(updateDto.OpeningDay.ToValueFromNonNull<System.DateTimeOffset>());
        }
    }
}

internal partial class StoreFactory : StoreFactoryBase
{
    public StoreFactory
    (
        IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto> emailaddressfactory
    ): base(emailaddressfactory)
    {}
}