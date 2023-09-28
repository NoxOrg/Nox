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

public record CountryLocalNameKeyDto(System.Int64 keyId);

public partial class CountryLocalNameDto : CountryLocalNameDtoBase
{

}

/// <summary>
/// Local names for countries.
/// </summary>
public abstract class CountryLocalNameDtoBase : EntityDtoBase, IEntityDto<CountryLocalName>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            TryGetValidationExceptions("Name", () => ClientApi.Domain.CountryLocalNameMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.NativeName is not null)
            TryGetValidationExceptions("NativeName", () => ClientApi.Domain.CountryLocalNameMetadata.CreateNativeName(this.NativeName.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public System.String? NativeName { get; set; }
}