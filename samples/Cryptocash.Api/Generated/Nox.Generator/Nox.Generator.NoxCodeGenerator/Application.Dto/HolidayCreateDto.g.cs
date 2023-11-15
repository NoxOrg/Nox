﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Holiday related to country.
/// </summary>
public partial class HolidayCreateDto : HolidayCreateDtoBase
{

}

/// <summary>
/// Holiday related to country.
/// </summary>
public abstract class HolidayCreateDtoBase : IEntityDto<DomainNamespace.Holiday>
{
    /// <summary>
    /// Country holiday name 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Country holiday type 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Type is required")]
    
    public virtual System.String Type { get; set; } = default!;
    /// <summary>
    /// Country holiday date 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Date is required")]
    
    public virtual System.DateTime Date { get; set; } = default!;
}