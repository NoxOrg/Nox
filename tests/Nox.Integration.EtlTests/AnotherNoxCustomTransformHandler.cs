using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlTests;

public class AnotherNoxCustomTransformHandler: INoxCustomTransformHandler
{
    public string IntegrationName => "SomeOtherIntegration";
    
    public IDictionary<string, string> Invoke()
    {
        throw new NotImplementedException();
    }
}