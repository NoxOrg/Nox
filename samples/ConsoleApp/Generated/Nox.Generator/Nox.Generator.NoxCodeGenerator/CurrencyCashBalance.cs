// Generated

using Nox.Types;

namespace SampleService.Domain;


/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalance
{
    
    /// <summary>
    /// The amount (required).
    /// </summary>
    public Number Amount { get; set; } = null!;
    
    /// <summary>
    /// The Operation Limit (optional).
    /// </summary>
    public Number? OperationLimit { get; set; } = null!;
}
