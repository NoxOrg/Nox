﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
public partial class CountryQualityOfLifeIndexCreateDto : CountryQualityOfLifeIndexCreateDtoBase
{

}

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
public abstract class CountryQualityOfLifeIndexCreateDtoBase : IEntityDto<DomainNamespace.CountryQualityOfLifeIndex>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "CountryId is required")]
    public System.Int64? CountryId { get; set; }
    /// <summary>
    /// Rating Index     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "IndexRating is required")]
    
    public virtual System.Int32? IndexRating { get; set; }
}