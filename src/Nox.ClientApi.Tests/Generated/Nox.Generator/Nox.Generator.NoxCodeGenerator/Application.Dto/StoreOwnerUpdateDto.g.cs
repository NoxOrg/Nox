// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners
/// </summary>
public partial class StoreOwnerUpdateDto : IEntityDto<DomainNamespace.StoreOwner>
{
    /// <summary>
    /// Owner Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Temporary Owner Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public System.String TemporaryOwnerName { get; set; } = default!;
    /// <summary>
    /// Vat Number 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Notes { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns OneOrMany Stores
    /// </summary>
    public List<System.Guid> StoresId { get; set; } = new();
}