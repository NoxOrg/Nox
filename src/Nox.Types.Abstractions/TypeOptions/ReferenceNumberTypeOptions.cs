namespace Nox.Types;

public sealed class ReferenceNumberTypeOptions : INoxTypeOptions
{
    /// <summary>
    /// Start Number, example: 1
    /// </summary>
    public int StartsAt { get; set; } = 1;
    /// <summary>
    /// Next number increment, example: 10
    /// </summary>
    public int IncrementsBy { get; set; } = 1;

    /// <summary>
    /// ReferenceNumber Prefix, example: "INV-"
    /// </summary>
    public string Prefix { get; set; }=null!;

    /// <summary>
    /// Add a Checksum digit to the end of the ReferenceNumber.
    /// </summary>
    public bool SuffixCheckSumDigit { get; set; } = true;
}