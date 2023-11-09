// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee definition and related data
/// </summary>
public partial class EmployeeUpdateDto : IEntityDto<DomainNamespace.Employee>
{
    /// <summary>
    /// Employee's first name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Employee's last name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// Employee's email address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Employee's street address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Employee's first working day 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "FirstWorkingDay is required")]
    
    public System.DateTime FirstWorkingDay { get; set; } = default!;
    /// <summary>
    /// Employee's last working day 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee reviewing ExactlyOne CashStockOrders
    /// </summary>
    [Required(ErrorMessage = "CashStockOrder is required")]
    public System.Int64 CashStockOrderId { get; set; } = default!;
}