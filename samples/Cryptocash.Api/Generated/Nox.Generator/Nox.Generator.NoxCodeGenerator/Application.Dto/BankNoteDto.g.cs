// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record BankNoteKeyDto(System.Int64 keyId);

public partial class BankNoteDto : BankNoteDtoBase
{

}

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public abstract class BankNoteDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.BankNote>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.CashNote is not null)
            ExecuteActionAndCollectValidationExceptions("CashNote", () => DomainNamespace.BankNoteMetadata.CreateCashNote(this.CashNote.NonNullValue<System.String>()), result);
        else
            result.Add("CashNote", new [] { "CashNote is Required." });
    
        if (this.Value is not null)
            ExecuteActionAndCollectValidationExceptions("Value", () => DomainNamespace.BankNoteMetadata.CreateValue(this.Value.NonNullValue<MoneyDto>()), result);
        else
            result.Add("Value", new [] { "Value is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Currency bank note unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Currency's cash bank note identifier 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String CashNote { get; set; } = default!;

    /// <summary>
    /// Bank note value 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public MoneyDto Value { get; set; } = default!;
}