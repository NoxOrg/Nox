﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record HolidayKeyDto(System.Guid keyId);

/// <summary>
/// Update Holiday
/// Holiday related to country.
/// </summary>
public partial class HolidayDto : HolidayDtoBase
{

}

/// <summary>
/// Holiday related to country.
/// </summary>
public abstract class HolidayDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Holiday>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.HolidayMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Type is not null)
            ExecuteActionAndCollectValidationExceptions("Type", () => DomainNamespace.HolidayMetadata.CreateType(this.Type.NonNullValue<System.String>()), result);
        if (this.Date is not null)
            ExecuteActionAndCollectValidationExceptions("Date", () => DomainNamespace.HolidayMetadata.CreateDate(this.Date.NonNullValue<System.DateTime>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Country's holiday unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Country holiday name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country holiday type     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Type { get; set; }

    /// <summary>
    /// Country holiday date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTime? Date { get; set; }
}