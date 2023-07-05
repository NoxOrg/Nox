using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for default endpoints pertaining to a Nox solution.")]
    [Description("Define default endpoints pertinent to a Nox solution here. These include endpoints for API and BFF servers.")]
    [AdditionalProperties(false)]
    public class Endpoints
    {
        public ApiServer? ApiServer { get; internal set; }
        public BffServer? BffServer { get; internal set; }
    }
}