using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Specifies information on displaying the entity on a user interface.")]
    [Description("Provides hints to rendering engines as to how this entity should be managed in the user interface.")]
    [AdditionalProperties(false)]
    public class EntityUserInterface : DefinitionBase
    {
        [Title("An icon that distinctly and visually represents the entity.")]
        [Description("An optional icon that represents the entity as a key or in SVG format. It can be a URI that points to a resource countaining the SVG data.")]
        [Pattern(@"^[^\s]*$")]
        public string Icon { get; internal set; } = string.Empty;
    }
}