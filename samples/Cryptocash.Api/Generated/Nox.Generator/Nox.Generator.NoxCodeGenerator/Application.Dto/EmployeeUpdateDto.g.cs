﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using EmployeeEntity = Cryptocash.Domain.Employee;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeUpdateDto : IEntityDto<EmployeeEntity>
{
    /// <summary>
    /// Employee's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Employee's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// Employee's email address (Required).
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Employee's street address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Employee's first working day (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstWorkingDay is required")]
    
    public System.DateTime FirstWorkingDay { get; set; } = default!;
    /// <summary>
    /// Employee's last working day (Optional).
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee reviewing ExactlyOne CashStockOrders
    /// </summary>
    [Required(ErrorMessage = "EmployeeReviewingCashStockOrder is required")]
    public System.Int64 EmployeeReviewingCashStockOrderId { get; set; } = default!;
}