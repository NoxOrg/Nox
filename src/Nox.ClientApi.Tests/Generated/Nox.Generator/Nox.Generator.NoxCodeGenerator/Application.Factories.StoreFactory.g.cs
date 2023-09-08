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
        entity.Name = ClientApi.Domain.Store.CreateName(createDto.Name);
		entity.EnsureId();
        //entity.StoreOwner = StoreOwner?.ToEntity();
        if(createDto.EmailAddress is not null)
        {
            entity.EmailAddress = EmailAddressFactory.CreateEntity(createDto.EmailAddress);
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