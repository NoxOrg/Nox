// Generated

#nullable enable

using System;
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

public abstract class EmailAddressFactoryBase: IEntityFactory<EmailAddress,EmailAddressCreateDto>
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
    private ClientApi.Domain.EmailAddress ToEntity(EmailAddressCreateDto createDto)
    {
        var entity = new ClientApi.Domain.EmailAddress();
        if (createDto.Email is not null)entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(createDto.Email.NonNullValue<System.String>());
        if (createDto.IsVerified is not null)entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(createDto.IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }
}

public partial class EmailAddressFactory : EmailAddressFactoryBase
{
}