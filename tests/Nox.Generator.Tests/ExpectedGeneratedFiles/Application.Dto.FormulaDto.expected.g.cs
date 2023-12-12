// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record FormulaKeyDto(System.Int32 keyId);

/// <summary>
/// Update Formula
/// Dto for formulas.
/// </summary>
public partial class FormulaDto : FormulaDtoBase
{

}

/// <summary>
/// Dto for formulas.
/// </summary>
public abstract class FormulaDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Formula>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
       
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.FormulaMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// The identity of the formula
    /// </summary>    
    public System.Int32 Id { get; set; } = default!;

    /// <summary>
    /// The value of Pi     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public decimal? Pi { get; set; }

    /// <summary>
    /// The value of E     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public int? IntPi { get; set; }

    /// <summary>
    /// The value of Greeting     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public string? Greeting { get; set; }

    /// <summary>
    /// The name of the formula     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}