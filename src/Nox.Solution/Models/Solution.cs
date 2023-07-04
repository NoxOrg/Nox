using Json.Schema.Generation;
using System;
using System.Collections.Generic;

namespace Nox.Solution
{
    [Title("Fully describes a NOX solution")]
    [Description("Contains all configuration, domain objects and infrastructure declarations that defines a NOX solution. See https://noxorg.dev for more.")]
    [AdditionalProperties(false)]
    public class Solution : DefinitionBase
    {
        [Required]
        [Title("The short name for the solution. Contains no spaces.")]
        [Description("The name of the NOX solution, application or service. This value is used extensively by the NOX tooling and libraries and should ideally be unique within an organisation.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = null!;

        [Title("A short description of the NOX solution.")]
        [Description("A brief description of the solution with what it's purpose or goals are.")]
        public string? Description { get; internal set; }

        [Title("URL to the documentation or specification of the solution.")]
        [Description("A URL which contains the requirements, documentation or specification for this solution.")]
        [Pattern(@"^[^\s]*$")]
        public Uri? Overview { get; internal set; }

        [Title("The environment variables used in your solution and default values.")]
        [Description("A key/value pair of environment variables used in your solution and their defaults.")]
        public IReadOnlyDictionary<string, string>? Variables { get; internal set; }

        [Title("Definitions for run-time environments.")]
        [Description("Definitions for the name, production status and other pertinent information pertaining to run-time environments.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<Environment>? Environments { get; internal set; }

        public VersionControl? VersionControl { get; internal set; }

        [Title("Information about the team working on this solution.")]
        [Description("Specify the members of the team working on the solution including their respective roles.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<TeamMember>? Team { get; internal set; }

        public Domain? Domain { get; internal set; }

        public Infrastructure? Infrastructure { get; internal set; }

        public Application? Application { get; internal set; }
    }
}