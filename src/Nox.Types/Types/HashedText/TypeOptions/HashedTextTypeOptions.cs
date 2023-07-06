namespace Nox.Types;

public class HashedTextTypeOptions
{
    public HashingAlgorithm HashingAlgorithm { get; set; } = HashingAlgorithm.SHA256;
    public int Salt { get; set; } = 64;
}