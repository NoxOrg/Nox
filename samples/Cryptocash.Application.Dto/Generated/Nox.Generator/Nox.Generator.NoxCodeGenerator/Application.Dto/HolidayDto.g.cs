﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record HolidayKeyDto(System.Int64 keyId);

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
public abstract class HolidayDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => HolidayMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Type is not null)
            CollectValidationExceptions("Type", () => HolidayMetadata.CreateType(this.Type.NonNullValue<System.String>()), result);
        else
            result.Add("Type", new [] { "Type is Required." });
    
        CollectValidationExceptions("Date", () => HolidayMetadata.CreateDate(this.Date), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country's holiday unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country holiday name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country holiday type     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Type { get; set; } = default!;

    /// <summary>
    /// Country holiday date     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTime Date { get; set; } = default!;
}