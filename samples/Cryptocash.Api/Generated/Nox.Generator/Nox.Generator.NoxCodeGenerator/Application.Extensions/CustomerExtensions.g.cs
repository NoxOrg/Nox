// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class CustomerExtensions
{
    public static CustomerDto ToDto(this Cryptocash.Domain.Customer entity)
    {
        var dto = new CustomerDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.FirstName, (dto) => dto.FirstName =entity!.FirstName!.Value);
        dto.SetIfNotNull(entity?.LastName, (dto) => dto.LastName =entity!.LastName!.Value);
        dto.SetIfNotNull(entity?.EmailAddress, (dto) => dto.EmailAddress =entity!.EmailAddress!.Value);
        dto.SetIfNotNull(entity?.Address, (dto) => dto.Address =entity!.Address!.ToDto());
        dto.SetIfNotNull(entity?.MobileNumber, (dto) => dto.MobileNumber =entity!.MobileNumber!.Value);
        dto.SetIfNotNull(entity?.PaymentDetails, (dto) => dto.PaymentDetails = entity!.PaymentDetails.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.Bookings, (dto) => dto.Bookings = entity!.Bookings.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.Transactions, (dto) => dto.Transactions = entity!.Transactions.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.CountryId, (dto) => dto.CountryId = entity!.CountryId!.Value);

        return dto;
    }
}