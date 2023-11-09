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
/// Holiday related to country
/// </summary>
public partial class HolidayUpdateDto : IEntityDto<DomainNamespace.Holiday>
{
    /// <summary>
    /// Country holiday name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Country holiday type 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Type is required")]
    
    public System.String Type { get; set; } = default!;
    /// <summary>
    /// Country holiday date 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Date is required")]
    
    public System.DateTime Date { get; set; } = default!;
}