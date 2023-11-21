using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlTests;

public class TestNoxCustomTransformHandler: INoxCustomTransformHandler
{
    public string IntegrationName => "SqlToSqlCustomIntegration";
    
    public IDictionary<string, string> Invoke()
    {
        var result = new Dictionary<string, string>();
        result.Add("CountryId", "Id");
        return result;
    }
}