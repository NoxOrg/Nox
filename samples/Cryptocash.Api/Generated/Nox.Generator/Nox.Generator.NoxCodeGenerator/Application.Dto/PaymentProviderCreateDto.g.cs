// Generated

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
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderCreateDto : PaymentProviderCreateDtoBase
{

}

/// <summary>
/// Payment provider related data.
/// </summary>
public abstract class PaymentProviderCreateDtoBase : IEntityDto<DomainNamespace.PaymentProvider>
{
    /// <summary>
    /// Payment provider unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Payment provider name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public virtual System.String? PaymentProviderName { get; set; }
    /// <summary>
    /// Payment provider account type     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public virtual System.String? PaymentProviderType { get; set; }

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<System.Int64> PaymentDetailsId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<PaymentDetailCreateDto> PaymentDetails { get; set; } = new();
}