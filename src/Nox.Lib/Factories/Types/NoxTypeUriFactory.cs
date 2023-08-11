using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeUriFactory : NoxTypeFactoryBase<Nox.Types.Uri>
    {
        public NoxTypeUriFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.Uri? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            return value == null ? null : Nox.Types.Uri.From(value);
        }
    }
}
