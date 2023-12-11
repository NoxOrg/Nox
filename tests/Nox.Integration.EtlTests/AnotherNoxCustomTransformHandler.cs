using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests;

public class AnotherNoxCustomTransformHandler: INoxCustomTransformHandler
{
    public string IntegrationName => "SomeOtherIntegration";
    
    public dynamic Invoke(dynamic sourceRecord)
    {
        throw new NotImplementedException();
    }
}