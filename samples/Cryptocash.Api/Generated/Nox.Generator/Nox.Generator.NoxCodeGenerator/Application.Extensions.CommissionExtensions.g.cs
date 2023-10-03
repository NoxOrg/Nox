// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CommissionExtensions
{
    public static CommissionDto ToDto(this Commission entity)
    {
        var dto = new CommissionDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Rate, () => dto.Rate = entity!.Rate!.Value);
        SetIfNotNull(entity?.EffectiveAt, () => dto.EffectiveAt = entity!.EffectiveAt!.Value);
        SetIfNotNull(entity?.CommissionFeesForCountryId, () => dto.CommissionFeesForCountryId = entity!.CommissionFeesForCountryId!.Value);
        SetIfNotNull(entity?.CommissionFeesForCountry, () => dto.CommissionFeesForCountry = entity!.CommissionFeesForCountry!.ToDto());
        SetIfNotNull(entity?.CommissionFeesForBooking, () => dto.CommissionFeesForBooking = entity!.CommissionFeesForBooking.Select(e => e.ToDto()).ToList());

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