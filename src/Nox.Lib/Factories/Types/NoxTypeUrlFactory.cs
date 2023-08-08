using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeUrlFactory : NoxTypeFactoryBase<Url>
    {
        public NoxTypeUrlFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Url? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            return value == null ? null : Url.From(value);
        }
    }
}
