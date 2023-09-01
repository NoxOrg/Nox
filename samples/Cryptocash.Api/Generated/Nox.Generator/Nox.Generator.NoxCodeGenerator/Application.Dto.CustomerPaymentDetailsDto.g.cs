// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CustomerPaymentDetailsKeyDto(System.Int64 keyId);

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class CustomerPaymentDetailsDto
{

    /// <summary>
    /// Customer payment account unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    public System.String PaymentAccountName { get; set; } = default!;

    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    public System.String PaymentAccountNumber { get; set; } = default!;

    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
    public System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// CustomerPaymentDetails Customer's payment account ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CustomerId { get; set; } = default!;
    public virtual CustomerDto Customer { get; set; } = null!;

    /// <summary>
    /// CustomerPaymentDetails Payment provider ExactlyOne PaymentProviders
    /// </summary>
    public virtual PaymentProviderDto PaymentProvider { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public CustomerPaymentDetails ToEntity()
    {
        var entity = new CustomerPaymentDetails();
        entity.Id = CustomerPaymentDetails.CreateId(Id);
        entity.PaymentAccountName = CustomerPaymentDetails.CreatePaymentAccountName(PaymentAccountName);
        entity.PaymentAccountNumber = CustomerPaymentDetails.CreatePaymentAccountNumber(PaymentAccountNumber);
        if (PaymentAccountSortCode is not null)entity.PaymentAccountSortCode = CustomerPaymentDetails.CreatePaymentAccountSortCode(PaymentAccountSortCode.NonNullValue<System.String>());
        entity.Customer = Customer.ToEntity();
        entity.PaymentProvider = PaymentProvider.ToEntity();
        return entity;
    }

}