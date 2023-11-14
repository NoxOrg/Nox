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
/// Currency and related data
/// </summary>
public partial class CurrencyUpdateDto : IEntityDto<DomainNamespace.Currency>
{
    /// <summary>
    /// Currency's name 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Name { get; set; }
    /// <summary>
    /// Currency's symbol 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Symbol { get; set; }
}