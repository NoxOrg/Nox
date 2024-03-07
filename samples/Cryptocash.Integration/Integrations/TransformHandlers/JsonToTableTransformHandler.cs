using AutoMapper;
using CryptocashIntegration.Application.Integration.CustomTransformHandlers;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableTransformHandler: JsonToTableTransformHandlerBase, INoxCustomTransformHandler
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        var result = InvokeBase(sourceRecord);
        result.Id = sourceRecord.CountryId;
        //result.AsAt = DateTime.Parse(sourceRecord.CreateDate);
        result.CreateDate = DateTime.Parse(sourceRecord.CreateDate);
        DateTime? editDate = null;
        if (DateTime.TryParse(sourceRecord.EditDate, out DateTime parsedEditDate))
        {
            editDate = parsedEditDate;
        }
        result.EditDate = editDate ?? null!;
        result.Etag = new Guid(sourceRecord.Etag);
        return result;
    }
}

public abstract class SampleSourceToSampleTargetTransformBase
{
    public string IntegrationName => "JsonToTable";

    public virtual dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}

public partial class SampleSourceToSampleTargetTransform : SampleSourceToSampleTargetTransformBase
{
    public virtual dynamic Invoke(dynamic sourceRecord)
    {
        return base.InvokeBase(sourceRecord);
    }
}


//User can override
public partial class SampleSourceToSampleTargetTransform
{
    public override dynamic InvokeBase(dynamic sourceRecord)
    {
        var target = base.InvokeBase(sourceRecord);
        target.Computed = sourceRecord.Id + sourceRecord.Population;
        return target;
    }
}