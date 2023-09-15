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
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application.Factories;

public abstract class StoreFactoryBase: IEntityFactory<Store,StoreCreateDto>
{
    protected IEntityFactory<EmailAddress,EmailAddressCreateDto> EmailAddressFactory {get;}

    public StoreFactoryBase
    (
        IEntityFactory<EmailAddress,EmailAddressCreateDto> emailaddressfactory
        )
    {        
        EmailAddressFactory = emailaddressfactory;
    }

    public virtual Store CreateEntity(StoreCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private ClientApi.Domain.Store ToEntity(StoreCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Store();
        entity.Id = ( createDto.Id == null || System.Guid.Empty.Equals(createDto.Id) ) ? Nox.Types.Guid.From(System.Guid.NewGuid()) : Store.CreateId(createDto.Id);
        entity.Name = ClientApi.Domain.Store.CreateName(createDto.Name);
        entity.Address = ClientApi.Domain.Store.CreateAddress(createDto.Address);
        entity.Location = ClientApi.Domain.Store.CreateLocation(createDto.Location);
        //entity.StoreOwner = StoreOwner?.ToEntity();
        if (createDto.VerifiedEmails is not null)
        {
            entity.VerifiedEmails = EmailAddressFactory.CreateEntity(createDto.VerifiedEmails);
        }
        return entity;
    }
}

public partial class StoreFactory : StoreFactoryBase
{
    public StoreFactory
    (
        IEntityFactory<EmailAddress,EmailAddressCreateDto> emailaddressfactory
    ): base(emailaddressfactory)                      
    {}
}