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
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Factories;

public abstract class StoreOwnerFactoryBase: IEntityFactory<StoreOwnerCreateDto,StoreOwner>
{

    public StoreOwnerFactoryBase
    (
        )
    {
    }

    public virtual StoreOwner CreateEntity(StoreOwnerCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private ClientApi.Domain.StoreOwner ToEntity(StoreOwnerCreateDto createDto)
    {
        var entity = new ClientApi.Domain.StoreOwner();
        entity.Id = StoreOwner.CreateId(createDto.Id);
        entity.Name = ClientApi.Domain.StoreOwner.CreateName(createDto.Name);
        if (createDto.VatNumber is not null)entity.VatNumber = ClientApi.Domain.StoreOwner.CreateVatNumber(createDto.VatNumber.NonNullValue<VatNumberDto>());
        if (createDto.StreetAddress is not null)entity.StreetAddress = ClientApi.Domain.StoreOwner.CreateStreetAddress(createDto.StreetAddress.NonNullValue<StreetAddressDto>());
        //entity.Stores = Stores.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}

public partial class StoreOwnerFactory : StoreOwnerFactoryBase
{
}