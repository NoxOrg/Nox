﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CustomerTransactionKeyDto(System.Int64 keyId);

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class CustomerTransactionDto
{

    /// <summary>
    /// The customer transaction unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The transaction type (Required).
    /// </summary>
    public System.String TransactionType { get; set; } = default!;

    /// <summary>
    /// The transaction processed datetime (Required).
    /// </summary>
    public System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;

    /// <summary>
    /// The transaction amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// The transaction external reference (Required).
    /// </summary>
    public System.String Reference { get; set; } = default!;

    /// <summary>
    /// CustomerTransaction The transaction's related customer ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically...
    public virtual string CustomerId { get; set; } = null!;
    public virtual CustomerDto Customer { get; set; } = null!;

    /// <summary>
    /// CustomerTransaction The transaction's related booking ExactlyOne Bookings
    /// </summary>
    //EF maps ForeignKey Automatically...
    public virtual string BookingId { get; set; } = null!;
    public virtual BookingDto Booking { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public CustomerTransaction ToEntity()
    {
        var entity = new CustomerTransaction();
        entity.Id = CustomerTransaction.CreateId(Id);
        entity.TransactionType = CustomerTransaction.CreateTransactionType(TransactionType);
        entity.ProcessedOnDateTime = CustomerTransaction.CreateProcessedOnDateTime(ProcessedOnDateTime);
        entity.Amount = CustomerTransaction.CreateAmount(Amount);
        entity.Reference = CustomerTransaction.CreateReference(Reference);
        entity.Customer = Customer.ToEntity();
        entity.Booking = Booking.ToEntity();
        return entity;
    }

}