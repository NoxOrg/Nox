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

    public Workplace ToEntity()
    {
        var entity = new Workplace();
        entity.Name = Workplace.CreateName(Name);
        return entity;
    }
}