// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CustomerPaymentDetailsKeyDto(System.Int64 keyId);

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class CustomerPaymentDetailsDto
{

    /// <summary>
    /// The customer payment account unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The payment account name (Required).
    /// </summary>
    public System.String PaymentAccountName { get; set; } = default!;

    /// <summary>
    /// The payment account type (Required).
    /// </summary>
    public System.String PaymentAccountType { get; set; } = default!;

    /// <summary>
    /// The payment account reference number (Required).
    /// </summary>
    public System.String PaymentAccountNumber { get; set; } = default!;

    /// <summary>
    /// The payment account sort code (Required).
    /// </summary>
    public System.String PaymentAccountSortCode { get; set; } = default!;

    /// <summary>
    /// CustomerPaymentDetails The payment account related customer ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public string CustomerId { get; set; } = null!;
    public virtual CustomerDto Customer { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}