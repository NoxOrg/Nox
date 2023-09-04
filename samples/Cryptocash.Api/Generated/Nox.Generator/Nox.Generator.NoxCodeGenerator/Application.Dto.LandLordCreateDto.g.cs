// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLordCreateDto : LandLordUpdateDto
{

    public LandLord ToEntity()
    {
        var entity = new LandLord();
        entity.Name = LandLord.CreateName(Name);
        entity.Address = LandLord.CreateAddress(Address);
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}