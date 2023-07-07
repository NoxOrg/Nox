using Nox.Solution;

namespace Nox.Secrets.Tests;

public class MockSecretsValidFor : SecretsValidFor
{
    public new int? Days { get; set; }
    public new int? Hours { get; set; }
    public new int? Minutes { get; set; }
    public new int? Seconds { get; set; }
}