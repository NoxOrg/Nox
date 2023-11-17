// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class ExchangeRateExtensions
{
    public static ExchangeRateDto ToDto(this Cryptocash.Domain.ExchangeRate entity)
    {
        var dto = new ExchangeRateDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.EffectiveRate, (dto) => dto.EffectiveRate =entity!.EffectiveRate!.Value);
        dto.SetIfNotNull(entity?.EffectiveAt, (dto) => dto.EffectiveAt =entity!.EffectiveAt!.Value);

        return dto;
    }
}