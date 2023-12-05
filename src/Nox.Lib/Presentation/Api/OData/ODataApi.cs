
using Microsoft.AspNetCore.OData.Deltas;
using Nox.Application.Dto;

namespace Nox.Presentation.Api.OData
{
    public static class ODataApi
    {
        /// <summary>
        /// Transform the route prefix defined in NoxSolution to a valid OData API route.
        /// </summary>
        public static string GetRoutePrefix(string apiRoutePrefix)
        {
            return apiRoutePrefix.TrimStart('/');
        }

        public static Dictionary<string, dynamic> GetDeltaUpdatedProperties<T>(Delta<T> delta) where T : class
        {
            var updatedProperties = new Dictionary<string, dynamic>();

            foreach (var propertyName in delta.GetChangedPropertyNames())
            {
                if (delta.TryGetPropertyValue(propertyName, out dynamic value))
                {
                    var property = typeof(T).GetProperty(propertyName)!;

                    var propertyType = property.PropertyType;
                    if (propertyType.GetInterfaces().Contains(typeof(INoxCompoundTypeDto)) && value != null)
                    {
                        var method = typeof(ODataApi).GetMethod("GetDeltaUpdatedProperties");
                        var generic = method!.MakeGenericMethod(propertyType);
                        var nestedProperties = generic.Invoke(null, new object[] { value! });

                        updatedProperties[propertyName] = nestedProperties!;
                    }
                    else
                        updatedProperties[propertyName] = value!;
                }
            }

            return updatedProperties;
        }
    }
}
