using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTemperatureFactory : NoxTypeFactoryBase<Temperature>
    {
        public NoxTypeTemperatureFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Temperature? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Temperature.From(value, simpleTypeDefinition.TemperatureTypeOptions ?? new TemperatureTypeOptions());
        }        
    }
}