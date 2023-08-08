using Nox.Solution;

namespace Nox.Factories.Types
{
    public class NoxTypeBooleanFactory : NoxTypeFactoryBase<Nox.Types.Boolean>
    {
        public NoxTypeBooleanFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.Boolean? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Nox.Types.Boolean.From(value);
        }
    }
}