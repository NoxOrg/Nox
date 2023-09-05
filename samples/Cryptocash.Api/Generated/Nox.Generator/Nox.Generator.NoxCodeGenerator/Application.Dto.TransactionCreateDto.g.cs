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
public partial class TransactionCreateDto : TransactionUpdateDto
{

    public Transaction ToEntity()
    {
        var entity = new Transaction();
        entity.TransactionType = Transaction.CreateTransactionType(TransactionType);
        entity.ProcessedOnDateTime = Transaction.CreateProcessedOnDateTime(ProcessedOnDateTime);
        entity.Amount = Transaction.CreateAmount(Amount);
        entity.Reference = Transaction.CreateReference(Reference);
        //entity.Customer = Customer.ToEntity();
        //entity.Booking = Booking.ToEntity();
        return entity;
    }
}