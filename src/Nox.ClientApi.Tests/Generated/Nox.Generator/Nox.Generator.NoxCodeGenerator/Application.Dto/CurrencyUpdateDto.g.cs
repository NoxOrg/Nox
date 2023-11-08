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

    /// <summary>
    /// Currency List of store licenses where this currency is a default one OneOrMany StoreLicenses
    /// </summary>
    public List<System.Int64> StoreLicenseDefaultId { get; set; } = new();

    /// <summary>
    /// Currency List of store licenses that were sold in this currency OneOrMany StoreLicenses
    /// </summary>
    public List<System.Int64> StoreLicenseSoldInId { get; set; } = new();
}