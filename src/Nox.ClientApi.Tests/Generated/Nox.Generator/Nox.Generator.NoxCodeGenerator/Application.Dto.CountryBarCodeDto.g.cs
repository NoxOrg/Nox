
// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryBarCodeKeyDto();

public partial class CountryBarCodeDto : CountryBarCodeDtoBase
{

}

/// <summary>
/// Bar code for country.
/// </summary>
public abstract class CountryBarCodeDtoBase : EntityDtoBase, IEntityDto<CountryBarCode>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.BarCodeName is not null)
            TryGetValidationExceptions("BarCodeName", () => ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(this.BarCodeName.NonNullValue<System.String>()), result);
        else
            result.Add("BarCodeName", new [] { "BarCodeName is Required." });
    
        if (this.BarCodeNumber is not null)
            TryGetValidationExceptions("BarCodeNumber", () => ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(this.BarCodeNumber.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    public System.String BarCodeName { get; set; } = default!;

    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public System.Int32? BarCodeNumber { get; set; }
}