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
/// Holiday related to country.
/// </summary>
public partial class HolidayCreateDto : IEntityCreateDto <Holiday>
{    
    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    [Required(ErrorMessage = "Type is required")]
    
    public System.String Type { get; set; } = default!;    
    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    [Required(ErrorMessage = "Date is required")]
    
    public System.DateTime Date { get; set; } = default!;

    public Cryptocash.Domain.Holiday ToEntity()
    {
        var entity = new Cryptocash.Domain.Holiday();
        entity.Name = Cryptocash.Domain.Holiday.CreateName(Name);
        entity.Type = Cryptocash.Domain.Holiday.CreateType(Type);
        entity.Date = Cryptocash.Domain.Holiday.CreateDate(Date);
        return entity;
    }
}