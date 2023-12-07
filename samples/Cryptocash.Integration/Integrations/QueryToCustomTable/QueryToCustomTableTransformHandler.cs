using System.Dynamic;
using AutoMapper;
using CryptocashIntegration.Application.Integration.CustomTransformHandlers;
using Nox.Integration.Abstractions;

namespace Cryptocash.Integration.Integrations;

public class QueryToCustomTableTransformHandler: QueryToCustomTableTransformHandlerBase, INoxCustomTransformHandler
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));

        var result = mapper.Map<dynamic>(sourceRecord);
        
        //dynamic result = new ExpandoObject();
        result.Id = sourceRecord.CountryId;
        //result.Name = sourceRecord.Name;
        //result.Population = sourceRecord.Population;
        result.AsAt = sourceRecord.CreateDate.DateTime;
        
        return result;
    }
}