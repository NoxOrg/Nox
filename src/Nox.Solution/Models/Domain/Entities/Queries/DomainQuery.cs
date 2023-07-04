using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox.Solution
{
    [Title("Defines a query for the domain.")]
    [Description("Defines a query that operates on the domain. Queries should have no side effects and not mutate the domain state.")]
    [AdditionalProperties(false)]
    public class DomainQuery : DefinitionBase
    {
        [Required]
        [Title("The name of the query. Contains no spaces.")]
        [Description("A descriptive name for the query, usually in the format Get[Entity]by[Grouping]. Eg \"GetCountriesByContinent\".")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = null!;

        [Title("A phrase describing expected output from the domain query.")]
        [Description("A phrase that describes expected result from the query. Eg. \"Returns a list of countries for a given continent\".")]
        public string? Description { get; internal set; }

        [Title("Defines the request input parameters for domain queries")]
        [Description("Specifies one or more domain query input parameter collections")]
        [AdditionalProperties(false)]
        public IReadOnlyList<DomainQueryRequestInput>? RequestInput { get; internal set; }

        [Required]
        [Title("Defines the request input parameters for domain queries")]
        [Description("Specifies one or more domain query input parameter collections")]
        [AdditionalProperties(false)]
        public DomainQueryResponseOutput ResponseOutput { get; internal set; } = new();
    }
}