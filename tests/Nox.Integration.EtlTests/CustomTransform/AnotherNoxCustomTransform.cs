using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests.CustomTransform;

public class AnotherNoxCustomTransform: INoxCustomTransform
{
    public string IntegrationName => "SomeOtherIntegration";
    
    public dynamic Invoke(dynamic sourceRecord)
    {
        throw new NotImplementedException();
    }
}