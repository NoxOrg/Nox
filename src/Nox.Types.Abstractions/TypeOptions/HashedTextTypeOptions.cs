namespace Nox.Types;

public class HashedTextTypeOptions : INoxTypeOptions
{
    public HashingAlgorithm HashingAlgorithm { get; set; } = HashingAlgorithm.SHA256;
    public int SaltLength { get; set; } = 64;
}