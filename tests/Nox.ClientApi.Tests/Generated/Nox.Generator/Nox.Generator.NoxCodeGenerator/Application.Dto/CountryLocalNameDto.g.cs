﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace ClientApi.Application.Dto;

public record CountryLocalNameKeyDto(System.Int64 keyId);

/// <summary>
/// Update CountryLocalName
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameDto : CountryLocalNameDtoBase
{

}

/// <summary>
/// Local names for countries.
/// </summary>
public abstract class CountryLocalNameDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => CountryLocalNameMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.NativeName is not null)
            CollectValidationExceptions("NativeName", () => CountryLocalNameMetadata.CreateNativeName(this.NativeName.NonNullValue<System.String>()), result);
        if (this.Description is not null)
            CollectValidationExceptions("Description", () => CountryLocalNameMetadata.CreateDescription(this.Description.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// The unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Local name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Local name in native tongue     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? NativeName { get; set; }

    /// <summary>
    /// Description     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Description { get; set; }
}