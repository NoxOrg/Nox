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
/// Workplace.
/// </summary>
public partial class WorkplaceCreateDto : WorkplaceUpdateDto
{

    public ClientApi.Domain.Workplace ToEntity()
    {
        var entity = new ClientApi.Domain.Workplace();
        entity.Name = ClientApi.Domain.Workplace.CreateName(Name);
        return entity;
    }
}