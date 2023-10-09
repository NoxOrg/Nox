// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CommissionExtensions
{
    public static CommissionDto ToDto(this Commission entity)
    {
        var dto = new CommissionDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Rate, (dto) => dto.Rate =entity!.Rate!.Value);
        dto.SetIfNotNull(entity?.EffectiveAt, (dto) => dto.EffectiveAt =entity!.EffectiveAt!.Value);
        dto.SetIfNotNull(entity?.CommissionFeesForCountryId, (dto) => dto.CommissionFeesForCountryId = entity!.CommissionFeesForCountryId!.Value);
        dto.SetIfNotNull(entity?.CommissionFeesForBooking, (dto) => dto.CommissionFeesForBooking = entity!.CommissionFeesForBooking.Select(e => e.ToDto()).ToList());

        return dto;
    }
}