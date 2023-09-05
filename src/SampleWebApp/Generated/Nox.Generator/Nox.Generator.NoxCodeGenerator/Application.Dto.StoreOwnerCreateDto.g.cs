// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerCreateDto 
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;    
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;

    public SampleWebApp.Domain.StoreOwner ToEntity()
    {
        var entity = new SampleWebApp.Domain.StoreOwner();
        entity.Id = StoreOwner.CreateId(Id);
        entity.Name = SampleWebApp.Domain.StoreOwner.CreateName(Name);
        //entity.Stores = Stores.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}