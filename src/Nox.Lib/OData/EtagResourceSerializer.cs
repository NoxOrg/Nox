using Castle.Core.Resource;

using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nox.Lib;
public class EtagResourceSerializer : ODataResourceSerializer
{
    public EtagResourceSerializer(IODataSerializerProvider serializerProvider)
        : base(serializerProvider)
    { }

    public override ODataResource CreateResource(SelectExpandNode selectExpandNode, ResourceContext resourceContext)
    {
        ODataResource resource = base.CreateResource(selectExpandNode, resourceContext);

        var etagProperty = resourceContext.ResourceInstance.GetType().GetProperties()
            .FirstOrDefault(x => x.Name.Equals("etag", StringComparison.InvariantCultureIgnoreCase));

        if (etagProperty != null)
        {
            resource.ETag = etagProperty.GetValue(resourceContext.ResourceInstance)?.ToString();
        }

        return resource;
    }
}
