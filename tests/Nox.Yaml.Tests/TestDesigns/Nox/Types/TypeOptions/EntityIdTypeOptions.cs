using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions
{
    public class EntityIdTypeOptions : INoxTypeOptions
    {
        public string Entity { get; set; } = null!;
    }
}