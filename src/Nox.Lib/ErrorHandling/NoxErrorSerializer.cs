using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;

namespace Nox.Lib;

public class NoxErrorSerializer : ODataErrorSerializer
{
    public override Task WriteObjectAsync(object graph,
        Type type,
        ODataMessageWriter messageWriter,
        ODataSerializerContext writeContext)
    {
        if (graph is SerializableError error)
        {
            ODataError oDataError = error.CreateODataError();
            return base.WriteObjectAsync(oDataError, typeof(ODataError), messageWriter, writeContext);
        }
        else if (graph is ODataError oDataError)
        {
            return base.WriteObjectAsync(oDataError, typeof(ODataError), messageWriter, writeContext);
        }

        return base.WriteObjectAsync(graph, type, messageWriter, writeContext);
    }
}