using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox.Solution
{
    [Title("Information about the team member working on this solution.")]
    [Description("Information of the team member including username and their respective role(s) of which their might me more than one.")]
    [AdditionalProperties(false)]
    public class TeamMember : DefinitionBase
    {
        [Title("The name and surname of the team member.")]
        [Description("The name and surname of the member in the team.")]
        public string? Name { get; internal set; }

        [Required]
        [Title("The version control and organizational user name for the user.")]
        [Description("The user name/email for the user on Github, Azure Devops or another source versioning platform")]
        [Pattern(@"^[^\s]*$")]
        public string UserName { get; internal set; } = null!;

        [Title("Roles that a team member fulfills for this solution.")]
        [Description("The list of one or more roles that the user fulfills for this solution. At least one role is required")]
        [AdditionalProperties(false)]
        public IReadOnlyList<TeamRole>? Roles { get; internal set; }
    }
}