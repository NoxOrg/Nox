// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class EmployeeCreateDto : EmployeeCreateDtoBase
{

}

/// <summary>
/// Employee definition and related data.
/// </summary>
public abstract class EmployeeCreateDtoBase : IEntityDto<Employee>
{
    /// <summary>
    /// Employee's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Employee's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Employee's email address (Required).
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Employee's street address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Employee's first working day (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstWorkingDay is required")]
    
    public virtual System.DateTime FirstWorkingDay { get; set; } = default!;
    /// <summary>
    /// Employee's last working day (Optional).
    /// </summary>
    public virtual System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee reviewing ExactlyOne CashStockOrders
    /// </summary>
    public System.Int64? EmployeeReviewingCashStockOrderId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual CashStockOrderCreateDto? EmployeeReviewingCashStockOrder { get; set; } = default!;

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberCreateDto> EmployeeContactPhoneNumbers { get; set; } = new();
}