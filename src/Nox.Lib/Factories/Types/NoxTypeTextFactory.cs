using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTextFactory : NoxTypeFactoryBase<Text>
    {
        public NoxTypeTextFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Text? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            
            return Text.From(value, simpleTypeDefinition.TextTypeOptions ?? new TextTypeOptions());
        }
    }

    public class NoxTypeDateTimeFactory : NoxTypeFactoryBase<Nox.Types.DateTime>
    {
        public NoxTypeDateTimeFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.DateTime? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Nox.Types.DateTime.From(value);
        }
    }
}
