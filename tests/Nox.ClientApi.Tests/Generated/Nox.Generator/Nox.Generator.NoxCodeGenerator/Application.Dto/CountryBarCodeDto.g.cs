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

public record CountryBarCodeKeyDto();

/// <summary>
/// Update CountryBarCode
/// Bar code for country.
/// </summary>
public partial class CountryBarCodeDto : CountryBarCodeDtoBase
{

}

/// <summary>
/// Bar code for country.
/// </summary>
public abstract class CountryBarCodeDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.BarCodeName is not null)
            CollectValidationExceptions("BarCodeName", () => CountryBarCodeMetadata.CreateBarCodeName(this.BarCodeName.NonNullValue<System.String>()), result);
        else
            result.Add("BarCodeName", new [] { "BarCodeName is Required." });
    
        if (this.BarCodeNumber is not null)
            CollectValidationExceptions("BarCodeNumber", () => CountryBarCodeMetadata.CreateBarCodeNumber(this.BarCodeNumber.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Bar code name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String BarCodeName { get; set; } = default!;

    /// <summary>
    /// Bar code number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? BarCodeNumber { get; set; }
}