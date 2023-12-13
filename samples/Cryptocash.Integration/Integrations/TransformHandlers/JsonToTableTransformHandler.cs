using CryptocashIntegration.Application.Integration.CustomTransformHandlers;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations.TransformHandlers;

public class JsonToTableTransformHandler: JsonToTableTransformHandlerBase, INoxCustomTransformHandler
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        var result = InvokeBase(sourceRecord);
        result.Id = sourceRecord.CountryId;
        result.AsAt = DateTime.Parse(sourceRecord.CreateDate);
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