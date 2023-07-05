using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the Search server used in a Nox solution.")]
    [Description("Specify properties pertinent to the solution Search server here. Examples include name, serverUri, Port and connection credentials")]
    [AdditionalProperties(false)]
    public class SearchServer: ServerBase
    {
        [Required]
        [Title("The search server provider.")]
        [Description("The provider used for this search server server. Examples include ElasticSearch.")]
        public SearchServerProvider Provider { get; internal set; } = SearchServerProvider.ElasticSearch;
    }
}