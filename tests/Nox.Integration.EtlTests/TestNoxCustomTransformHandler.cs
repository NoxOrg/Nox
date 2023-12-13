using System.Dynamic;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class TestNoxCustomTransformHandler: TestNoxCustomTransformHandlerBase, INoxCustomTransformHandler
{
    private readonly NoxSolution _solution;
    
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
        //Test that solution is injected
        var name = _solution.Name;
        return result;
    }
}