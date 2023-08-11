using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypePhoneNumberFactory : NoxTypeFactoryBase<PhoneNumber>
    {
        public NoxTypePhoneNumberFactory(NoxSolution solution) : base(solution)
        {
        }

        public override PhoneNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return PhoneNumber.From(value);
        }        
    }
}