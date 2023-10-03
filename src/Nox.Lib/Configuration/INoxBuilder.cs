using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Nox.Monitoring.ElasticApm;

namespace Nox
{
    public interface INoxBuilder
    {
        INoxBuilder UseNoxElasticMonitoring();
        INoxBuilder UseODataRouteDebug();

    }

    internal class NoxBuilder : INoxBuilder
    {
        private readonly IApplicationBuilder _applicationBuilder;

        public NoxBuilder(IApplicationBuilder applicationBuilder)
        {
            _applicationBuilder = applicationBuilder;
        }

        public INoxBuilder UseNoxElasticMonitoring()
        {
            _applicationBuilder.UseNoxAllElasticApm();

            return this;
        }

        public INoxBuilder UseODataRouteDebug()
        {
            _applicationBuilder.UseODataRouteDebug();

            return this;
        }
    }
}