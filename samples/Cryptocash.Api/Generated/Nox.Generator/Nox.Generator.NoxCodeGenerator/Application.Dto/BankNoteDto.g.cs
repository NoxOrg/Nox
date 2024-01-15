// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record BankNoteKeyDto(System.Int64 keyId);

/// <summary>
/// Update BankNote
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteDto : BankNoteDtoBase
{

}

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public abstract class BankNoteDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.CashNote is not null)
            CollectValidationExceptions("CashNote", () => BankNoteMetadata.CreateCashNote(this.CashNote.NonNullValue<System.String>()), result);
        else
            result.Add("CashNote", new [] { "CashNote is Required." });
    
        if (this.Value is not null)
            CollectValidationExceptions("Value", () => BankNoteMetadata.CreateValue(this.Value.NonNullValue<MoneyDto>()), result);
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
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String CashNote { get; set; } = default!;

    /// <summary>
    /// Bank note value     
    /// </summary>
    /// <remarks>Required.</remarks>
    public MoneyDto Value { get; set; } = default!;
}