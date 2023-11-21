using System.Dynamic;
using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class TestNoxCustomTransformHandler: INoxCustomTransformHandler
{
    private readonly NoxSolution _solution;
    
    public string IntegrationName => "SqlToSqlCustomIntegration";

    public TestNoxCustomTransformHandler(NoxSolution solution)
    {
        _solution = solution;
    }
    
    public dynamic Invoke(dynamic sourceRecord)
    {
        dynamic result = new ExpandoObject();
        result.Id = sourceRecord.CountryId;
        result.Name = sourceRecord.Name;
        result.Population = sourceRecord.Population;
        //Check that solution is injected
        var name = _solution.Name;
        return result;
    }
}