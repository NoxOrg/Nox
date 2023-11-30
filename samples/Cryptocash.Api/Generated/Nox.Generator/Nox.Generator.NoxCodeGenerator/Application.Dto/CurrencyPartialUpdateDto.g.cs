// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyPartialUpdateDto : CurrencyPartialUpdateDtoBase
{

}

/// <summary>
/// Currency and related data
/// </summary>
public partial class CurrencyPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Currency>
{
    /// <summary>
    /// Currency's name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Currency's iso number id
    /// </summary>
    public virtual System.Int16 CurrencyIsoNumeric { get; set; } = default!;
    /// <summary>
    /// Currency's symbol
    /// </summary>
    public virtual System.String Symbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric thousands notation separator
    /// </summary>
    public virtual System.String? ThousandsSeparator { get; set; }
    /// <summary>
    /// Currency's numeric decimal notation separator
    /// </summary>
    public virtual System.String? DecimalSeparator { get; set; }
    /// <summary>
    /// Currency's numeric space between amount and symbol
    /// </summary>
    public virtual System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric decimal digits
    /// </summary>
    public virtual System.Int32 DecimalDigits { get; set; } = default!;
    /// <summary>
    /// Currency's major name
    /// </summary>
    public virtual System.String MajorName { get; set; } = default!;
    /// <summary>
    /// Currency's major display symbol
    /// </summary>
    public virtual System.String MajorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor name
    /// </summary>
    public virtual System.String MinorName { get; set; } = default!;
    /// <summary>
    /// Currency's minor display symbol
    /// </summary>
    public virtual System.String MinorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor value when converted to major
    /// </summary>
    public virtual MoneyDto MinorToMajorValue { get; set; } = default!;
}