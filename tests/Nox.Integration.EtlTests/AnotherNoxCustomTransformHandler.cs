using System.Dynamic;
using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlTests;

public class AnotherNoxCustomTransformHandler: INoxCustomTransformHandler
{
    public string IntegrationName => "SomeOtherIntegration";
    
    public dynamic Invoke(dynamic sourceRecord)
    {
        throw new NotImplementedException();
    }
}