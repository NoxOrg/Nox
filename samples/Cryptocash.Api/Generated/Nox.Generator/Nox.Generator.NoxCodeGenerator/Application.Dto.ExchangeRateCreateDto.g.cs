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
/// Exchange rate and related data.
/// </summary>
public partial class ExchangeRateCreateDto : ExchangeRateUpdateDto
{

    public Cryptocash.Domain.ExchangeRate ToEntity()
    {
        var entity = new Cryptocash.Domain.ExchangeRate();
        entity.EffectiveRate = Cryptocash.Domain.ExchangeRate.CreateEffectiveRate(EffectiveRate);
        entity.EffectiveAt = Cryptocash.Domain.ExchangeRate.CreateEffectiveAt(EffectiveAt);
        return entity;
    }
}