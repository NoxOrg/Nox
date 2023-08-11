using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeYamlFactory : NoxTypeFactoryBase<Yaml>
    {
        public NoxTypeYamlFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Yaml? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            return value == null ? null : Yaml.From(value);
        }
    }
}
