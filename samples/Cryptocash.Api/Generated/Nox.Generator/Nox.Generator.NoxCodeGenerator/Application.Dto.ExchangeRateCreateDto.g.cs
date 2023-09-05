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

    public ExchangeRate ToEntity()
    {
        var entity = new ExchangeRate();
        entity.EffectiveRate = ExchangeRate.CreateEffectiveRate(EffectiveRate);
        entity.EffectiveAt = ExchangeRate.CreateEffectiveAt(EffectiveAt);
        return entity;
    }
}