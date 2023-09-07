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

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeCreateDto : IEntityCreateDto <Employee>
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

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberCreateDto> EmployeePhoneNumbers { get; set; } = new();

    public Cryptocash.Domain.Employee ToEntity()
    {
        var entity = new Cryptocash.Domain.Employee();
        entity.FirstName = Cryptocash.Domain.Employee.CreateFirstName(FirstName);
        entity.LastName = Cryptocash.Domain.Employee.CreateLastName(LastName);
        entity.EmailAddress = Cryptocash.Domain.Employee.CreateEmailAddress(EmailAddress);
        entity.Address = Cryptocash.Domain.Employee.CreateAddress(Address);
        entity.FirstWorkingDay = Cryptocash.Domain.Employee.CreateFirstWorkingDay(FirstWorkingDay);
        if (LastWorkingDay is not null)entity.LastWorkingDay = Cryptocash.Domain.Employee.CreateLastWorkingDay(LastWorkingDay.NonNullValue<System.DateTime>());
        //entity.CashStockOrder = CashStockOrder.ToEntity();
        entity.EmployeePhoneNumbers = EmployeePhoneNumbers.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}