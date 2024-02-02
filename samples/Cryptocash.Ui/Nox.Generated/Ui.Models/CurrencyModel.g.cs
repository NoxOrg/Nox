// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyModel : CurrencyModelBase
{

}

/// <summary>
/// Currency and related data
/// </summary>
public abstract class CurrencyModelBase: IEntityModel
{

    /// <summary>
    /// Currency unique identifier
    /// </summary>
    public virtual System.String? Id { get; set; }

    /// <summary>
    /// Currency's name     
    /// </summary>
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Currency's iso number id     
    /// </summary>
    public virtual System.Int16? CurrencyIsoNumeric { get; set; }

    /// <summary>
    /// Currency's symbol     
    /// </summary>
    public virtual System.String? Symbol { get; set; }

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
    public virtual System.Boolean? SpaceBetweenAmountAndSymbol { get; set; }

    /// <summary>
    /// Currency's symbol position     
    /// </summary>
    public virtual System.Boolean? SymbolOnLeft { get; set; }

    /// <summary>
    /// Currency's numeric decimal digits     
    /// </summary>
    public virtual System.Int32? DecimalDigits { get; set; }

    /// <summary>
    /// Currency's major name     
    /// </summary>
    public virtual System.String? MajorName { get; set; }

    /// <summary>
    /// Currency's major display symbol     
    /// </summary>
    public virtual System.String? MajorSymbol { get; set; }

    /// <summary>
    /// Currency's minor name     
    /// </summary>
    public virtual System.String? MinorName { get; set; }

    /// <summary>
    /// Currency's minor display symbol     
    /// </summary>
    public virtual System.String? MinorSymbol { get; set; }

    /// <summary>
    /// Currency's minor value when converted to major     
    /// </summary>
    public virtual MoneyModel? MinorToMajorValue { get; set; }
}