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
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionCreateDto : CommissionUpdateDto
{

    public Cryptocash.Domain.Commission ToEntity()
    {
        var entity = new Cryptocash.Domain.Commission();
        entity.Rate = Cryptocash.Domain.Commission.CreateRate(Rate);
        entity.EffectiveAt = Cryptocash.Domain.Commission.CreateEffectiveAt(EffectiveAt);
        //entity.Country = Country?.ToEntity();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}