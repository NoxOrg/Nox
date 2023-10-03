// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class ExchangeRateExtensions
{
    public static ExchangeRateDto ToDto(this ExchangeRate entity)
    {
        var dto = new ExchangeRateDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.EffectiveRate, () => dto.EffectiveRate = entity!.EffectiveRate!.Value);
        SetIfNotNull(entity?.EffectiveAt, () => dto.EffectiveAt = entity!.EffectiveAt!.Value);

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}