using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class HashedTextTypeOptions
{
    public HashingAlgorithm HashingAlgorithm { get; set; } = HashingAlgorithm.SHA256;
    public int SaltLength { get; set; } = 64;
}