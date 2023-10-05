// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CustomerExtensions
{
    public static CustomerDto ToDto(this Customer entity)
    {
        var dto = new CustomerDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.FirstName, () => dto.FirstName =entity!.FirstName!.Value);
        SetIfNotNull(entity?.LastName, () => dto.LastName =entity!.LastName!.Value);
        SetIfNotNull(entity?.EmailAddress, () => dto.EmailAddress =entity!.EmailAddress!.Value);
        SetIfNotNull(entity?.Address, () => dto.Address =entity!.Address!.ToDto());
        SetIfNotNull(entity?.MobileNumber, () => dto.MobileNumber =entity!.MobileNumber!.Value);
        SetIfNotNull(entity?.CustomerRelatedPaymentDetails, () => dto.CustomerRelatedPaymentDetails = entity!.CustomerRelatedPaymentDetails.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CustomerRelatedBookings, () => dto.CustomerRelatedBookings = entity!.CustomerRelatedBookings.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CustomerRelatedTransactions, () => dto.CustomerRelatedTransactions = entity!.CustomerRelatedTransactions.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CustomerBaseCountryId, () => dto.CustomerBaseCountryId = entity!.CustomerBaseCountryId!.Value);

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