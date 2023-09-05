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

    public Cryptocash.Domain.Transaction ToEntity()
    {
        var entity = new Cryptocash.Domain.Transaction();
        entity.TransactionType = Cryptocash.Domain.Transaction.CreateTransactionType(TransactionType);
        entity.ProcessedOnDateTime = Cryptocash.Domain.Transaction.CreateProcessedOnDateTime(ProcessedOnDateTime);
        entity.Amount = Cryptocash.Domain.Transaction.CreateAmount(Amount);
        entity.Reference = Cryptocash.Domain.Transaction.CreateReference(Reference);
        //entity.Customer = Customer.ToEntity();
        //entity.Booking = Booking.ToEntity();
        return entity;
    }
}