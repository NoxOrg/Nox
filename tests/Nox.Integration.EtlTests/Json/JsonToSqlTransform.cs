using System.Dynamic;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests.Json;

public class JsonToSqlTransform: JsonToSqlTransformHandlerBase, INoxCustomTransform
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        dynamic result = new ExpandoObject();
        result.Id = sourceRecord.CountryId;
        result.Name = sourceRecord.Name;
        result.Population = sourceRecord.Population;
        return result;
    }
}