// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class CustomerTransactionUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The transaction type (Required).
    /// </summary>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public System.String TransactionType { get; set; } = default!;
    /// <summary>
    /// The transaction processed datetime (Required).
    /// </summary>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;
    /// <summary>
    /// The transaction amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// The transaction external reference (Required).
    /// </summary>
    [Required(ErrorMessage = "Reference is required")]
    
    public System.String Reference { get; set; } = default!;
}