// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto : StoreUpdateDto
{

    public ClientApi.Domain.Store ToEntity()
    {
        var entity = new ClientApi.Domain.Store();
        entity.Name = ClientApi.Domain.Store.CreateName(Name);
        //entity.StoreOwner = StoreOwner?.ToEntity();
        //entity.EmailAddress = EmailAddress?.ToEntity();
        return entity;
    }
}