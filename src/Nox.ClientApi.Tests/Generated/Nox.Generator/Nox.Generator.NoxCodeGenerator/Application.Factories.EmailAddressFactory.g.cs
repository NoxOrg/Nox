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
using EmailAddress = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Factories;

public abstract class EmailAddressFactoryBase : IEntityFactory<EmailAddress, EmailAddressCreateDto, EmailAddressUpdateDto>
{

    public EmailAddressFactoryBase
    (
        )
    {
    }

    public virtual EmailAddress CreateEntity(EmailAddressCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public void UpdateEntity(EmailAddress entity, EmailAddressUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private ClientApi.Domain.EmailAddress ToEntity(EmailAddressCreateDto createDto)
    {
        var entity = new ClientApi.Domain.EmailAddress();
        if (createDto.Email is not null)entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(createDto.Email.NonNullValue<System.String>());
        if (createDto.IsVerified is not null)entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(createDto.IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }

    private void MapEntity(EmailAddress entity, EmailAddressUpdateDto updateDto)
    {
        // TODO: discuss about keys
        if (updateDto.Email is not null)entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(updateDto.Email.NonNullValue<System.String>());
        if (updateDto.IsVerified is not null)entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(updateDto.IsVerified.NonNullValue<System.Boolean>());

        // TODO: discuss about keys
    }
}

public partial class EmailAddressFactory : EmailAddressFactoryBase
{
}