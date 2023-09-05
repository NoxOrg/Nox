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
/// Customer transaction log and related data.
/// </summary>
public partial class CustomerTransactionCreateDto : CustomerTransactionUpdateDto
{

    public CustomerTransaction ToEntity()
    {
        var entity = new CustomerTransaction();
        entity.TransactionType = CustomerTransaction.CreateTransactionType(TransactionType);
        entity.ProcessedOnDateTime = CustomerTransaction.CreateProcessedOnDateTime(ProcessedOnDateTime);
        entity.Amount = CustomerTransaction.CreateAmount(Amount);
        entity.Reference = CustomerTransaction.CreateReference(Reference);
        //entity.Customer = Customer.ToEntity();
        //entity.Booking = Booking.ToEntity();
        return entity;
    }
}