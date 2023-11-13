using Nox.Types.Schema;
using System;
using System.Diagnostics;

namespace Nox.Solution
{
    [Title("The definition namespace for default endpoints pertaining to a Nox solution.")]
    [Description("Define default endpoints pertinent to a Nox solution here. These include endpoints for API and BFF servers.")]
    [AdditionalProperties(false)]
    public class Endpoints
    {
        [Title("The api route prefix, defaults to api/v1 or to api/vMajor({Solution.Version}) if Version is set in the root of the Solution.")]
        [Description(@"Defines the prefix for all Api routes end points.")]
        public string ApiRoutePrefix { get; internal set; } = null!;
        public ApiServer? ApiServer { get; internal set; }
        public BffServer? BffServer { get; internal set; }
                
        public void ApplyDefaults(string solutionVersion)
        {
            if (ApiRoutePrefix is null || string.IsNullOrEmpty(ApiRoutePrefix))
            {
                ApiRoutePrefix = "/api/v" + new Version(solutionVersion).Major;
                return;
            }
            else
            {
                ApiRoutePrefix = SanitizeRoutePrefix(ApiRoutePrefix);
            }
        }
        /// <summary>
        /// Sanitizes the route prefix by stripping trailing forward slashes and adding leading slashes.
        /// </summary>
        /// <param name="routePrefix">Route prefix to sanitize.</param>
        /// <returns>Sanitized route prefix.</returns>
        private static string SanitizeRoutePrefix(string routePrefix)
        {
            Debug.Assert(routePrefix != null);
            if(string.IsNullOrEmpty(routePrefix))
            {
                return "/";
            }
            if (routePrefix == "/")
            {
                return routePrefix;
            }
            if (!routePrefix!.StartsWith("/"))
            {
                routePrefix = "/" + routePrefix;
            }
            if (routePrefix!.EndsWith("/"))
            {
                return routePrefix.TrimEnd('/');
            }
            return routePrefix;
        }
    }
}